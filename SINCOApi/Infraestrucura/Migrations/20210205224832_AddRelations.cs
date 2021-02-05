using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class AddRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AsignaturaId",
                table: "Calificaciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_AsignaturaId",
                table: "Calificaciones",
                column: "AsignaturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Asignaturas_AsignaturaId",
                table: "Calificaciones",
                column: "AsignaturaId",
                principalTable: "Asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Asignaturas_AsignaturaId",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_AsignaturaId",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "AsignaturaId",
                table: "Calificaciones");
        }
    }
}
