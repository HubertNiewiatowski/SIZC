using System;
using System.ComponentModel.DataAnnotations;

namespace SIZCapi.DTOs
{
    public class KlientDoRejestracjiDto
    {
        [Required]
        public string Imie { get; set; }
        
        [Required]
        public string Nazwisko { get; set; }
        
        [Required]
        [EmailAddress]
        public string AdresEmail { get; set; }
 
        public string NrTelStacjonarny { get; set; }
 
        public string NrTelKomorkowy { get; set; }
        
        [Required]
        public string KodPocztowy { get; set; }
        
        [Required]
        public string Miejscowosc { get; set; }
 
        public string Ulica { get; set; }
 
        public string NrBudynek { get; set; }
 
        public string NrMieszkanie { get; set; }
 
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Hasło musi zawierać pomiędzy 6 a 50 znaków")]
        public string Haslo { get; set; }

        [Required]
        public DateTime DataRejestracji { get; set; }
    }
}