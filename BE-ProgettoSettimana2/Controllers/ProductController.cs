using Microsoft.AspNetCore.Mvc;
using BE_ProgettoSettimana2;
using BE_ProgettoSettimana2.Models;

namespace BE_ProgettoSettimana2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var products = ProductRepository.GetProducts();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = ProductRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.CoverImageFile != null)
                {
                    product.CoverImageBase64 = ConvertToBase64(product.CoverImageFile);
                }
                if (product.Image1File != null)
                {
                    product.Image1Base64 = ConvertToBase64(product.Image1File);
                }
                if (product.Image2File != null)
                {
                    product.Image2Base64 = ConvertToBase64(product.Image2File);
                }

                product.Id = ProductRepository.GetProducts().Any() ? ProductRepository.GetProducts().Max(p => p.Id) + 1 : 1;
                ProductRepository.GetProducts().Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        private string ConvertToBase64(Microsoft.AspNetCore.Http.IFormFile file)
        {
            

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream); 
                var fileBytes = memoryStream.ToArray(); 
                return Convert.ToBase64String(fileBytes);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = ProductRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Errore nella validazione del modello");
                return View(updatedProduct);
            }

            var product = ProductRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            Console.WriteLine($"Aggiornando il prodotto con ID: {id}");
            Console.WriteLine($"Nuovo Nome: {updatedProduct.Name}");
            Console.WriteLine($"Nuovo Prezzo: {updatedProduct.Price}");

            // Aggiorna le immagini solo se sono state caricate
            if (updatedProduct.CoverImageFile != null)
            {
                updatedProduct.CoverImageBase64 = ConvertToBase64(updatedProduct.CoverImageFile);
            }
            else
            {
                updatedProduct.CoverImageBase64 = product.CoverImageBase64; // mantiene l'immagine esistente
            }

            if (updatedProduct.Image1File != null)
            {
                updatedProduct.Image1Base64 = ConvertToBase64(updatedProduct.Image1File);
            }
            else
            {
                updatedProduct.Image1Base64 = product.Image1Base64; // mantiene l'immagine esistente
            }

            if (updatedProduct.Image2File != null)
            {
                updatedProduct.Image2Base64 = ConvertToBase64(updatedProduct.Image2File);
            }
            else
            {
                updatedProduct.Image2Base64 = product.Image2Base64; 
            }

            bool success = ProductRepository.UpdateProduct(updatedProduct);
            if (!success)
            {
                ModelState.AddModelError("", "Errore durante l'aggiornamento del prodotto");
                return View(updatedProduct);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
