using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class SkladnikOdzywczy
    {
        public int SkladnikOdzywczyID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NazwaSkladnik { get; set; }

        public float Kalorycznosc { get; set; }

        // relacja WartoscOdzywcza
        public virtual ICollection<WartoscOdzywcza> WartoscOdzywcza { get; set; }
    }
}