using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class ZamowienieStatus
    {
        public int ZamowienieStatusID { get; set; }    

        [Column(TypeName = "nvarchar(50)")]
        public string NazwaStatus { get; set; }

        //relacja Zamowienie
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}