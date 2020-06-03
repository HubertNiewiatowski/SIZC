using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIZCapi.Models
{
    public class Klient
    {
        public int KlientID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Imie { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Nazwisko { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string AdresEmail { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NrTelStacjonarny { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NrTelKomorkowy { get; set; }

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

        public byte[] HasloHash { get; set; }
        
        public byte[] HasloSalt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataRejestracji { get; set; }

        //relacja Zamowienie
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}