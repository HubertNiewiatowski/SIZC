using System;
using Microsoft.EntityFrameworkCore;
using SIZCapi.Models;

namespace SIZCapi.Data
{
    public static class ModelBuilderExtensions
    {

        private static void HaszujHaslo(string haslo, out byte[] hasloHash, out byte[] hasloSalt)
        {
            using (var kodUwierzytelniania = new System.Security.Cryptography.HMACSHA512())
            {
                hasloSalt = kodUwierzytelniania.Key;

                hasloHash = kodUwierzytelniania.ComputeHash(System.Text.Encoding.Unicode.GetBytes(haslo));

            }    
        }
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            byte[] hasloHash;
            byte[] hasloSalt;



            modelBuilder.Entity<ZamowienieStatus>().HasData(
                new ZamowienieStatus
                {
                    ZamowienieStatusID = 1,
                    NazwaStatus = "zamówione"
                },
                new ZamowienieStatus
                {
                    ZamowienieStatusID = 2,
                    NazwaStatus = "w trakcie przygotowywania"
                },
                new ZamowienieStatus
                {
                    ZamowienieStatusID = 3,
                    NazwaStatus = "przygotowane"
                },
                new ZamowienieStatus
                {
                    ZamowienieStatusID = 4,
                    NazwaStatus = "w trakcie dostawy"
                },
                new ZamowienieStatus
                {
                    ZamowienieStatusID = 5,
                    NazwaStatus = "dostarczone"
                }
            );

            modelBuilder.Entity<PracownikRola>().HasData(
                new PracownikRola
                {
                    PracownikRolaID = 1,
                    NazwaRola = "kucharz"
                },
                new PracownikRola
                {
                    PracownikRolaID = 2,
                    NazwaRola = "dostawca"
                },
                new PracownikRola
                {
                    PracownikRolaID = 3,
                    NazwaRola = "administrator"
                }
            );

            modelBuilder.Entity<Alergen>().HasData(
                new Alergen
                {
                    AlergenID = 1,
                    NazwaAlergen = "brak alergenu"
                },
                new Alergen
                {
                    AlergenID = 2,
                    NazwaAlergen = "jajka"
                },
                new Alergen
                {
                    AlergenID = 3,
                    NazwaAlergen = "mleko"
                },
                new Alergen
                {
                    AlergenID = 4,
                    NazwaAlergen = "orzechy"
                }
            );

            modelBuilder.Entity<SkladnikOdzywczy>().HasData(
                new SkladnikOdzywczy
                {
                    SkladnikOdzywczyID = 1,
                    NazwaSkladnik = "białko",
                    Kalorycznosc = 4
                },
                new SkladnikOdzywczy
                {
                    SkladnikOdzywczyID = 2,
                    NazwaSkladnik = "tłuszcz",
                    Kalorycznosc = 9
                },
                new SkladnikOdzywczy
                {
                    SkladnikOdzywczyID = 3,
                    NazwaSkladnik = "węglowodany",
                    Kalorycznosc = 4
                }
            );

