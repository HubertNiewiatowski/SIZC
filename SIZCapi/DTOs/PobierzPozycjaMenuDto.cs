using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SIZCapi.Models;

namespace SIZCapi.DTOs
{
    public class PobierzPozycjaMenuDto
    {
        [Required]
        public int PozycjaMenuID { get; set; }
        
        public string NazwaPozycja { get; set; } 
        
        public decimal Cena { get; set; }
        
        public string Opis { get; set; }
        
        public string ObrazekUrl { get; set; }

        public virtual ICollection<DlaPozycjaMenuSkladnikDto> Skladnik { get; set; }
    }
}