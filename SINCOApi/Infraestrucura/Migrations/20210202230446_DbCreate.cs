using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class DbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificación = table.Column<string>(maxLength: 15, nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(maxLength: 100, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Dirección = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "profesores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificación = table.Column<string>(maxLength: 15, nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(maxLength: 100, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Dirección = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(maxLength: 15, nullable: true),
                    Asignaturaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profesores_Asignaturas_Asignaturaid",
                        column: x => x.Asignaturaid,
                        principalTable: "Asignaturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_profesores_Asignaturaid",
                table: "profesores",
                column: "Asignaturaid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "profesores");

            migrationBuilder.DropTable(
                name: "Asignaturas");
        }
    }
}
