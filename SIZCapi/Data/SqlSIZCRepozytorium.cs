using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIZCapi.Models;

namespace SIZCapi.Data
{
    public class SqlSIZCRepozytorium : ISIZCRepozytorium
    {
        private readonly SIZCKontekst _kontekst;

        public SqlSIZCRepozytorium(SIZCKontekst kontekst)
        {
            _kontekst = kontekst;
        }

        public void DodajZasob<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _kontekst.Add(entity);
        }

        public async Task<PozycjaMenu> PobierzPozycjeMenuPoId(int id)
        {
            var pozycjaMenu = await _kontekst.PozycjaMenu.FirstOrDefaultAsync(e => e.PozycjaMenuID == id);

            return pozycjaMenu;
        }

        public async Task<IEnumerable<PozycjaMenu>> PobierzPozycjeMenuWszystkie()
        {
            var pozycjeMenu = await _kontekst.PozycjaMenu.ToListAsync();

            return pozycjeMenu;
        }

        public void UsunZasob<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _kontekst.Remove(entity);
        }

        public async Task<bool> ZapiszZasob()
        {
            return await _kontekst.SaveChangesAsync() > 0;
        }
    }
}