using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class WartoscOdzywcza
    {
        public int WartoscOdzywczaID { get; set; }

        public float ZawartoscSkladnikOdzywczy { get; set; }

        // relacja Skladnik
        public int SkladnikID { get; set; }
        public virtual Skladnik Skladnik { get; set; }

        // relacja SkladnikOdzywczy
        public int SkladnikOdzywczyID { get; set; }
        public virtual SkladnikOdzywczy SkladnikOdzywczy { get; set; }
    }
}