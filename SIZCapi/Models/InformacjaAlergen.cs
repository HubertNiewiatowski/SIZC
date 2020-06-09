namespace SIZCapi.Models
{
    public class InformacjaAlergen
    {
        public int InformacjaAlergenID { get; set; }

        // relacja Skladnik
        public int SkladnikID { get; set; }
        public virtual Skladnik Skladnik { get; set; }

        // relacja Alergen
        public int AlergenID { get; set; }
        public virtual Alergen Alergen { get; set; }
    }
}