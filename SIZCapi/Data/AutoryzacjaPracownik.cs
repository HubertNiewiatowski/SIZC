using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIZCapi.Models;

namespace SIZCapi.Data
{
    public class AutoryzacjaPracownik : IAutoryzacjaPracownik
    {
        private readonly SIZCKontekst _kontekst;

        public AutoryzacjaPracownik(SIZCKontekst kontekst)
        {
            _kontekst = kontekst;
        }

        public async Task<Pracownik> Zarejestruj(Pracownik pracownik, string haslo)
        {
            byte[] hasloHash;
            byte[] hasloSalt;

            HaszujHaslo(haslo, out hasloHash, out hasloSalt);

            pracownik.HasloHash = hasloHash;
            pracownik.HasloSalt = hasloSalt;

            await _kontekst.Pracownik.AddAsync(pracownik);
            await _kontekst.SaveChangesAsync();

            return pracownik;
        }

        public async Task<Pracownik> Zaloguj(string login, string haslo)
        {
            var pracownik = await _kontekst.Pracownik.FirstOrDefaultAsync(e => e.Login == login);

            if (pracownik == null)
            {
                return null;
            }

            if (!PorowanajZaszyfrowaneHasla(haslo, pracownik.HasloHash, pracownik.HasloSalt))
            {
                return null;
            }

            return pracownik;
        }

        public async Task<bool> CzyLoginIstnieje(string login)
        {
            if (await _kontekst.Pracownik.AnyAsync(e => e.Login == login))
            {
                return true;
            }

            return false;
        }

        private void HaszujHaslo(string haslo, out byte[] hasloHash, out byte[] hasloSalt)
        {
            using (var kodUwierzytelniania = new System.Security.Cryptography.HMACSHA512())
            {
                hasloSalt = kodUwierzytelniania.Key;

                hasloHash = kodUwierzytelniania.ComputeHash(System.Text.Encoding.Unicode.GetBytes(haslo));

            }    
        }

        private bool PorowanajZaszyfrowaneHasla(string haslo, byte[] hasloHash, byte[] hasloSalt)
        {
            using (var kodUwierzytelniania = new System.Security.Cryptography.HMACSHA512(hasloSalt))
            {
                var wygenerowanyHash = kodUwierzytelniania.ComputeHash(System.Text.Encoding.Unicode.GetBytes(haslo));

                for (int i = 0; i < wygenerowanyHash.Length; i++)
                {
                    if (wygenerowanyHash[i] != hasloHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }        
    }
}