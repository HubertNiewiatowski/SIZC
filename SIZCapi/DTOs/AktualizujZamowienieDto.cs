using System;

namespace SIZCapi.DTOs
{
    public class AktualizujZamowienieDto
    {
        public int ZamowienieID { get; set; }

        public decimal Koszt { get; set; }

        public string KodPocztowy { get; set; }
        
        public string Miejscowosc { get; set; }

        public string Ulica { get; set; }

        public string NrBudynek { get; set; }

        public string NrMieszkanie { get; set; }

        public DateTime DataRealizacji { get; set; }

        public DateTime DataZlozenia { get; set; }

        public int PozycjaMenuID { get; set; }

        public int KlientID { get; set; }

        public int PracownikID { get; set; }

        public int PlatnoscTypID { get; set; }

        public int ZamowienieStatusID { get; set; }
    }
}