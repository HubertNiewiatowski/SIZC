using System.Threading.Tasks;
using SIZCapi.Models;

namespace SIZCapi.Data
{
    public interface IAutoryzacjaKlient
    {
        Task<Klient> Zarejestruj(Klient klient, string haslo);

        Task<Klient> Zaloguj(string email, string haslo);
        
        Task<bool> CzyEmailIstnieje(string email);
    }
}