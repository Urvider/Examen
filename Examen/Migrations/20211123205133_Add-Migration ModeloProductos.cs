using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Migrations
{
    public partial class AddMigrationModeloProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioCompra = table.Column<double>(nullable: false),
                    PrecioVenta = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
