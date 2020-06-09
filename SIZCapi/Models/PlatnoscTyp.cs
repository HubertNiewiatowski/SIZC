using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class PlatnoscTyp
    {
        public int PlatnoscTypID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NazwaPlatnosc { get; set; }

        // relacja Zamowienie
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}