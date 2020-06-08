using System.ComponentModel.DataAnnotations;

namespace SIZCapi.DTOs
{
    public class DodajPozycjaMenuDto
    {
        [Required]
        public string NazwaPozycja { get; set; }

        [Required]
        public decimal Cena { get; set; }
        
        [Required]
        public string Opis { get; set; }
        
        public string ObrazekUrl { get; set; }
    }
}