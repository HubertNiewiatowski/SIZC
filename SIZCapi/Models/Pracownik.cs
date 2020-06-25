using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class Pracownik
    {
        // klucz główny
        public int PracownikID { get; set; } // akcesory get set

        // adnotacja danych
        [Column(TypeName = "nvarchar(50)")]
        public string Login { get; set; }

        public byte[] HasloHash { get; set; }
        public byte[] HasloSalt { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }

        // relacja Pracownik - PracownikRola
        // klucz obcy
        public int PracownikRolaID { get; set; }
        public virtual PracownikRola PracownikRola { get; set; }
    }
}


