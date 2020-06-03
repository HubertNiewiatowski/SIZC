using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class WartoscOdzywcza
    {
        public int WartoscOdzywczaID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NazwaWartoscOdzywcza { get; set; }

        public float Kalorycznosc { get; set; }

        //relacja Skladnik
        public virtual ICollection<Skladnik> Skladnik { get; set; }
    }
}