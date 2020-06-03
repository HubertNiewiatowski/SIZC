using System.Collections.Generic;
using System.Threading.Tasks;
using SIZCapi.Models;

namespace SIZCapi.Data
{
    public interface ISIZCRepozytorium
    {
        void DodajZasob<T>(T entity) where T : class;
        void UsunZasob<T>(T entity) where T : class;
        Task<bool> ZapiszZasob();
        Task<PozycjaMenu> PobierzPozycjeMenuPoId(int id);
        Task<IEnumerable<PozycjaMenu>> PobierzPozycjeMenuWszystkie();
    }
}