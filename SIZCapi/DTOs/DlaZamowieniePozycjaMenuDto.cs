namespace SIZCapi.DTOs
{
    public class DlaZamowieniePozycjaMenuDto
    {
        public int PozycjaMenuID { get; set; }
        
        public string NazwaPozycja { get; set; } 

        public decimal Cena { get; set; }

        public string Opis { get; set; }

        public string ObrazekUrl { get; set; }
    }
}