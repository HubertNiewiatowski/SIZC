using Microsoft.EntityFrameworkCore;
using SIZCapi.Models;

namespace SIZCapi.Data
{
    public class SIZCKontekst : DbContext
    {
        public SIZCKontekst(DbContextOptions<SIZCKontekst> opcje) : base(opcje)
        {
            
        }

        public DbSet<Alergen> Alergen { get; set; }

        public DbSet<InformacjaAlergen> InformacjaAlergen { get; set; }

        public DbSet<Klient> Klient { get; set; }

        public DbSet<PlatnoscTyp> PlatnoscTyp { get; set; }

        public DbSet<PozycjaMenu> PozycjaMenu { get; set; }

        public DbSet<Pracownik> Pracownik { get; set; }

        public DbSet<PracownikRola> PracownikRola { get; set; }

        public DbSet<Skladnik> Skladnik { get; set; }

        public DbSet<SkladnikOdzywczy> SkladnikOdzywczy { get; set; }

        public DbSet<WartoscOdzywcza> WartoscOdzywcza { get; set; }

        public DbSet<Zamowienie> Zamowienie { get; set; }

        public DbSet<ZamowienieStatus> ZamowienieStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}