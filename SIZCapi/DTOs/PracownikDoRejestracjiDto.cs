using System.ComponentModel.DataAnnotations;

namespace SIZCapi.DTOs
{
    public class PracownikDoRejestracjiDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Hasło musi zawierać pomiędzy 6 a 50 znaków")]
        public string Haslo { get; set; }

        [Required]
        public int PracownikRolaID { get; set; }        
    }
}