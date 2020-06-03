using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class PozycjaMenu
    {
        public int PozycjaMenuID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NazwaPozycja { get; set; } 

        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        public string Opis { get; set; }

        public string ObrazekUrl { get; set; }

        //relacja Zamowienie
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }

        //relacja Skladnik
        public virtual ICollection<Skladnik> Skladnik { get; set; }
    }
}