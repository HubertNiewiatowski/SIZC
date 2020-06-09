using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class Pracownik
    {
        public int PracownikID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Login { get; set; }

        public byte[] HasloHash { get; set; }

        public byte[] HasloSalt { get; set; }

        // relacja Zamowienie
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }

        // relacja PracownikRola
        public int PracownikRolaID { get; set; }
        public virtual PracownikRola PracownikRola { get; set; }
    }
}