using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Api.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductor",
                columns: table => new
                {
                    ConductorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Dni = table.Column<string>(unicode: false, maxLength: 8, nullable: false),
                    Direccion = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Celular = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Correo = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductor", x => x.ConductorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conductor");
        }
    }
}
