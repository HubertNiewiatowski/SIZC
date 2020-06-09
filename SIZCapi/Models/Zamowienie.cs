using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class Zamowienie
    {
        public int ZamowienieID { get; set; }
        
        [Column(TypeName = "money")]
        public decimal Koszt { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string KodPocztowy { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string Miejscowosc { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Ulica { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string NrBudynek { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string NrMieszkanie { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataRealizacji { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataZlozenia { get; set; }

        // relacja PozycjaMenu
        public int PozycjaMenuID { get; set; }
        public virtual PozycjaMenu PozycjaMenu { get; set; }
        
        // relacja Klient
        public int KlientID { get; set; }
        public virtual Klient Klient { get; set; }

        // relacja Pracownik
        public int PracownikID { get; set; }
        public virtual Pracownik Pracownik { get; set; }

        // relacja PlatnoscTyp
        public int PlatnoscTypID { get; set; }
        public virtual PlatnoscTyp PlatnoscTyp { get; set; }

        // relacja ZamowienieStatus
        public int ZamowienieStatusID { get; set; }
        public virtual ZamowienieStatus ZamowienieStatus { get; set; }
    }
}