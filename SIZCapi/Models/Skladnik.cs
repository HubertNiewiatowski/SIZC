using System.Collections.Generic;
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

        // relacja PozycjaMenu
        public int PozycjaMenuID { get; set; }
        public virtual PozycjaMenu PozycjaMenu { get; set; }

        // relacja InformacjaAlergen
        public virtual ICollection<InformacjaAlergen> InformacjaAlergen { get; set; }
        
        // relacja WartoscOdzywcza
        public virtual ICollection<WartoscOdzywcza> WartoscOdzywcza { get; set; }
    }
}