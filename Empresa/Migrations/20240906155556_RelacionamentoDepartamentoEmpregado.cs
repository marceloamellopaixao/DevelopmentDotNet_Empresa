using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoDepartamentoEmpregado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empregados_PX_Departamentos_PX_DepartamentoId",
                table: "Empregados_PX");

            migrationBuilder.DropIndex(
                name: "IX_Empregados_PX_DepartamentoId",
                table: "Empregados_PX");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Empregados_PX_DepartamentoId",
                table: "Empregados_PX",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empregados_PX_Departamentos_PX_DepartamentoId",
                table: "Empregados_PX",
                column: "DepartamentoId",
                principalTable: "Departamentos_PX",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
