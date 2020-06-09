using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIZCapi.Migrations
{
    public partial class SeedingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alergen",
                columns: new[] { "AlergenID", "NazwaAlergen" },
                values: new object[,]
                {
                    { 1, "brak alergenu" },
                    { 2, "jajka" },
                    { 3, "mleko" },
                    { 4, "orzechy" }
                });

            migrationBuilder.InsertData(
                table: "Klient",
                columns: new[] { "KlientID", "AdresEmail", "DataRejestracji", "HasloHash", "HasloSalt", "Imie", "KodPocztowy", "Miejscowosc", "Nazwisko", "NrBudynek", "NrMieszkanie", "NrTelKomorkowy", "NrTelStacjonarny", "Ulica" },
                values: new object[,]
                {
                    { 1, "jan.kowalski@wp.pl", new DateTime(2020, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), new byte[] { 170, 14, 16, 253, 13, 157, 134, 43, 48, 140, 75, 215, 59, 169, 120, 138, 82, 217, 139, 252, 5, 90, 9, 160, 20, 206, 213, 251, 47, 61, 159, 79, 66, 155, 50, 100, 221, 185, 162, 59, 185, 4, 243, 160, 61, 157, 102, 233, 74, 110, 153, 222, 66, 196, 81, 101, 223, 163, 34, 159, 196, 8, 251, 142 }, new byte[] { 57, 147, 159, 78, 240, 174, 91, 78, 175, 87, 138, 32, 26, 0, 227, 176, 42, 174, 114, 205, 185, 168, 23, 40, 50, 251, 174, 40, 129, 38, 239, 213, 18, 121, 125, 204, 154, 199, 177, 11, 172, 198, 182, 165, 104, 105, 123, 42, 204, 36, 40, 177, 131, 167, 192, 169, 14, 205, 44, 24, 133, 59, 52, 51, 200, 234, 110, 97, 247, 197, 41, 183, 247, 109, 186, 54, 120, 225, 140, 147, 60, 61, 131, 107, 51, 143, 242, 131, 196, 183, 235, 200, 247, 53, 180, 244, 248, 108, 162, 89, 238, 238, 232, 2, 27, 212, 222, 229, 25, 136, 221, 33, 131, 30, 7, 11, 143, 43, 91, 94, 106, 85, 91, 106, 236, 152, 244, 82 }, "Jan", "01234", "Warszawa", "Kowalski", "1", "2", "123456789", "221234567", "Długa" },
                    { 2, "elzbieta.zalewska@gmail.com", new DateTime(2020, 6, 2, 14, 37, 12, 0, DateTimeKind.Unspecified), new byte[] { 18, 36, 52, 123, 205, 72, 214, 20, 74, 211, 235, 254, 111, 99, 232, 29, 146, 93, 180, 191, 10, 112, 18, 181, 152, 88, 1, 51, 194, 124, 173, 239, 119, 16, 157, 126, 97, 100, 92, 234, 193, 229, 126, 112, 232, 77, 101, 228, 168, 99, 34, 247, 40, 91, 38, 253, 197, 54, 118, 193, 38, 204, 192, 36 }, new byte[] { 121, 250, 95, 167, 215, 164, 32, 145, 75, 6, 34, 7, 158, 143, 122, 77, 239, 130, 232, 140, 126, 1, 177, 147, 186, 120, 55, 84, 180, 96, 38, 100, 59, 1, 33, 68, 71, 128, 149, 232, 106, 230, 149, 211, 37, 153, 17, 29, 193, 95, 248, 51, 135, 141, 43, 200, 3, 162, 107, 229, 164, 205, 40, 145, 197, 195, 204, 21, 78, 37, 98, 71, 37, 222, 97, 242, 226, 126, 123, 152, 156, 48, 244, 240, 22, 42, 203, 7, 99, 196, 193, 116, 177, 43, 89, 242, 125, 83, 139, 181, 60, 148, 33, 145, 153, 192, 177, 57, 147, 115, 79, 13, 49, 246, 156, 163, 253, 204, 31, 149, 251, 52, 79, 207, 2, 99, 159, 119 }, "Elżbieta", "43210", "Kraków", "Zalewska", "17a", "-", "987654321", "-", "Krótka" },
                    { 3, "marcin.nowak@onet.pl", new DateTime(2020, 6, 4, 23, 7, 21, 0, DateTimeKind.Unspecified), new byte[] { 228, 142, 70, 51, 193, 240, 60, 213, 150, 24, 9, 45, 52, 169, 183, 195, 241, 1, 155, 196, 179, 123, 213, 81, 20, 228, 139, 70, 176, 175, 98, 233, 189, 242, 102, 237, 184, 172, 195, 72, 118, 214, 60, 239, 54, 164, 112, 36, 153, 172, 20, 75, 12, 210, 232, 124, 29, 140, 149, 195, 86, 27, 220, 2 }, new byte[] { 71, 24, 1, 98, 114, 136, 246, 47, 189, 32, 68, 45, 131, 116, 137, 177, 137, 41, 145, 255, 120, 163, 73, 97, 172, 5, 152, 126, 5, 118, 209, 62, 113, 115, 98, 119, 14, 89, 190, 87, 110, 104, 235, 99, 35, 246, 161, 247, 3, 1, 7, 255, 99, 123, 25, 205, 64, 82, 11, 195, 168, 108, 55, 80, 127, 18, 8, 14, 64, 1, 184, 118, 206, 196, 85, 114, 167, 180, 68, 89, 181, 252, 37, 50, 248, 30, 120, 76, 124, 232, 210, 46, 118, 100, 133, 153, 28, 47, 0, 39, 122, 61, 29, 119, 173, 165, 39, 129, 60, 126, 30, 120, 3, 10, 228, 74, 97, 58, 109, 234, 159, 125, 54, 218, 158, 104, 38, 216 }, "Marcin", "11222", "Gdańsk", "Nowak", "12", "2", "-", "221112233", "Szeroka" }
                });

            migrationBuilder.InsertData(
                table: "PlatnoscTyp",
                columns: new[] { "PlatnoscTypID", "NazwaPlatnosc" },
                values: new object[,]
                {
                    { 1, "gotówka" },
                    { 2, "blik" },
                    { 3, "przelew" }
                });

            migrationBuilder.InsertData(
                table: "PozycjaMenu",
                columns: new[] { "PozycjaMenuID", "Cena", "NazwaPozycja", "ObrazekUrl", "Opis" },
                values: new object[,]
                {
                    { 3, 27.50m, "Dieta Sport", "https://i.ibb.co/CBTgwTZ/dieta-Sport.png", "Pozycja dla osób trenujących, bogata w białko" },
                    { 2, 25.50m, "Dieta Light", "https://i.ibb.co/kgPxXXX/dieta-Light.png", "Pozycja dla osób odchudzjących się, bogata w błonnik" },
                    { 1, 26.50m, "Dieta Vege", "https://i.ibb.co/ChJDspJ/dieta-Vege.png", "Pozycja dla wegetarian, bogata w produkty roślinne" }
                });

            migrationBuilder.InsertData(
                table: "PracownikRola",
                columns: new[] { "PracownikRolaID", "NazwaRola" },
                values: new object[,]
                {
                    { 1, "kucharz" },
                    { 2, "dostawca" },
                    { 3, "administrator" }
                });

            migrationBuilder.InsertData(
                table: "SkladnikOdzywczy",
                columns: new[] { "SkladnikOdzywczyID", "Kalorycznosc", "NazwaSkladnik" },
                values: new object[,]
                {
                    { 1, 4f, "białko" },
                    { 2, 9f, "tłuszcz" },
                    { 3, 4f, "węglowodany" }
                });

            migrationBuilder.InsertData(
                table: "ZamowienieStatus",
                columns: new[] { "ZamowienieStatusID", "NazwaStatus" },
                values: new object[,]
                {
                    { 1, "zamówione" },
                    { 2, "w trakcie przygotowywania" },
                    { 3, "przygotowane" },
                    { 4, "w trakcie dostawy" },
                    { 5, "dostarczone" }
                });

            migrationBuilder.InsertData(
                table: "Pracownik",
                columns: new[] { "PracownikID", "HasloHash", "HasloSalt", "Login", "PracownikRolaID" },
                values: new object[,]
                {
                    { 1, new byte[] { 88, 99, 250, 96, 27, 39, 98, 124, 132, 199, 254, 30, 29, 99, 239, 84, 144, 182, 200, 157, 156, 90, 135, 109, 176, 119, 173, 132, 255, 225, 12, 45, 71, 17, 104, 111, 100, 106, 173, 79, 125, 214, 140, 153, 119, 211, 243, 97, 95, 120, 199, 162, 250, 212, 48, 189, 141, 96, 14, 29, 174, 66, 176, 134 }, new byte[] { 219, 202, 46, 140, 220, 31, 157, 188, 85, 16, 198, 227, 251, 3, 95, 238, 71, 171, 192, 35, 171, 16, 244, 167, 169, 97, 162, 13, 23, 14, 68, 45, 249, 177, 92, 71, 74, 166, 80, 107, 49, 91, 19, 159, 121, 26, 157, 156, 57, 238, 193, 81, 245, 170, 146, 120, 98, 155, 167, 236, 189, 85, 239, 119, 241, 125, 98, 144, 198, 175, 100, 107, 171, 5, 174, 74, 121, 92, 79, 168, 187, 237, 130, 85, 200, 57, 241, 170, 190, 139, 222, 238, 91, 161, 238, 181, 200, 237, 119, 64, 24, 5, 151, 57, 137, 145, 154, 69, 63, 207, 179, 79, 132, 168, 74, 36, 46, 131, 43, 222, 236, 49, 56, 132, 221, 9, 12, 52 }, "kucharz1", 1 },
                    { 2, new byte[] { 246, 105, 54, 49, 83, 189, 240, 143, 129, 207, 253, 160, 90, 103, 163, 111, 24, 56, 85, 229, 83, 157, 148, 83, 178, 89, 218, 97, 220, 233, 153, 94, 154, 29, 173, 113, 146, 62, 70, 156, 163, 109, 191, 50, 77, 53, 183, 75, 90, 16, 90, 80, 156, 154, 10, 117, 21, 117, 61, 67, 45, 37, 8, 186 }, new byte[] { 219, 95, 92, 132, 78, 74, 73, 252, 13, 93, 146, 254, 134, 37, 44, 237, 242, 70, 119, 203, 194, 88, 131, 56, 11, 216, 218, 220, 182, 89, 77, 50, 161, 204, 111, 74, 33, 100, 236, 50, 64, 116, 80, 34, 216, 97, 140, 38, 164, 136, 33, 152, 211, 119, 83, 162, 191, 220, 173, 39, 155, 218, 5, 246, 234, 235, 242, 244, 131, 198, 61, 117, 205, 7, 15, 175, 148, 98, 24, 183, 246, 183, 91, 59, 175, 125, 208, 201, 200, 136, 109, 2, 230, 236, 131, 16, 234, 84, 203, 213, 243, 17, 27, 100, 41, 190, 42, 112, 144, 214, 206, 43, 214, 104, 171, 55, 139, 211, 207, 228, 213, 66, 118, 145, 85, 137, 247, 121 }, "dostawca1", 2 },
                    { 3, new byte[] { 137, 224, 224, 5, 149, 165, 6, 146, 210, 239, 220, 213, 163, 138, 82, 240, 107, 213, 155, 202, 114, 57, 11, 107, 26, 240, 137, 36, 133, 156, 139, 41, 17, 53, 27, 188, 223, 24, 21, 17, 0, 63, 151, 180, 34, 162, 117, 164, 88, 108, 205, 130, 208, 241, 98, 255, 219, 247, 94, 39, 237, 128, 213, 111 }, new byte[] { 42, 222, 3, 39, 252, 148, 22, 236, 185, 162, 251, 30, 247, 103, 142, 30, 76, 165, 241, 85, 232, 146, 25, 136, 168, 134, 180, 74, 182, 2, 74, 195, 183, 111, 141, 171, 30, 57, 163, 81, 250, 14, 86, 47, 226, 123, 185, 187, 37, 25, 56, 139, 88, 96, 43, 86, 236, 250, 76, 149, 101, 107, 115, 0, 173, 242, 138, 22, 116, 166, 91, 226, 252, 252, 62, 144, 28, 186, 49, 149, 30, 103, 7, 104, 103, 93, 29, 45, 156, 100, 124, 39, 181, 89, 39, 214, 85, 33, 101, 241, 38, 249, 41, 20, 20, 143, 76, 189, 187, 250, 92, 118, 206, 217, 11, 73, 147, 50, 145, 253, 248, 96, 32, 126, 255, 51, 76, 146 }, "administartor1", 3 }
                });

            migrationBuilder.InsertData(
                table: "Skladnik",
                columns: new[] { "SkladnikID", "CzyWeganski", "CzyWegetarianski", "MasaSkladnik", "NazwaSkladnik", "PozycjaMenuID" },
                values: new object[,]
                {
                    { 1, true, true, 42f, "awokado", 1 },
                    { 2, true, true, 45f, "marchew", 1 },
                    { 3, true, true, 80f, "soczewica", 1 },
                    { 4, true, true, 200f, "pomidory", 1 },
                    { 5, false, false, 142f, "dorsz gotowany", 2 },
                    { 6, false, false, 57f, "brokuły", 2 },
                    { 7, true, true, 68f, "dziki ryż", 2 },
                    { 8, false, false, 143f, "kurczak", 3 },
                    { 9, true, true, 153f, "ziemniaki", 3 },
                    { 10, true, true, 63f, "sałata", 3 }
                });

            migrationBuilder.InsertData(
                table: "InformacjaAlergen",
                columns: new[] { "InformacjaAlergenID", "AlergenID", "SkladnikID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 6, 1, 6 },
                    { 2, 1, 2 },
                    { 10, 1, 10 },
                    { 5, 1, 5 },
                    { 3, 1, 3 },
                    { 8, 1, 8 },
                    { 9, 1, 9 },
                    { 7, 1, 7 },
                    { 4, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "WartoscOdzywcza",
                columns: new[] { "WartoscOdzywczaID", "SkladnikID", "SkladnikOdzywczyID", "ZawartoscSkladnikOdzywczy" },
                values: new object[,]
                {
                    { 19, 7, 2, 1.1f },
                    { 20, 7, 3, 75f },
                    { 21, 7, 1, 15f },
                    { 22, 8, 2, 14f },
                    { 24, 8, 1, 27f },
                    { 25, 9, 2, 0.1f },
                    { 26, 9, 3, 16.3f },
                    { 27, 9, 1, 1.8f },
                    { 28, 10, 2, 0.2f },
                    { 29, 10, 3, 2.9f },
                    { 30, 10, 1, 1.4f },
                    { 23, 8, 3, 0f },
                    { 18, 6, 1, 2.8f },
                    { 16, 6, 2, 0.4f },
                    { 7, 3, 2, 0.4f },
                    { 15, 5, 1, 17.8f },
                    { 14, 5, 3, 0f },
                    { 13, 5, 2, 0.67f },
                    { 12, 4, 1, 0.9f },
                    { 11, 4, 3, 3.9f },
                    { 10, 4, 2, 0.2f },
                    { 9, 3, 1, 9f },
                    { 8, 3, 3, 20f },
                    { 17, 6, 3, 7f },
                    { 6, 2, 1, 0.9f },
                    { 5, 2, 3, 10f },
                    { 4, 2, 2, 0.2f },
                    { 3, 1, 1, 4f },
                    { 2, 1, 3, 9f },
                    { 1, 1, 2, 15f }
                });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "ZamowienieID", "DataRealizacji", "DataZlozenia", "KlientID", "KodPocztowy", "Koszt", "Miejscowosc", "NrBudynek", "NrMieszkanie", "PlatnoscTypID", "PozycjaMenuID", "PracownikID", "Ulica", "ZamowienieStatusID" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 6, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 5, 9, 47, 0, 0, DateTimeKind.Unspecified), 2, "43210", 30.5m, "Wrocław", "14c", "-", 2, 2, 1, "Miła", 3 },
                    { 1, new DateTime(2020, 6, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 9, 47, 0, 0, DateTimeKind.Unspecified), 1, "01234", 31.5m, "Warszawa", "1", "2", 1, 1, 1, "Długa", 1 },
                    { 3, new DateTime(2020, 6, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 3, 9, 7, 5, 0, DateTimeKind.Unspecified), 3, "11222", 36.5m, "Gdańsk", "12", "2", 3, 3, 1, "Szeroka", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alergen",
                keyColumn: "AlergenID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Alergen",
                keyColumn: "AlergenID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Alergen",
                keyColumn: "AlergenID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InformacjaAlergen",
                keyColumn: "InformacjaAlergenID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "PracownikID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "PracownikID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "WartoscOdzywcza",
                keyColumn: "WartoscOdzywczaID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "ZamowienieID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "ZamowienieID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "ZamowienieID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZamowienieStatus",
                keyColumn: "ZamowienieStatusID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ZamowienieStatus",
                keyColumn: "ZamowienieStatusID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Alergen",
                keyColumn: "AlergenID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "KlientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "KlientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "KlientID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlatnoscTyp",
                keyColumn: "PlatnoscTypID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlatnoscTyp",
                keyColumn: "PlatnoscTypID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlatnoscTyp",
                keyColumn: "PlatnoscTypID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "PracownikID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PracownikRola",
                keyColumn: "PracownikRolaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PracownikRola",
                keyColumn: "PracownikRolaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skladnik",
                keyColumn: "SkladnikID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SkladnikOdzywczy",
                keyColumn: "SkladnikOdzywczyID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SkladnikOdzywczy",
                keyColumn: "SkladnikOdzywczyID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SkladnikOdzywczy",
                keyColumn: "SkladnikOdzywczyID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZamowienieStatus",
                keyColumn: "ZamowienieStatusID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ZamowienieStatus",
                keyColumn: "ZamowienieStatusID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZamowienieStatus",
                keyColumn: "ZamowienieStatusID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PozycjaMenu",
                keyColumn: "PozycjaMenuID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PozycjaMenu",
                keyColumn: "PozycjaMenuID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PozycjaMenu",
                keyColumn: "PozycjaMenuID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PracownikRola",
                keyColumn: "PracownikRolaID",
                keyValue: 1);
        }
    }
}
