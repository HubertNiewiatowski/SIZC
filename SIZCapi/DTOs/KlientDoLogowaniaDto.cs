namespace SIZCapi.DTOs
{
    public class KlientDoLogowaniaDto
    {
        public string AdresEmail { get; set; }
        public byte[] HasloHash { get; set; }        
        public byte[] HasloSalt { get; set; }
    }
}