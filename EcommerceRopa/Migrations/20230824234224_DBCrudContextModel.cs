using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceRopa.Migrations
{
    public partial class DBCrudContextModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Talla = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estilo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    PrendaID = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Existencia = table.Column<int>(type: "int", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Inventari__Prend__398D8EEE",
                        column: x => x.PrendaID,
                        principalTable: "Prenda",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_PrendaID",
                table: "Inventario",
                column: "PrendaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Prenda");
        }
    }
}
