using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DodajZasob<T>(T encja) where T : class
        {
            if (encja == null)
            {
                throw new ArgumentNullException(nameof(encja));
            }

            _kontekst.Add(encja);
        }

        public async Task<PozycjaMenu> PobierzPozycjeMenuPoId(int id)
        {
            var pozycjaMenu = await _kontekst.PozycjaMenu.Include(e => e.Skladnik).FirstOrDefaultAsync(e => e.PozycjaMenuID == id);

            return pozycjaMenu;
        }

        public async Task<IEnumerable<PozycjaMenu>> PobierzPozycjeMenuWszystkie()
        {
            var pozycjeMenu = await _kontekst.PozycjaMenu.Include(e => e.Skladnik).ToListAsync();

            return pozycjeMenu;
        }

        public async Task<Klient> PobierzProfilKlienta(int id)
        {
            var profilKlienta = await _kontekst.Klient.FirstOrDefaultAsync(e => e.KlientID == id);

            return profilKlienta;
        }

        public async Task<IEnumerable<Zamowienie>> PobierzZamowieniaKlienta(int id)
        {
            var zamowienia = await _kontekst.Zamowienie.Include(e => e.PozycjaMenu).Include(e => e.PlatnoscTyp).Include(e => e.ZamowienieStatus).Where(e => e.KlientID == id).ToListAsync();

            return zamowienia;
        }

        public async Task<IEnumerable<Zamowienie>> PobierzZamowieniaWszystkie()
        {
            var zamowienia = await _kontekst.Zamowienie.ToListAsync();

            return zamowienia;
        }

        public void UsunZasob<T>(T encja) where T : class
        {
            if (encja == null)
            {
                throw new ArgumentNullException(nameof(encja));
            }

            _kontekst.Remove(encja);
        }

        public async Task<bool> ZapiszZasob()
        {
            return await _kontekst.SaveChangesAsync() > 0;
        }

    }
}