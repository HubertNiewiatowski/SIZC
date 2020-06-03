using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class Skladnik
    {
        public int SkladnikID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NazwaSkladnik { get; set; }

        public bool CzyWeganski { get; set; }

        public bool CzyWegetarianski { get; set; }

        public float MasaSkladnik { get; set; }

        public float MasaWartoscOdzywcza { get; set; }

        //relacja PozycjaMenu
        public int PozycjaMenuID { get; set; }
        public virtual PozycjaMenu PozycjaMenu { get; set; }

        //relacja Alergen
        public int AlergenID { get; set; }
        public virtual Alergen Alergen { get; set; }
        
        //relacja WartoscOdzywcza
        public int WartoscOdzywczaID { get; set; }
        public virtual WartoscOdzywcza WartoscOdzywcza { get; set; }
    }
}