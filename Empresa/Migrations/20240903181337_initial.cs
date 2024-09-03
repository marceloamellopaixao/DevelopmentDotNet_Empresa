using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos_PX",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DepartamentoNome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos_PX", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Empregados_PX",
                columns: table => new
                {
                    EmpregadoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Genero = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FotoUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DepartamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregados_PX", x => x.EmpregadoId);
                    table.ForeignKey(
                        name: "FK_Empregados_PX_Departamentos_PX_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos_PX",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empregados_PX_DepartamentoId",
                table: "Empregados_PX",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empregados_PX");

            migrationBuilder.DropTable(
                name: "Departamentos_PX");
        }
    }
}
