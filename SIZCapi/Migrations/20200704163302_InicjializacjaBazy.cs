using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIZCapi.Migrations
{
    public partial class InicjializacjaBazy : Migration
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
                    { 1, "hubertniewiatowski@outlook.com", new DateTime(2020, 6, 1, 11, 47, 3, 0, DateTimeKind.Unspecified), new byte[] { 149, 191, 148, 51, 81, 184, 15, 229, 203, 117, 223, 25, 162, 50, 137, 250, 163, 167, 28, 22, 141, 107, 64, 75, 20, 87, 213, 72, 208, 150, 75, 202, 249, 216, 118, 130, 88, 121, 211, 122, 22, 106, 180, 247, 174, 131, 126, 226, 253, 71, 177, 79, 126, 10, 19, 117, 159, 58, 208, 182, 74, 102, 202, 68 }, new byte[] { 237, 70, 77, 182, 240, 176, 216, 2, 86, 183, 167, 29, 151, 173, 234, 224, 180, 22, 118, 37, 69, 131, 175, 126, 98, 99, 130, 1, 9, 199, 116, 49, 159, 93, 6, 248, 137, 226, 237, 125, 26, 88, 190, 104, 67, 62, 92, 119, 64, 177, 149, 105, 26, 39, 226, 65, 106, 48, 89, 240, 4, 90, 120, 130, 244, 246, 25, 181, 104, 85, 226, 116, 35, 29, 65, 25, 17, 43, 60, 111, 36, 84, 225, 180, 37, 13, 246, 124, 174, 7, 131, 22, 25, 231, 130, 200, 212, 251, 224, 12, 120, 239, 43, 128, 203, 249, 25, 143, 214, 83, 14, 161, 192, 35, 206, 207, 108, 203, 19, 177, 109, 161, 133, 89, 231, 231, 145, 150 }, "Jan", "01234", "Warszawa", "Kowalski", "1", "2", "123456789", "221234567", "Długa" },
                    { 2, "elz.zal@wp.pl", new DateTime(2020, 6, 3, 14, 58, 12, 0, DateTimeKind.Unspecified), new byte[] { 79, 94, 226, 122, 123, 205, 45, 57, 1, 239, 95, 213, 157, 145, 89, 38, 250, 96, 238, 140, 215, 241, 146, 13, 56, 188, 212, 53, 133, 200, 25, 208, 48, 107, 30, 171, 31, 53, 185, 245, 205, 212, 230, 147, 33, 142, 136, 234, 97, 229, 192, 192, 253, 231, 183, 11, 23, 6, 190, 152, 161, 31, 168, 133 }, new byte[] { 126, 205, 15, 35, 20, 106, 255, 106, 213, 16, 249, 151, 95, 153, 103, 142, 203, 201, 86, 131, 47, 9, 186, 1, 196, 204, 129, 224, 137, 58, 113, 147, 86, 222, 166, 47, 142, 29, 113, 85, 19, 135, 240, 218, 98, 230, 139, 168, 211, 233, 91, 136, 163, 62, 67, 124, 210, 52, 108, 14, 48, 62, 217, 18, 105, 118, 154, 183, 156, 231, 212, 197, 85, 154, 77, 53, 209, 96, 39, 142, 123, 203, 140, 52, 35, 191, 80, 142, 188, 26, 247, 33, 18, 196, 102, 7, 80, 87, 150, 241, 159, 93, 246, 46, 187, 35, 19, 240, 90, 232, 60, 27, 235, 0, 68, 27, 161, 173, 180, 85, 205, 149, 217, 89, 94, 165, 56, 162 }, "Elżbieta", "43210", "Kraków", "Zalewska", "17a", "-", "987654321", "-", "Krótka" },
                    { 3, "mar.now@onet.pl", new DateTime(2020, 6, 7, 23, 7, 21, 0, DateTimeKind.Unspecified), new byte[] { 113, 196, 224, 66, 169, 1, 126, 46, 137, 97, 48, 104, 154, 41, 236, 235, 52, 112, 168, 1, 103, 192, 174, 216, 192, 21, 12, 220, 56, 93, 211, 16, 122, 25, 49, 90, 85, 171, 92, 248, 212, 202, 176, 94, 27, 153, 67, 10, 36, 188, 236, 77, 142, 118, 66, 148, 75, 194, 98, 117, 37, 179, 91, 208 }, new byte[] { 125, 243, 64, 151, 31, 211, 250, 134, 146, 90, 246, 190, 165, 52, 98, 35, 225, 185, 14, 206, 241, 211, 92, 0, 9, 33, 201, 24, 18, 174, 16, 210, 133, 112, 110, 252, 183, 139, 26, 101, 25, 105, 253, 187, 204, 25, 117, 228, 58, 14, 51, 242, 185, 67, 236, 225, 98, 62, 93, 99, 107, 31, 45, 35, 121, 176, 99, 114, 132, 239, 117, 245, 139, 38, 226, 148, 34, 41, 123, 125, 117, 200, 115, 236, 115, 121, 234, 96, 148, 22, 228, 28, 239, 167, 162, 66, 169, 243, 194, 126, 216, 171, 184, 172, 38, 182, 63, 45, 19, 209, 37, 78, 140, 113, 23, 239, 78, 201, 31, 103, 53, 191, 95, 240, 184, 87, 90, 175 }, "Marcin", "11222", "Gdańsk", "Nowak", "12", "2", "-", "221112233", "Szeroka" }
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
                    { 1, new byte[] { 165, 174, 245, 7, 144, 195, 2, 55, 149, 184, 59, 141, 1, 175, 173, 47, 87, 77, 231, 189, 53, 230, 60, 208, 206, 200, 122, 51, 248, 207, 112, 198, 151, 53, 37, 162, 147, 199, 7, 166, 228, 217, 242, 164, 146, 226, 107, 189, 53, 122, 38, 38, 165, 129, 129, 193, 174, 1, 75, 239, 29, 136, 22, 5 }, new byte[] { 10, 51, 15, 132, 230, 70, 227, 113, 47, 91, 39, 52, 150, 243, 61, 226, 255, 65, 159, 38, 103, 181, 168, 184, 136, 59, 73, 67, 65, 117, 29, 249, 234, 180, 8, 11, 121, 96, 79, 112, 71, 230, 88, 188, 166, 189, 164, 135, 200, 67, 33, 205, 192, 96, 38, 80, 6, 240, 108, 236, 240, 8, 179, 28, 117, 100, 5, 105, 234, 105, 204, 12, 96, 199, 73, 171, 179, 47, 5, 15, 250, 150, 154, 227, 29, 167, 172, 220, 124, 4, 138, 249, 14, 60, 153, 16, 132, 195, 198, 100, 79, 73, 112, 228, 176, 240, 185, 227, 247, 198, 168, 191, 116, 73, 200, 158, 24, 180, 195, 242, 5, 23, 89, 211, 168, 1, 206, 202 }, "kucharz1", 1 },
                    { 2, new byte[] { 142, 45, 102, 153, 202, 19, 11, 55, 153, 139, 1, 86, 10, 29, 69, 68, 32, 63, 206, 81, 77, 213, 55, 0, 16, 81, 193, 69, 71, 28, 247, 238, 15, 111, 107, 80, 158, 20, 180, 147, 44, 226, 248, 72, 226, 54, 21, 20, 157, 199, 14, 126, 215, 247, 202, 155, 179, 12, 3, 143, 24, 127, 187, 9 }, new byte[] { 232, 97, 82, 212, 195, 90, 217, 108, 232, 246, 93, 168, 91, 143, 251, 68, 245, 100, 59, 60, 230, 60, 225, 53, 107, 167, 66, 52, 16, 178, 136, 121, 168, 73, 17, 224, 149, 62, 230, 66, 37, 193, 85, 11, 83, 37, 18, 152, 187, 32, 169, 101, 128, 47, 51, 42, 23, 37, 20, 165, 65, 78, 114, 4, 217, 205, 201, 12, 169, 101, 42, 241, 173, 173, 38, 62, 107, 68, 79, 45, 141, 87, 187, 253, 231, 221, 150, 236, 66, 70, 188, 156, 89, 220, 82, 187, 221, 233, 0, 150, 236, 103, 15, 24, 50, 16, 56, 184, 139, 173, 190, 165, 202, 226, 202, 142, 232, 32, 180, 236, 54, 7, 168, 242, 31, 39, 20, 204 }, "dostawca1", 2 },
                    { 3, new byte[] { 82, 194, 108, 64, 42, 144, 125, 17, 1, 177, 83, 81, 71, 142, 143, 218, 40, 88, 237, 212, 158, 25, 26, 6, 18, 80, 209, 221, 44, 183, 166, 197, 145, 232, 68, 7, 122, 100, 182, 18, 106, 198, 253, 168, 198, 194, 43, 249, 181, 134, 191, 250, 245, 1, 152, 108, 78, 189, 208, 78, 125, 162, 155, 155 }, new byte[] { 238, 251, 81, 62, 113, 163, 25, 109, 198, 75, 119, 86, 184, 30, 183, 122, 220, 18, 181, 223, 165, 211, 44, 90, 21, 238, 34, 53, 55, 55, 170, 75, 7, 57, 4, 107, 139, 238, 163, 81, 48, 133, 232, 220, 242, 160, 149, 194, 187, 52, 0, 168, 223, 198, 116, 237, 167, 113, 167, 30, 250, 140, 34, 199, 19, 43, 111, 36, 213, 25, 225, 143, 29, 140, 178, 52, 103, 131, 50, 186, 20, 86, 66, 178, 161, 152, 209, 73, 160, 208, 22, 102, 34, 22, 136, 178, 125, 7, 124, 146, 155, 52, 75, 130, 43, 148, 78, 6, 101, 204, 26, 17, 89, 144, 182, 170, 42, 47, 161, 245, 58, 193, 60, 12, 99, 229, 243, 178 }, "administrator1", 3 }
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
