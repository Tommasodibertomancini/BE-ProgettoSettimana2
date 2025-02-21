using System.ComponentModel.DataAnnotations;

namespace BE_ProgettoSettimana2.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obbligatorio")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Prezzo obbligatorio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "è richiesta una descrizione")]
        [MinLength(10, ErrorMessage = "La descrizione deve avere più di 10 caratteri")]
        [MaxLength(1000, ErrorMessage = "La descrizione deve avere meno di 1000 caratteri")]
        public string? Description { get; set; }

        public string? CoverImageBase64 { get; set; }
        public string? Image1Base64 { get; set; }
        public string? Image2Base64 { get; set; }

        [Required(ErrorMessage = "Immagine di Cover obbligatoria")]
        public IFormFile? CoverImageFile { get; set; }

        [Required(ErrorMessage = "Immagine obbligatoria")]
        public IFormFile? Image1File { get; set; }

        [Required(ErrorMessage = "Immagine obbligatoria")]
        public IFormFile? Image2File { get; set; }

    }
}
