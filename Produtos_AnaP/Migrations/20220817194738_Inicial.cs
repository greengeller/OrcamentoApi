using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrcamentoApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendedorId = table.Column<int>(type: "int", nullable: false),
                    ProdutosId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrcamentoId = table.Column<int>(type: "int", nullable: true),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    VendedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkDTO_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkDTO_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkDTO_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkDTO_OrcamentoId",
                table: "LinkDTO",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkDTO_ProdutosId",
                table: "LinkDTO",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkDTO_VendedorId",
                table: "LinkDTO",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_ProdutosId",
                table: "Orcamentos",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_VendedorId",
                table: "Orcamentos",
                column: "VendedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkDTO");

            migrationBuilder.DropTable(
                name: "Orcamentos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
