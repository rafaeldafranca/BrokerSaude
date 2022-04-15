using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrokerService.Core.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Produto = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cns = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cobertura = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Acomodacao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Validado = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    Senha = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Documento = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Numero = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    UF = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    Tipo = table.Column<int>(type: "int", unicode: false, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    DataUltimoAcesso = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Associados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Matricula = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Associados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conveniados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    PlanoId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conveniados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conveniados_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conveniados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manifestacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DataFechamento = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true),
                    StatusSolicitacao = table.Column<int>(type: "int", unicode: false, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifestacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manifestacoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Conselho = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    EspecialidadeId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestadores_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestadores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManifestacaoResposta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ManifestacaoId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestacaoResposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifestacaoResposta_Manifestacoes_ManifestacaoId",
                        column: x => x.ManifestacaoId,
                        principalTable: "Manifestacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Associados_UsuarioId",
                table: "Associados",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Conveniados_PlanoId",
                table: "Conveniados",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Conveniados_UsuarioId",
                table: "Conveniados",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestacaoResposta_ManifestacaoId",
                table: "ManifestacaoResposta",
                column: "ManifestacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifestacoes_UsuarioId",
                table: "Manifestacoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestadores_EspecialidadeId",
                table: "Prestadores",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestadores_UsuarioId",
                table: "Prestadores",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Associados");

            migrationBuilder.DropTable(
                name: "Conveniados");

            migrationBuilder.DropTable(
                name: "ManifestacaoResposta");

            migrationBuilder.DropTable(
                name: "Prestadores");

            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropTable(
                name: "Manifestacoes");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
