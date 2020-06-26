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

        public async Task<IEnumerable<PozycjaMenu>> PobierzPozycjeMenuWszystkie()
        {
            var pozycjeMenu = await _kontekst.PozycjaMenu.Include(e => e.Skladnik).ToListAsync();

            return pozycjeMenu;
        }

        public async Task<PozycjaMenu> PobierzPozycjeMenuPoId(int id)
        {
            var pozycjaMenu = await _kontekst.PozycjaMenu.Include(e => e.Skladnik).FirstOrDefaultAsync(e => e.PozycjaMenuID == id);

            return pozycjaMenu;
        }

        public async Task<int> ZliczZamowieniaDoRaportu(DateTime dataPoczatkowa, DateTime dataKoncowa)
        {
            var zamowienia = await _kontekst.Zamowienie.Where(e => e.DataZlozenia >= dataPoczatkowa && e.DataZlozenia <= dataKoncowa).ToListAsync();

            int iloscZamowien = zamowienia.Count();
            
            return iloscZamowien;
        }

        public async Task<Zamowienie> PobierzZamowieniePoId(int id)
        {
            var zamowienie = await _kontekst.Zamowienie.Include(e => e.PozycjaMenu).Include(e => e.PlatnoscTyp).Include(e => e.ZamowienieStatus).FirstOrDefaultAsync(e => e.ZamowienieID == id);

            return zamowienie;
        }

        public async Task<IEnumerable<Zamowienie>> PobierzZamowieniaKlienta(int id)
        {
            var zamowienia = await _kontekst.Zamowienie.Include(e => e.PozycjaMenu).Include(e => e.PlatnoscTyp).Include(e => e.ZamowienieStatus).Where(e => e.KlientID == id).ToListAsync();

            return zamowienia;
        }

        public async Task<IEnumerable<Zamowienie>> PobierzZamowieniaPracownika(int id)
        {
            var zamowienia = await _kontekst.Zamowienie.Include(e => e.PozycjaMenu).Include(e => e.PlatnoscTyp).Include(e => e.ZamowienieStatus).Where(e => e.PracownikID == id).ToListAsync();

            return zamowienia;
        }

        public async Task<IEnumerable<PlatnoscTyp>> PobierzTypyPlatnosci()
        {
            var typyPlatnosci = await _kontekst.PlatnoscTyp.ToListAsync();

            return typyPlatnosci;
        }

        public async Task<IEnumerable<ZamowienieStatus>> PobierzStatusyZamowien()
        {
            var statusyZamowinen = await _kontekst.ZamowienieStatus.ToListAsync();

            return statusyZamowinen;
        }


        public async Task<int> ZliczProfileKlientowDoRaportu(DateTime dataPoczatkowa, DateTime dataKoncowa)
        {
            var profileKlientow = await _kontekst.Klient.Where(e => e.DataRejestracji >= dataPoczatkowa && e.DataRejestracji <= dataKoncowa).ToListAsync();

            int iloscKlientow = profileKlientow.Count();
            
            return iloscKlientow;
        }

        public async Task<Klient> PobierzProfilKlienta(int id)
        {
            var profilKlienta = await _kontekst.Klient.FirstOrDefaultAsync(e => e.KlientID == id);

            return profilKlienta;
        }

        public async Task<IEnumerable<Pracownik>> PobierzProfilePracownikowWszystkie()
        {
            var profilePracownikow = await _kontekst.Pracownik.ToListAsync();

            return profilePracownikow;
        }

        public async Task<Pracownik> PobierzProfilPracownika(int id)
        {
            var profilPracownika = await _kontekst.Pracownik.FirstOrDefaultAsync(e => e.PracownikID == id);

            return profilPracownika;
        }

        public async Task<string> PobierzAdresEmailKlienta(int id)
        {
            var adresEmail = await _kontekst.Klient.Where(e => e.KlientID == id).Select( e => e.AdresEmail).FirstOrDefaultAsync();

            return adresEmail;
        }
    }
}