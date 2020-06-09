using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class PracownikRola
    {
        public int PracownikRolaID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NazwaRola { get; set; }

        // relacja Pracownik
        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}