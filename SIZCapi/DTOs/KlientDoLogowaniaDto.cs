using System.ComponentModel.DataAnnotations;

namespace SIZCapi.DTOs
{
    public class KlientDoLogowaniaDto
    {
        [EmailAddress]
        public string AdresEmail { get; set; }
        
        public string Haslo { get; set; }
    }
}