using System.Xml.Linq;

namespace BE_ProgettoSettimana2.Models
{
    public static class ProductRepository
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name= "Nike Jordan 1",
                Price = 750,
                Description = "Le Air Jordan 1 sono un icona senza tempo del mondo sneaker. Rilasciate per la prima volta nel 1985, presentano la classica colorway bianco, rosso e nero ispirata ai Chicago Bulls.",
                CoverImageBase64 = GetBase64DefaultImage("Jordan1.jpg"),
                Image1Base64 = GetBase64DefaultImage("Jordan1Lat.jpg"),
                Image2Base64 = GetBase64DefaultImage("Jordan1High.jpg")

            },

            new Product
            {
                Id = 2,
                Name= "Nike Jordan 2",
                Price = 180,
                Description = "Le Air Jordan 1 sono un icona senza tempo del mondo sneaker. Rilasciate per la prima volta nel 1985, presentano la classica colorway bianco, rosso e nero ispirata ai Chicago Bulls.",
                CoverImageBase64 = GetBase64DefaultImage("Jordan2.jpg"),
                Image1Base64 = GetBase64DefaultImage("Jordan2Lat.jpg"),
                Image2Base64 = GetBase64DefaultImage("Jordan2Retro.jpg")

            },

            new Product
            {
                Id = 3,
                Name= "Nike Jordan 12",
                Price = 400,
                Description = "Le Air Jordan 12 \"Flu Game\" sono una delle scarpe più iconiche nella storia delle sneaker, celebrate per il loro legame indissolubile con una delle partite più leggendarie di Michael Jordan. Indossate durante la famosa partita delle Finals NBA del 1997 contro i Utah Jazz, quando MJ, malato e debilitato, ha dato il massimo per portare i Chicago Bulls alla vittoria, le \"Flu Game\" sono diventate simbolo di resilienza e forza.",
                CoverImageBase64 = GetBase64DefaultImage("Jordan12.jpg"),
                Image1Base64 = GetBase64DefaultImage("Jordan12Lat.jpg"),
                Image2Base64 = GetBase64DefaultImage("Jordan12Back.jpg")

            },
            new Product
            {
                Id = 4,
                Name= "Nike Jordan 11",
                Price = 350,
                Description = "Le Air Jordan 11 \"Concord\" sono uno dei modelli più iconici e amati della linea Jordan. Caratterizzate da una tomaia in pelle bianca lucida, accenti neri e una suola trasparente, queste scarpe combinano eleganza e performance. Lanciate per la prima volta nel 1995, le \"Concord\" sono state indossate da Michael Jordan durante la sua prima stagione di ritorno in NBA.",
                CoverImageBase64 = GetBase64DefaultImage("Jordan11.jpg"),
                Image1Base64 = GetBase64DefaultImage("Jordan11Lat.jpg"),
                Image2Base64 = GetBase64DefaultImage("Jordan11Back.jpg")

            }
            
        };  
        
        private static string GetBase64DefaultImage( string fileName)
        {
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", fileName);
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }

        public static List<Product> GetProducts()
        {
            return products;
        }

        public static Product? GetProductById(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public static bool UpdateProduct(Product updatedProduct)
        {
            var existingProduct = GetProductById(updatedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.CoverImageBase64 = updatedProduct.CoverImageBase64;
                existingProduct.Image1Base64 = updatedProduct.Image1Base64;
                existingProduct.Image2Base64 = updatedProduct.Image2Base64;
                return true;
            }
            return false;
        }
    }
}
