using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIZCapi.Models;

namespace SIZCapi.Data
{
    public class AutoryzacjaKlient : IAutoryzacjaKlient
    {
        private readonly SIZCKontekst _kontekst;

        public AutoryzacjaKlient(SIZCKontekst kontekst)
        {
            _kontekst = kontekst;
        }

        public async Task<bool> CzyEmailIstnieje(string email)
        {
            if (await _kontekst.Klient.AnyAsync(e => e.AdresEmail == email))
            {
                return true;
            }

            return false;
        }

        public async Task<Klient> Zaloguj(string email, string haslo)
        {
            var klient = await _kontekst.Klient.FirstOrDefaultAsync(e => e.AdresEmail == email);

            if (klient == null)
            {
                return null;
            }

            if (!PorowanajZaszyfrowaneHasla(haslo, klient.HasloHash, klient.HasloSalt))
            {
                return null;
            }

            return klient;
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

        public async Task<Klient> Zarejestruj(Klient klient, string haslo)
        {
            byte[] hasloHash;
            byte[] hasloSalt;

            HaszujHaslo(haslo, out hasloHash, out hasloSalt);

            klient.HasloHash = hasloHash;
            klient.HasloSalt = hasloSalt;

            await _kontekst.Klient.AddAsync(klient);
            await _kontekst.SaveChangesAsync();

            return klient;
        }

        private void HaszujHaslo(string haslo, out byte[] hasloHash, out byte[] hasloSalt)
        {
            using (var kodUwierzytelniania = new System.Security.Cryptography.HMACSHA512())
            {
                hasloSalt = kodUwierzytelniania.Key;

                hasloHash = kodUwierzytelniania.ComputeHash(System.Text.Encoding.Unicode.GetBytes(haslo));

            }    
        }
    }
}