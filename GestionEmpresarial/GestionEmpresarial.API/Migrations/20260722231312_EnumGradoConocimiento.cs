using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEmpresarial.API.Migrations
{
    /// <inheritdoc />
    public partial class EnumGradoConocimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grado",
                table: "Tecnico_Conocimientos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Grado",
                table: "Tecnico_Conocimientos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
