using System.Threading.Tasks;
using SIZCapi.Models;

namespace SIZCapi.Data
{
    public interface IAutoryzacjaPracownik
    {
        Task<Pracownik> Zarejestruj(Pracownik pracownik, string haslo);
        Task<Pracownik> Zaloguj(string login, string haslo);
        Task<bool> CzyLoginIstnieje(string login);     
    }
}