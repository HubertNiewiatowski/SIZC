using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class Alergen
    {
        public int AlergenID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NazwaAlergen { get; set; }

        //relacja Skladnik
        public virtual ICollection<Skladnik> Skladnik { get; set; }
    }
}