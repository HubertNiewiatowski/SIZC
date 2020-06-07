using System;
using System.ComponentModel.DataAnnotations;

namespace SIZCapi.DTOs
{
    public class DodajZamowienieDto
    {
        [Required]
        public decimal Koszt { get; set; }

        [Required]
        public string KodPocztowy { get; set; }
        
        [Required]
        public string Miejscowosc { get; set; }

        public string Ulica { get; set; }
        
        public string NrBudynek { get; set; }
        
        public string NrMieszkanie { get; set; }
        
        public DateTime DataRealizacji { get; set; }
        
        public DateTime DataZlozenia { get; set; }

        [Required]
        public int PozycjaMenuID { get; set; }
        
        [Required]
        public int KlientID { get; set; }
        
        [Required]
        public int PracownikID { get; set; }
        
        [Required]
        public int PlatnoscTypID { get; set; }
        
        [Required]
        public int ZamowienieStatusID { get; set; }
    }
}