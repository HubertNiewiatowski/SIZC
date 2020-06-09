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
                    NazwaStatus="zamówione"
                },
                new ZamowienieStatus
                {
                    NazwaStatus="w trakcie przygotowywania"
                },
                new ZamowienieStatus
                {
                    NazwaStatus="przygotowane"
                },
                new ZamowienieStatus
                {
                    NazwaStatus="w trakcie dostawy"
                },
                new ZamowienieStatus
                {
                    NazwaStatus="dostarczone"
                }
            );

            modelBuilder.Entity<PracownikRola>().HasData(
                new PracownikRola
                {
                    NazwaRola="kucharz"
                },
                new PracownikRola
                {
                    NazwaRola="dostawca"
                },
                new PracownikRola
                {
                    NazwaRola="administrator"
                }
            );

            modelBuilder.Entity<Alergen>().HasData(
                new Alergen
                {
                    NazwaAlergen="brak alergenu"
                },
                new Alergen
                {
                    NazwaAlergen="jajka"
                },
                new Alergen
                {
                    NazwaAlergen="mleko"
                },
                new Alergen
                {
                    NazwaAlergen="orzechy"
                }
            );

            modelBuilder.Entity<SkladnikOdzywczy>().HasData(
                new SkladnikOdzywczy
                {
                    NazwaSkladnik="białko",
                    Kalorycznosc=4
                },
                new SkladnikOdzywczy
                {
                    NazwaSkladnik="tłuszcz",
                    Kalorycznosc=9
                },
                new SkladnikOdzywczy
                {
                    NazwaSkladnik="węglowodany",
                    Kalorycznosc=4
                }
            );

            modelBuilder.Entity<PlatnoscTyp>().HasData(
                new PlatnoscTyp
                {
                    NazwaPlatnosc="gotówka"
                },
                new PlatnoscTyp
                {
                    NazwaPlatnosc="blik"
                },
                new PlatnoscTyp
                {
                    NazwaPlatnosc="przelew"
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Klient>().HasData(
                new Klient
                {
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    AdresEmail = "jan.kowalski@wp.pl",
                    NrTelStacjonarny = "221234567",
                    NrTelKomorkowy = "123456789",
                    KodPocztowy = "01234",
                    Miejscowosc = "Warszawa",
                    Ulica = "Długa",
                    NrBudynek = "1",
                    NrMieszkanie = "2",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    DataRejestracji = new DateTime(2020, 6, 1, 7, 47, 0)
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Klient>().HasData(
                new Klient
                {
                    Imie = "Elżbieta",
                    Nazwisko = "Zalewska",
                    AdresEmail = "elzbieta.zalewska@gmail.com",
                    NrTelStacjonarny = "-",
                    NrTelKomorkowy = "987654321",
                    KodPocztowy = "43210",
                    Miejscowosc = "Kraków",
                    Ulica = "Krótka",
                    NrBudynek = "17a",
                    NrMieszkanie = "-",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    DataRejestracji = new DateTime(2020, 6, 2, 14, 37, 12)
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Klient>().HasData(            
                new Klient
                {
                    Imie = "Marcin",
                    Nazwisko = "Nowak",
                    AdresEmail = "marcin.nowak@onet.pl",
                    NrTelStacjonarny = "221112233",
                    NrTelKomorkowy = "-",
                    KodPocztowy = "11222",
                    Miejscowosc = "Gdańsk",
                    Ulica = "Szeroka",
                    NrBudynek = "12",
                    NrMieszkanie = "2",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    DataRejestracji = new DateTime(2020, 6, 4, 23, 7, 21)
                }
            );

            modelBuilder.Entity<PozycjaMenu>().HasData(
                new PozycjaMenu
                {
                    NazwaPozycja = "Dieta Vege",
                    Cena = 26.50m,
                    Opis = "Pozycja dla wegetarian, bogata w produkty roślinne",
                    ObrazekUrl = "https://i.ibb.co/ChJDspJ/dieta-Vege.png"
                },
                new PozycjaMenu
                {
                    NazwaPozycja = "Dieta Light",
                    Cena = 25.50m,
                    Opis = "Pozycja dla osób odchudzjących się, bogata w błonnik",
                    ObrazekUrl = "https://i.ibb.co/kgPxXXX/dieta-Light.png"
                },
                new PozycjaMenu
                {
                    NazwaPozycja = "Dieta Sport",
                    Cena = 27.50m,
                    Opis = "Pozycja dla osób trenujących, bogata w białko",
                    ObrazekUrl = "https://i.ibb.co/CBTgwTZ/dieta-Sport.png"
                }
            );

            modelBuilder.Entity<Skladnik>().HasData(
                new Skladnik
                {
                    NazwaSkladnik = "awokado",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 42,
                    PozycjaMenuID = 1
                },
                new Skladnik
                {
                    NazwaSkladnik = "marchew",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 45,
                    PozycjaMenuID = 1
                },
                new Skladnik
                {
                    NazwaSkladnik = "soczewica",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 80,
                    PozycjaMenuID = 1
                },
                new Skladnik
                {
                    NazwaSkladnik = "pomidory",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 200,
                    PozycjaMenuID = 1
                },
                new Skladnik
                {
                    NazwaSkladnik = "dorsz gotowany",
                    CzyWeganski = false,
                    CzyWegetarianski = false,
                    MasaSkladnik = 142,
                    PozycjaMenuID = 2
                },
                new Skladnik
                {
                    NazwaSkladnik = "brokuły",
                    CzyWeganski = false,
                    CzyWegetarianski = false,
                    MasaSkladnik = 57,
                    PozycjaMenuID = 2
                },
                new Skladnik
                {
                    NazwaSkladnik = "dziki ryż",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 68,
                    PozycjaMenuID = 2
                },
                new Skladnik
                {
                    NazwaSkladnik = "kurczak",
                    CzyWeganski = false,
                    CzyWegetarianski = false,
                    MasaSkladnik = 143,
                    PozycjaMenuID = 3
                },
                new Skladnik
                {
                    NazwaSkladnik = "ziemniaki",
                    CzyWeganski = true,
                    CzyWegetarianski = true,
                    MasaSkladnik = 153,
                    PozycjaMenuID = 3
                },
                new Skladnik
                {
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
                    SkladnikID = 1,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    SkladnikID = 2,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    SkladnikID = 3,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    SkladnikID = 4,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    SkladnikID = 5,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    SkladnikID = 6,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    SkladnikID = 7,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    SkladnikID = 8,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    SkladnikID = 9,
                    AlergenID = 1
                },
                new InformacjaAlergen
                {
                    SkladnikID = 10,
                    AlergenID = 1
                }            
            );

            modelBuilder.Entity<WartoscOdzywcza>().HasData(
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 15,
                    SkladnikID = 1,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 9,
                    SkladnikID = 1,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 4,
                    SkladnikID = 1,
                    SkladnikOdzywczyID = 1
                },


                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0.2f,
                    SkladnikID = 2,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 10,
                    SkladnikID = 2,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0.9f,
                    SkladnikID = 2,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0.4f,
                    SkladnikID = 3,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 20,
                    SkladnikID = 3,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 9,
                    SkladnikID = 3,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0.2f,
                    SkladnikID = 4,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 3.9f,
                    SkladnikID = 4,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0.9f,
                    SkladnikID = 4,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0.67f,
                    SkladnikID = 5,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0,
                    SkladnikID = 5,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 17.8f,
                    SkladnikID = 5,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0.4f,
                    SkladnikID = 6,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 7,
                    SkladnikID = 6,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 2.8f,
                    SkladnikID = 6,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 1.1f,
                    SkladnikID = 7,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 75,
                    SkladnikID = 7,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 15,
                    SkladnikID = 7,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 14,
                    SkladnikID = 8,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0,
                    SkladnikID = 8,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 27,
                    SkladnikID = 8,
                    SkladnikOdzywczyID = 1
                },
                
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0.1f,
                    SkladnikID = 9,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 16.3f,
                    SkladnikID = 9,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 1.8f,
                    SkladnikID = 9,
                    SkladnikOdzywczyID = 1
                },

                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 0.2f,
                    SkladnikID = 10,
                    SkladnikOdzywczyID = 2
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 2.9f,
                    SkladnikID = 10,
                    SkladnikOdzywczyID = 3
                },
                new WartoscOdzywcza
                {
                    ZawartoscSkladnikOdzywczy = 1.4f,
                    SkladnikID = 10,
                    SkladnikOdzywczyID = 1
                }
            );

            HaszujHaslo("password", out hasloHash, out hasloSalt);

            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik
                {
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
                    Login = "administartor1",
                    HasloHash = hasloHash,
                    HasloSalt = hasloSalt,
                    PracownikRolaID = 3
                }
            );

            modelBuilder.Entity<Zamowienie>().HasData(
                new Zamowienie
                {
                    Koszt = 31.5m,
                    KodPocztowy = "01234",
                    Miejscowosc = "Warszawa",
                    Ulica = "Długa",
                    NrBudynek = "1",
                    NrMieszkanie = "2",
                    DataRealizacji = new DateTime(2020, 6, 3, 15, 00, 0),
                    DataZlozenia = new DateTime(2020, 6, 2, 9, 47, 0),
                    PozycjaMenuID = 1,
                    KlientID = 1,
                    PracownikID = 1,
                    PlatnoscTypID = 1,
                    ZamowienieStatusID = 1
                },                
                new Zamowienie
                {
                    Koszt = 30.5m,
                    KodPocztowy = "43210",
                    Miejscowosc = "Wrocław",
                    Ulica = "Miła",
                    NrBudynek = "14c",
                    NrMieszkanie = "-",
                    DataRealizacji = new DateTime(2020, 6, 6, 9, 00, 0),
                    DataZlozenia = new DateTime(2020, 6, 5, 9, 47, 0),
                    PozycjaMenuID = 2,
                    KlientID = 2,
                    PracownikID = 1,
                    PlatnoscTypID = 2,
                    ZamowienieStatusID = 3
                },
                new Zamowienie
                {
                    Koszt = 36.5m,
                    KodPocztowy = "11222",
                    Miejscowosc = "Gdańsk",
                    Ulica = "Szeroka",
                    NrBudynek = "12",
                    NrMieszkanie = "2",
                    DataRealizacji = new DateTime(2020, 6, 4, 18, 00, 0),
                    DataZlozenia = new DateTime(2020, 6, 3, 9, 7, 5),
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