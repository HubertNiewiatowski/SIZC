namespace SIZCapi.DTOs
{
    public class PobierzSkladnikiDto
    {
        public int SkladnikID { get; set; }

        public string NazwaSkladnik { get; set; }

        public bool CzyWeganski { get; set; }

        public bool CzyWegetarianski { get; set; }

        public float MasaSkladnik { get; set; }

        public float MasaWartoscOdzywcza { get; set; }   
    }
}