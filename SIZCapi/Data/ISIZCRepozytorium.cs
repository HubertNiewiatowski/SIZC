using System.Collections.Generic;
using System.Threading.Tasks;
using SIZCapi.Models;

namespace SIZCapi.Data
{
    public interface ISIZCRepozytorium
    {
        void DodajZasob<T>(T encja) where T : class;

        void UsunZasob<T>(T encja) where T : class;

        Task<bool> ZapiszZasob();

        Task<IEnumerable<PozycjaMenu>> PobierzPozycjeMenuWszystkie();

        Task<PozycjaMenu> PobierzPozycjeMenuPoId(int id);

        Task<IEnumerable<Zamowienie>> PobierzZamowieniaWszystkie();

        Task<Zamowienie> PobierzZamowieniePoId(int id);

        Task<IEnumerable<Zamowienie>> PobierzZamowieniaKlienta(int id);

        Task<IEnumerable<Zamowienie>> PobierzZamowieniaPracownika(int id);

        Task<IEnumerable<Klient>> PobierzProfileKlientowWszystkie();

        Task<Klient> PobierzProfilKlienta(int id);

        Task<IEnumerable<Pracownik>> PobierzProfilePracownikowWszystkie();

        Task<Pracownik> PobierzProfilPracownika(int id);

    }
}