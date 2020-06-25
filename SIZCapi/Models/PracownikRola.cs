using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class PracownikRola
    {
        // klucz główny
        public int PracownikRolaID { get; set; } // akcesory get set

        // adnotacja danych
        [Column(TypeName = "nvarchar(50)")]
        public string NazwaRola { get; set; }

        // relacja Pracownik - PracownikRola
        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}


