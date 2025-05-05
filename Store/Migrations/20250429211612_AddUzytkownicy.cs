using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class AddUzytkownicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UlicaNumerDomuMieszkania = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uzytkownicy");
        }
    }
}
