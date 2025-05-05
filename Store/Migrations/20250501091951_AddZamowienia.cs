using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class AddZamowienia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZlozenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UzytkownikId = table.Column<int>(type: "int", nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Uzytkownicy_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PozycjeZamowien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZamowienieID = table.Column<int>(type: "int", nullable: false),
                    ProduktID = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjeZamowien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PozycjeZamowien_Produkty_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PozycjeZamowien_Zamowienia_ZamowienieID",
                        column: x => x.ZamowienieID,
                        principalTable: "Zamowienia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZamowien_ProduktID",
                table: "PozycjeZamowien",
                column: "ProduktID");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZamowien_ZamowienieID",
                table: "PozycjeZamowien",
                column: "ZamowienieID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_UzytkownikId",
                table: "Zamowienia",
                column: "UzytkownikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PozycjeZamowien");

            migrationBuilder.DropTable(
                name: "Zamowienia");
        }
    }
}
