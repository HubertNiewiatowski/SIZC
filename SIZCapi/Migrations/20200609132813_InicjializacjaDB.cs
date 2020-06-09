using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIZCapi.Migrations
{
    public partial class InicjializacjaDB : Migration
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
