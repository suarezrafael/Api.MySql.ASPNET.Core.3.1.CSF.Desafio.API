using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSF.Desafio.API.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CIDADE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(maxLength: 100, nullable: false),
                    ESTADO = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CIDADE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENTE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    RG = table.Column<string>(maxLength: 20, nullable: false),
                    CPF = table.Column<string>(maxLength: 20, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    TELEFONE = table.Column<string>(maxLength: 20, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 150, nullable: true),
                    COD_EMPRESA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RUA = table.Column<string>(maxLength: 255, nullable: false),
                    BAIRRO = table.Column<string>(maxLength: 50, nullable: false),
                    NUMERO = table.Column<string>(maxLength: 50, nullable: false),
                    COMPLEMENTO = table.Column<string>(maxLength: 100, nullable: false),
                    CEP = table.Column<string>(maxLength: 10, nullable: false),
                    TIPO_ENDERECO = table.Column<int>(nullable: false),
                    TB_CIDADE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_ENDERECO_TB_CIDADE_TB_CIDADE_ID",
                        column: x => x.TB_CIDADE_ID,
                        principalTable: "TB_CIDADE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENTE_ENDERECO",
                columns: table => new
                {
                    TB_CLIENTE_ID = table.Column<int>(nullable: false),
                    TB_ENDERECO_ID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE_ENDERECO", x => new { x.TB_CLIENTE_ID, x.TB_ENDERECO_ID });
                    table.ForeignKey(
                        name: "FK_TB_CLIENTE_ENDERECO_TB_CLIENTE_TB_CLIENTE_ID",
                        column: x => x.TB_CLIENTE_ID,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CLIENTE_ENDERECO_TB_ENDERECO_TB_ENDERECO_ID",
                        column: x => x.TB_ENDERECO_ID,
                        principalTable: "TB_ENDERECO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_CIDADE",
                columns: new[] { "ID", "ESTADO", "NOME" },
                values: new object[,]
                {
                    { 1, "RS", "Santa Cruz do Sul" },
                    { 2, "RS", "Vera Cruz" }
                });

            migrationBuilder.InsertData(
                table: "TB_CLIENTE",
                columns: new[] { "ID", "COD_EMPRESA", "CPF", "DATA_NASCIMENTO", "EMAIL", "NOME", "RG", "TELEFONE" },
                values: new object[,]
                {
                    { 1, 1, "01552764095", new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "rafaelv_s@hotmail.com", "Rafael Vieira Suarez", "6096800117", "51999708050" },
                    { 2, 1, "00460801040", new DateTime(1987, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "caroline_splett@gmail.com", "Caroline Seer Splett", "6096800618", "51996013891" }
                });

            migrationBuilder.InsertData(
                table: "TB_ENDERECO",
                columns: new[] { "ID", "BAIRRO", "CEP", "TB_CIDADE_ID", "COMPLEMENTO", "NUMERO", "RUA", "TIPO_ENDERECO" },
                values: new object[] { 1, "Ana Nery", "96835422", 1, "150 m", "3322", "Euclides Kliemann", 1 });

            migrationBuilder.InsertData(
                table: "TB_ENDERECO",
                columns: new[] { "ID", "BAIRRO", "CEP", "TB_CIDADE_ID", "COMPLEMENTO", "NUMERO", "RUA", "TIPO_ENDERECO" },
                values: new object[] { 2, "Centro", "96835344", 2, "456 A", "3322", "Euclides Kliemann", 2 });

            migrationBuilder.InsertData(
                table: "TB_CLIENTE_ENDERECO",
                columns: new[] { "TB_CLIENTE_ID", "TB_ENDERECO_ID", "ID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_CLIENTE_ENDERECO",
                columns: new[] { "TB_CLIENTE_ID", "TB_ENDERECO_ID", "ID" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTE_ENDERECO_TB_ENDERECO_ID",
                table: "TB_CLIENTE_ENDERECO",
                column: "TB_ENDERECO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_TB_CIDADE_ID",
                table: "TB_ENDERECO",
                column: "TB_CIDADE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLIENTE_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_CLIENTE");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_CIDADE");
        }
    }
}
