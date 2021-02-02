using Microsoft.EntityFrameworkCore.Migrations;

namespace SINCOApi.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Telefono = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profesores");
        }
    }
}
