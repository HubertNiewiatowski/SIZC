using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIZCapi.Migrations
{
    public partial class InicjalizacjaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alergen",
                columns: table => new
                {
                    AlergenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlergen = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergen", x => x.AlergenID);
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    KlientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AdresEmail = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NrTelStacjonarny = table.Column<string>(type: "varchar(50)", nullable: true),
                    NrTelKomorkowy = table.Column<string>(type: "varchar(50)", nullable: true),
                    KodPocztowy = table.Column<string>(type: "varchar(5)", nullable: true),
                    Miejscowosc = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NrBudynek = table.Column<string>(type: "varchar(15)", nullable: true),
                    NrMieszkanie = table.Column<string>(type: "varchar(15)", nullable: true),
                    HasloHash = table.Column<byte[]>(nullable: true),
                    HasloSalt = table.Column<byte[]>(nullable: true),
                    DataRejestracji = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.KlientID);
                });

            migrationBuilder.CreateTable(
                name: "PlatnoscTyp",
                columns: table => new
                {
                    PlatnoscTypID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaPlatnosc = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatnoscTyp", x => x.PlatnoscTypID);
                });

            migrationBuilder.CreateTable(
                name: "PozycjaMenu",
                columns: table => new
                {
                    PozycjaMenuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaPozycja = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    ObrazekUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjaMenu", x => x.PozycjaMenuID);
                });

            migrationBuilder.CreateTable(
                name: "PracownikRola",
                columns: table => new
                {
                    PracownikRolaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaRola = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracownikRola", x => x.PracownikRolaID);
                });

            migrationBuilder.CreateTable(
                name: "SkladnikOdzywczy",
                columns: table => new
                {
                    SkladnikOdzywczyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaSkladnik = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Kalorycznosc = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkladnikOdzywczy", x => x.SkladnikOdzywczyID);
                });

            migrationBuilder.CreateTable(
                name: "ZamowienieStatus",
                columns: table => new
                {
                    ZamowienieStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaStatus = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamowienieStatus", x => x.ZamowienieStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Skladnik",
                columns: table => new
                {
                    SkladnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaSkladnik = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CzyWeganski = table.Column<bool>(nullable: false),
                    CzyWegetarianski = table.Column<bool>(nullable: false),
                    MasaSkladnik = table.Column<float>(nullable: false),
                    PozycjaMenuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladnik", x => x.SkladnikID);
                    table.ForeignKey(
                        name: "FK_Skladnik_PozycjaMenu_PozycjaMenuID",
                        column: x => x.PozycjaMenuID,
                        principalTable: "PozycjaMenu",
                        principalColumn: "PozycjaMenuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    PracownikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HasloHash = table.Column<byte[]>(nullable: true),
                    HasloSalt = table.Column<byte[]>(nullable: true),
                    PracownikRolaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.PracownikID);
                    table.ForeignKey(
                        name: "FK_Pracownik_PracownikRola_PracownikRolaID",
                        column: x => x.PracownikRolaID,
                        principalTable: "PracownikRola",
                        principalColumn: "PracownikRolaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformacjaAlergen",
                columns: table => new
                {
                    InformacjaAlergenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkladnikID = table.Column<int>(nullable: false),
                    AlergenID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacjaAlergen", x => x.InformacjaAlergenID);
                    table.ForeignKey(
                        name: "FK_InformacjaAlergen_Alergen_AlergenID",
                        column: x => x.AlergenID,
                        principalTable: "Alergen",
                        principalColumn: "AlergenID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformacjaAlergen_Skladnik_SkladnikID",
                        column: x => x.SkladnikID,
                        principalTable: "Skladnik",
                        principalColumn: "SkladnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WartoscOdzywcza",
                columns: table => new
                {
                    WartoscOdzywczaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZawartoscSkladnikOdzywczy = table.Column<float>(nullable: false),
                    SkladnikID = table.Column<int>(nullable: false),
                    SkladnikOdzywczyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WartoscOdzywcza", x => x.WartoscOdzywczaID);
                    table.ForeignKey(
                        name: "FK_WartoscOdzywcza_Skladnik_SkladnikID",
                        column: x => x.SkladnikID,
                        principalTable: "Skladnik",
                        principalColumn: "SkladnikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WartoscOdzywcza_SkladnikOdzywczy_SkladnikOdzywczyID",
                        column: x => x.SkladnikOdzywczyID,
                        principalTable: "SkladnikOdzywczy",
                        principalColumn: "SkladnikOdzywczyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    ZamowienieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Koszt = table.Column<decimal>(type: "money", nullable: false),
                    KodPocztowy = table.Column<string>(type: "varchar(5)", nullable: true),
                    Miejscowosc = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NrBudynek = table.Column<string>(type: "varchar(15)", nullable: true),
                    NrMieszkanie = table.Column<string>(type: "varchar(15)", nullable: true),
                    DataRealizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZlozenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PozycjaMenuID = table.Column<int>(nullable: false),
                    KlientID = table.Column<int>(nullable: false),
                    PracownikID = table.Column<int>(nullable: false),
                    PlatnoscTypID = table.Column<int>(nullable: false),
                    ZamowienieStatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.ZamowienieID);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klient_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klient",
                        principalColumn: "KlientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_PlatnoscTyp_PlatnoscTypID",
                        column: x => x.PlatnoscTypID,
                        principalTable: "PlatnoscTyp",
                        principalColumn: "PlatnoscTypID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_PozycjaMenu_PozycjaMenuID",
                        column: x => x.PozycjaMenuID,
                        principalTable: "PozycjaMenu",
                        principalColumn: "PozycjaMenuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Pracownik_PracownikID",
                        column: x => x.PracownikID,
                        principalTable: "Pracownik",
                        principalColumn: "PracownikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_ZamowienieStatus_ZamowienieStatusID",
                        column: x => x.ZamowienieStatusID,
                        principalTable: "ZamowienieStatus",
                        principalColumn: "ZamowienieStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, "hubertniewiatowski@outlook.com", new DateTime(2020, 6, 1, 11, 47, 3, 0, DateTimeKind.Unspecified), new byte[] { 191, 69, 151, 158, 145, 119, 85, 164, 226, 40, 100, 18, 254, 166, 89, 27, 198, 17, 209, 160, 95, 170, 161, 192, 247, 118, 62, 92, 35, 26, 162, 182, 145, 226, 176, 193, 193, 197, 76, 215, 158, 1, 238, 46, 80, 154, 1, 140, 207, 186, 168, 160, 148, 31, 10, 223, 101, 86, 157, 37, 206, 185, 20, 181 }, new byte[] { 28, 127, 34, 243, 143, 102, 71, 201, 216, 88, 100, 243, 159, 147, 112, 211, 243, 122, 142, 17, 213, 101, 107, 187, 178, 185, 12, 103, 125, 75, 173, 157, 152, 119, 124, 142, 117, 124, 32, 210, 118, 240, 30, 193, 213, 36, 182, 219, 93, 154, 134, 235, 56, 4, 253, 236, 82, 55, 1, 34, 173, 71, 129, 193, 74, 97, 29, 176, 160, 81, 83, 162, 27, 16, 105, 188, 198, 165, 47, 11, 58, 148, 32, 233, 227, 212, 166, 250, 20, 234, 66, 87, 85, 135, 178, 200, 31, 228, 213, 107, 194, 52, 205, 42, 159, 117, 208, 44, 237, 129, 242, 169, 241, 223, 211, 170, 220, 203, 83, 126, 59, 118, 25, 82, 201, 62, 161, 112 }, "Jan", "01234", "Warszawa", "Kowalski", "1", "2", "123456789", "221234567", "Długa" },
                    { 2, "hubertniewiatowski@outlook.com", new DateTime(2020, 6, 3, 14, 58, 12, 0, DateTimeKind.Unspecified), new byte[] { 63, 48, 166, 227, 159, 93, 188, 138, 251, 188, 127, 202, 31, 110, 184, 173, 94, 131, 53, 206, 9, 231, 235, 105, 118, 75, 20, 254, 95, 108, 122, 91, 156, 14, 219, 74, 146, 64, 147, 97, 105, 14, 67, 161, 212, 140, 216, 29, 194, 153, 17, 30, 247, 183, 26, 238, 77, 83, 166, 91, 11, 67, 255, 73 }, new byte[] { 6, 111, 19, 185, 214, 10, 203, 233, 16, 41, 25, 102, 51, 188, 15, 192, 234, 105, 71, 174, 39, 76, 222, 147, 33, 253, 17, 162, 189, 46, 116, 148, 239, 104, 247, 165, 205, 127, 148, 65, 197, 216, 184, 54, 229, 164, 120, 126, 45, 199, 33, 198, 250, 190, 110, 219, 250, 194, 9, 153, 225, 113, 232, 243, 138, 194, 243, 105, 192, 166, 114, 220, 56, 182, 253, 208, 234, 31, 125, 196, 120, 145, 214, 203, 244, 3, 248, 85, 223, 183, 91, 207, 216, 138, 159, 247, 176, 199, 103, 54, 225, 39, 132, 211, 184, 177, 73, 220, 192, 37, 18, 61, 205, 226, 226, 117, 2, 30, 114, 195, 185, 73, 31, 196, 20, 31, 65, 241 }, "Elżbieta", "43210", "Kraków", "Zalewska", "17a", "-", "987654321", "-", "Krótka" },
                    { 3, "hubertniewiatowski@outlook.com", new DateTime(2020, 6, 7, 23, 7, 21, 0, DateTimeKind.Unspecified), new byte[] { 136, 76, 253, 209, 225, 136, 74, 97, 133, 15, 50, 23, 37, 209, 54, 91, 79, 102, 79, 163, 95, 150, 14, 253, 11, 149, 18, 14, 143, 114, 38, 82, 104, 247, 89, 160, 145, 8, 103, 110, 206, 250, 12, 24, 9, 200, 30, 109, 247, 118, 75, 238, 100, 190, 133, 41, 74, 206, 150, 72, 15, 187, 193, 146 }, new byte[] { 47, 18, 235, 93, 253, 73, 226, 183, 163, 119, 249, 224, 3, 107, 208, 195, 91, 228, 115, 133, 188, 94, 249, 94, 121, 106, 209, 196, 168, 185, 168, 254, 16, 170, 43, 160, 67, 222, 78, 187, 0, 51, 66, 132, 223, 128, 131, 14, 137, 240, 39, 117, 57, 136, 45, 153, 238, 137, 161, 100, 10, 244, 56, 21, 19, 4, 54, 160, 112, 76, 95, 199, 65, 56, 109, 167, 21, 6, 158, 53, 237, 177, 18, 102, 208, 243, 252, 248, 53, 60, 211, 93, 41, 57, 28, 189, 159, 209, 208, 204, 223, 210, 32, 182, 160, 77, 54, 83, 61, 69, 181, 97, 228, 117, 115, 218, 89, 27, 198, 73, 11, 16, 47, 3, 191, 133, 15, 26 }, "Marcin", "11222", "Gdańsk", "Nowak", "12", "2", "-", "221112233", "Szeroka" }
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
                    { 1, new byte[] { 7, 105, 98, 62, 141, 60, 221, 91, 173, 215, 198, 163, 53, 145, 84, 115, 160, 70, 252, 158, 196, 104, 249, 18, 240, 75, 36, 93, 87, 106, 42, 207, 250, 5, 245, 139, 198, 18, 33, 83, 189, 35, 209, 0, 87, 95, 207, 134, 191, 43, 205, 208, 114, 217, 126, 111, 124, 186, 79, 206, 250, 13, 191, 10 }, new byte[] { 4, 51, 154, 67, 114, 118, 41, 195, 215, 185, 114, 245, 167, 101, 38, 189, 221, 226, 126, 131, 38, 12, 121, 85, 182, 109, 196, 207, 50, 136, 62, 178, 49, 45, 122, 217, 3, 239, 61, 54, 206, 78, 222, 229, 85, 137, 98, 117, 30, 251, 156, 140, 198, 55, 232, 57, 251, 157, 151, 196, 189, 69, 48, 169, 209, 99, 50, 130, 48, 200, 71, 157, 230, 227, 218, 33, 152, 79, 229, 66, 147, 241, 170, 36, 47, 95, 153, 15, 129, 93, 159, 248, 4, 163, 25, 63, 73, 141, 218, 53, 133, 56, 187, 169, 199, 73, 63, 253, 36, 46, 247, 187, 173, 26, 71, 93, 59, 1, 109, 190, 222, 63, 236, 38, 228, 100, 171, 0 }, "kucharz1", 1 },
                    { 2, new byte[] { 35, 150, 89, 149, 171, 157, 179, 242, 156, 136, 96, 162, 52, 134, 253, 32, 22, 85, 9, 96, 51, 105, 253, 162, 178, 22, 247, 148, 195, 31, 19, 68, 114, 127, 132, 29, 135, 42, 194, 170, 247, 196, 51, 118, 85, 211, 34, 121, 62, 67, 109, 8, 119, 140, 239, 215, 241, 57, 28, 182, 210, 127, 63, 21 }, new byte[] { 110, 60, 30, 221, 242, 167, 132, 128, 71, 93, 205, 44, 186, 42, 180, 177, 144, 241, 50, 151, 55, 36, 251, 10, 3, 4, 185, 162, 191, 89, 49, 139, 213, 71, 221, 165, 42, 110, 74, 92, 169, 192, 9, 47, 73, 253, 189, 86, 37, 155, 25, 142, 104, 20, 209, 239, 137, 179, 118, 7, 200, 70, 81, 194, 158, 45, 131, 191, 41, 154, 201, 113, 227, 236, 31, 47, 55, 112, 104, 65, 233, 252, 137, 221, 59, 216, 120, 47, 2, 64, 186, 221, 199, 79, 136, 14, 148, 117, 116, 129, 208, 241, 155, 211, 240, 9, 36, 22, 196, 232, 14, 151, 169, 130, 226, 175, 151, 182, 135, 60, 246, 197, 134, 48, 39, 159, 75, 10 }, "dostawca1", 2 },
                    { 3, new byte[] { 167, 131, 196, 223, 23, 232, 249, 147, 143, 26, 20, 18, 74, 119, 195, 30, 49, 181, 223, 42, 4, 15, 160, 218, 175, 116, 138, 64, 65, 93, 151, 132, 98, 102, 250, 72, 190, 95, 26, 24, 100, 245, 197, 105, 246, 189, 29, 89, 165, 226, 77, 81, 101, 18, 105, 93, 20, 72, 27, 139, 94, 199, 54, 9 }, new byte[] { 238, 221, 161, 58, 121, 3, 204, 246, 17, 201, 254, 215, 7, 11, 115, 57, 68, 241, 58, 188, 71, 151, 108, 97, 104, 118, 221, 123, 2, 157, 239, 63, 216, 216, 173, 215, 167, 14, 41, 89, 25, 187, 61, 19, 85, 40, 161, 196, 202, 239, 62, 226, 40, 99, 25, 46, 172, 129, 201, 233, 68, 186, 127, 237, 44, 218, 157, 204, 63, 156, 80, 153, 238, 196, 40, 124, 5, 173, 231, 126, 205, 108, 234, 82, 145, 123, 240, 121, 152, 24, 190, 118, 87, 172, 32, 34, 164, 132, 131, 163, 177, 53, 162, 203, 97, 90, 76, 16, 232, 226, 5, 26, 254, 245, 44, 183, 177, 66, 98, 32, 236, 147, 153, 184, 91, 221, 94, 153 }, "administrator1", 3 }
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
                    { 2, new DateTime(2020, 6, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 4, 17, 47, 42, 0, DateTimeKind.Unspecified), 2, "43210", 30.5m, "Wrocław", "14c", "-", 2, 2, 1, "Miła", 3 },
                    { 1, new DateTime(2020, 6, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 13, 57, 32, 0, DateTimeKind.Unspecified), 1, "01234", 31.5m, "Warszawa", "1", "2", 1, 1, 1, "Długa", 1 },
                    { 3, new DateTime(2020, 6, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 8, 9, 7, 5, 0, DateTimeKind.Unspecified), 3, "11222", 36.5m, "Gdańsk", "12", "2", 3, 3, 1, "Szeroka", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformacjaAlergen_AlergenID",
                table: "InformacjaAlergen",
                column: "AlergenID");

            migrationBuilder.CreateIndex(
                name: "IX_InformacjaAlergen_SkladnikID",
                table: "InformacjaAlergen",
                column: "SkladnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_PracownikRolaID",
                table: "Pracownik",
                column: "PracownikRolaID");

            migrationBuilder.CreateIndex(
                name: "IX_Skladnik_PozycjaMenuID",
                table: "Skladnik",
                column: "PozycjaMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_WartoscOdzywcza_SkladnikID",
                table: "WartoscOdzywcza",
                column: "SkladnikID");

            migrationBuilder.CreateIndex(
                name: "IX_WartoscOdzywcza_SkladnikOdzywczyID",
                table: "WartoscOdzywcza",
                column: "SkladnikOdzywczyID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_KlientID",
                table: "Zamowienie",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_PlatnoscTypID",
                table: "Zamowienie",
                column: "PlatnoscTypID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_PozycjaMenuID",
                table: "Zamowienie",
                column: "PozycjaMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_PracownikID",
                table: "Zamowienie",
                column: "PracownikID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_ZamowienieStatusID",
                table: "Zamowienie",
                column: "ZamowienieStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacjaAlergen");

            migrationBuilder.DropTable(
                name: "WartoscOdzywcza");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Alergen");

            migrationBuilder.DropTable(
                name: "Skladnik");

            migrationBuilder.DropTable(
                name: "SkladnikOdzywczy");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "PlatnoscTyp");

            migrationBuilder.DropTable(
                name: "Pracownik");

            migrationBuilder.DropTable(
                name: "ZamowienieStatus");

            migrationBuilder.DropTable(
                name: "PozycjaMenu");

            migrationBuilder.DropTable(
                name: "PracownikRola");
        }
    }
}