            modelBuilder.Entity<PlatnoscTyp>().HasData(
                new PlatnoscTyp
                {
                    PlatnoscTypID = 1,
                    NazwaPlatnosc = "gotówka"
                },
                new PlatnoscTyp
                {
                    PlatnoscTypID = 2,
                    NazwaPlatnosc = "blik"
                },
                new PlatnoscTyp
                {
                    PlatnoscTypID = 3,
                    NazwaPlatnosc = "przelew"
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Klient>().HasData(
                new Klient
                {
                    KlientID = 1,
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    AdresEmail = "hubertniewiatowski@outlook.com",
                    NrTelStacjonarny = "221234567",
                    NrTelKomorkowy = "123456789",
                    KodPocztowy = "01234",
                    Miejscowosc = "Warszawa",
                    Ulica = "Długa",
                    NrBudynek = "1",
                    NrMieszkanie = "2",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    DataRejestracji = new DateTime(2020, 6, 1, 11, 47, 3)
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Klient>().HasData(
                new Klient
                {
                    KlientID = 2,
                    Imie = "Elżbieta",
                    Nazwisko = "Zalewska",
                    AdresEmail = "hubertniewiatowski@outlook.com",
                    NrTelStacjonarny = "-",
                    NrTelKomorkowy = "987654321",
                    KodPocztowy = "43210",
                    Miejscowosc = "Kraków",
                    Ulica = "Krótka",
                    NrBudynek = "17a",
                    NrMieszkanie = "-",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    DataRejestracji = new DateTime(2020, 6, 3, 14, 58, 12)
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Klient>().HasData(            
                new Klient
                {
                    KlientID = 3,
                    Imie = "Marcin",
                    Nazwisko = "Nowak",
                    AdresEmail = "hubertniewiatowski@outlook.com",
                    NrTelStacjonarny = "221112233",
                    NrTelKomorkowy = "-",
                    KodPocztowy = "11222",
                    Miejscowosc = "Gdańsk",
                    Ulica = "Szeroka",
                    NrBudynek = "12",
                    NrMieszkanie = "2",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    DataRejestracji = new DateTime(2020, 6, 7, 23, 7, 21)
                }
            );

            modelBuilder.Entity<PozycjaMenu>().HasData(
                new PozycjaMenu
                {
                    PozycjaMenuID = 1,
                    NazwaPozycja = "Dieta Vege",
                    Cena = 26.50m,
                    Opis = "Pozycja dla wegetarian, bogata w produkty roślinne",
                    ObrazekUrl = "https://i.ibb.co/ChJDspJ/dieta-Vege.png"
                },
                new PozycjaMenu
                {
                    PozycjaMenuID = 2,
                    NazwaPozycja = "Dieta Light",
                    Cena = 25.50m,
                    Opis = "Pozycja dla osób odchudzjących się, bogata w błonnik",
                    ObrazekUrl = "https://i.ibb.co/kgPxXXX/dieta-Light.png"
                },
                new PozycjaMenu
                {
                    PozycjaMenuID = 3,
                    NazwaPozycja = "Dieta Sport",
                    Cena = 27.50m,
                    Opis = "Pozycja dla osób trenujących, bogata w białko",
                    ObrazekUrl = "https://i.ibb.co/CBTgwTZ/dieta-Sport.png"
                }
            );

            modelBuilder.Entity<Skladnik>().HasData(
                new Skladnik
                {
                    SkladnikID = 1,
                    NazwaSkladnik = "awokado",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 42,
                    PozycjaMenuID = 1
                },
                new Skladnik
                {
                    SkladnikID = 2,
                    NazwaSkladnik = "marchew",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 45,
                    PozycjaMenuID = 1
                },
                new Skladnik
                {
                    SkladnikID = 3,
                    NazwaSkladnik = "soczewica",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 80,
                    PozycjaMenuID = 1
                },
                new Skladnik
                {
                    SkladnikID = 4,
                    NazwaSkladnik = "pomidory",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 200,
                    PozycjaMenuID = 1
                },
                new Skladnik
                {
                    SkladnikID = 5,
                    NazwaSkladnik = "dorsz gotowany",
                    CzyWeganski = false,
                    CzyWegetarianski = false,
                    MasaSkladnik = 142,
                    PozycjaMenuID = 2
                },
                new Skladnik
                {
                    SkladnikID = 6,
                    NazwaSkladnik = "brokuły",
                    CzyWeganski = false,
                    CzyWegetarianski = false,
                    MasaSkladnik = 57,
                    PozycjaMenuID = 2
                },
                new Skladnik
                {
                    SkladnikID = 7,
                    NazwaSkladnik = "dziki ryż",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 68,
                    PozycjaMenuID = 2
                },
                new Skladnik
                {
                    SkladnikID = 8,
                    NazwaSkladnik = "kurczak",
                    CzyWeganski = false,
                    CzyWegetarianski = false,
                    MasaSkladnik = 143,
                    PozycjaMenuID = 3
                },
                new Skladnik
                {
                    SkladnikID = 9,
                    NazwaSkladnik = "ziemniaki",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 153,
                    PozycjaMenuID = 3
                },
                new Skladnik
                {
                    SkladnikID = 10,
                    NazwaSkladnik = "sałata",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 63,
                    PozycjaMenuID = 3
                }
            );

            modelBuilder.Entity<InformacjaAlergen>().HasData(
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 1,
                    SkladnikID = 1,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 2,
                    SkladnikID = 2,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 3,
                    SkladnikID = 3,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 4,
                    SkladnikID = 4,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 5,
                    SkladnikID = 5,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 6,
                    SkladnikID = 6,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 7,
                    SkladnikID = 7,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 8,
                    SkladnikID = 8,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 9,
                    SkladnikID = 9,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    InformacjaAlergenID = 10,
                    SkladnikID = 10,
                    AlergenID = 1
                }            
            );

            modelBuilder.Entity<WartoscOdzywcza>().HasData(
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 1,
                    ZawartoscSkladnikOdzywczy = 15,
                    SkladnikID = 1,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 2,
                    ZawartoscSkladnikOdzywczy = 9,
                    SkladnikID = 1,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 3,
                    ZawartoscSkladnikOdzywczy = 4,
                    SkladnikID = 1,
                    SkladnikOdzywczyID = 1
                },


                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 4,
                    ZawartoscSkladnikOdzywczy = 0.2f,
                    SkladnikID = 2,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 5,
                    ZawartoscSkladnikOdzywczy = 10,
                    SkladnikID = 2,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 6,
                    ZawartoscSkladnikOdzywczy = 0.9f,
                    SkladnikID = 2,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 7,
                    ZawartoscSkladnikOdzywczy = 0.4f,
                    SkladnikID = 3,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 8,
                    ZawartoscSkladnikOdzywczy = 20,
                    SkladnikID = 3,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 9,
                    ZawartoscSkladnikOdzywczy = 9,
                    SkladnikID = 3,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 10,
                    ZawartoscSkladnikOdzywczy = 0.2f,
                    SkladnikID = 4,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 11,
                    ZawartoscSkladnikOdzywczy = 3.9f,
                    SkladnikID = 4,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 12,
                    ZawartoscSkladnikOdzywczy = 0.9f,
                    SkladnikID = 4,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 13,
                    ZawartoscSkladnikOdzywczy = 0.67f,
                    SkladnikID = 5,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 14,
                    ZawartoscSkladnikOdzywczy = 0,
                    SkladnikID = 5,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 15,
                    ZawartoscSkladnikOdzywczy = 17.8f,
                    SkladnikID = 5,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 16,
                    ZawartoscSkladnikOdzywczy = 0.4f,
                    SkladnikID = 6,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 17,
                    ZawartoscSkladnikOdzywczy = 7,
                    SkladnikID = 6,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 18,
                    ZawartoscSkladnikOdzywczy = 2.8f,
                    SkladnikID = 6,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 19,
                    ZawartoscSkladnikOdzywczy = 1.1f,
                    SkladnikID = 7,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 20,
                    ZawartoscSkladnikOdzywczy = 75,
                    SkladnikID = 7,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 21,
                    ZawartoscSkladnikOdzywczy = 15,
                    SkladnikID = 7,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 22,
                    ZawartoscSkladnikOdzywczy = 14,
                    SkladnikID = 8,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 23,
                    ZawartoscSkladnikOdzywczy = 0,
                    SkladnikID = 8,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 24,
                    ZawartoscSkladnikOdzywczy = 27,
                    SkladnikID = 8,
                    SkladnikOdzywczyID = 1
                },
                
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 25,
                    ZawartoscSkladnikOdzywczy = 0.1f,
                    SkladnikID = 9,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 26,
                    ZawartoscSkladnikOdzywczy = 16.3f,
                    SkladnikID = 9,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 27,
                    ZawartoscSkladnikOdzywczy = 1.8f,
                    SkladnikID = 9,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 28,
                    ZawartoscSkladnikOdzywczy = 0.2f,
                    SkladnikID = 10,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 29,
                    ZawartoscSkladnikOdzywczy = 2.9f,
                    SkladnikID = 10,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    WartoscOdzywczaID = 30,
                    ZawartoscSkladnikOdzywczy = 1.4f,
                    SkladnikID = 10,
                    SkladnikOdzywczyID = 1
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik
                {
                    PracownikID = 1,
                    Login = "kucharz1",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    PracownikRolaID = 1
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik
                {
                    PracownikID = 2,
                    Login = "dostawca1",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    PracownikRolaID = 2
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik
                {
                    PracownikID = 3,
                    Login = "administrator1",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    PracownikRolaID = 3
                }
            );

            modelBuilder.Entity<Zamowienie>().HasData(
                new Zamowienie
                {
                    ZamowienieID = 1,
                    Koszt = 31.5m,
                    KodPocztowy = "01234",
                    Miejscowosc = "Warszawa",
                    Ulica = "Długa",
                    NrBudynek = "1",
                    NrMieszkanie = "2",
                    DataRealizacji = new DateTime(2020, 6, 3, 15, 00, 0),
                    DataZlozenia = new DateTime(2020, 6, 2, 13, 57, 32),
                    PozycjaMenuID = 1,
                    KlientID = 1,
                    PracownikID = 1,
                    PlatnoscTypID = 1,
                    ZamowienieStatusID = 1
                },                
                new Zamowienie
                {
                    ZamowienieID = 2,
                    Koszt = 30.5m,
                    KodPocztowy = "43210",
                    Miejscowosc = "Wrocław",
                    Ulica = "Miła",
                    NrBudynek = "14c",
                    NrMieszkanie = "-",
                    DataRealizacji = new DateTime(2020, 6, 5, 9, 00, 0),
                    DataZlozenia = new DateTime(2020, 6, 4, 17, 47, 42),
                    PozycjaMenuID = 2,
                    KlientID = 2,
                    PracownikID = 1,
                    PlatnoscTypID = 2,
                    ZamowienieStatusID = 3
                },
                new Zamowienie
                {
                    ZamowienieID = 3,
                    Koszt = 36.5m,
                    KodPocztowy = "11222",
                    Miejscowosc = "Gdańsk",
                    Ulica = "Szeroka",
                    NrBudynek = "12",
                    NrMieszkanie = "2",
                    DataRealizacji = new DateTime(2020, 6, 9, 18, 00, 0),
                    DataZlozenia = new DateTime(2020, 6, 8, 9, 7, 5),
                    PozycjaMenuID = 3,
                    KlientID = 3,
                    PracownikID = 1,
                    PlatnoscTypID = 3,
                    ZamowienieStatusID = 5
                }
            );
        }        
    }
}