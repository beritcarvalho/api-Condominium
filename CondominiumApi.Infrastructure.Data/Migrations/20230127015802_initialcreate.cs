using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominiumApi.Infrastructure.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Condominium");

            migrationBuilder.CreateTable(
                name: "Block",
                schema: "Condominium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Chave Primária da tabela de blocos de apartamento \"Block\"")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Block = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: false, comment: "Bloco por Apartamento")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.Id);
                },
                comment: "Tabela de Bloco de apartamentos");

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Condominium",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave Primária da tabela de pessoas \"Person\""),
                    First_Name = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false, comment: "Nome"),
                    Last_Name = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false, comment: "Sobrenome"),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false, comment: "CPF"),
                    Phone = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false, comment: "Telefone para contato"),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false, comment: "Email"),
                    Create_Date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()", comment: "Data de Criação do Cadastro"),
                    Last_Update_Date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()", comment: "Ultima atualização do cadastro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                },
                comment: "Tabela de Pessoas Cadastradas");

            migrationBuilder.CreateTable(
                name: "Apartment",
                schema: "Condominium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Chave Primária da tabela de apartamento \"Apartment\"")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "INT", nullable: false, comment: "Numero do Apartamento"),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave da tabela de Pessoa"),
                    ResidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Chave da tabela de Pessoa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_Block_BlockId",
                        column: x => x.BlockId,
                        principalSchema: "Condominium",
                        principalTable: "Block",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartment_Owner_PersonId",
                        column: x => x.OwnerId,
                        principalSchema: "Condominium",
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartment_Resident_PersonId",
                        column: x => x.ResidentId,
                        principalSchema: "Condominium",
                        principalTable: "Person",
                        principalColumn: "Id");
                },
                comment: "Tabela de Apartamentos");

            migrationBuilder.InsertData(
                schema: "Condominium",
                table: "Block",
                columns: new[] { "Id", "Block" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" }
                });

            migrationBuilder.InsertData(
                schema: "Condominium",
                table: "Person",
                columns: new[] { "Id", "Cpf", "Email", "First_Name", "Last_Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("495dadfc-add1-4826-bde8-828c9b0c0134"), "22233344455", "lux@stemmaguarda.com", "Lux", "Stemmaguarda", "11987654322" },
                    { new Guid("59de6d3b-2002-42fa-80e3-057f2cfc5cae"), "22233344456", "annie@hastur.com", "Annie", "Hastur", "11987654322" },
                    { new Guid("5a7a5658-ccbc-4451-b4bc-5a0264bd0a81"), "11122233344", "garen@stemmaguarda.com", "Garen", "Stemmaguarda", "11987654322" },
                    { new Guid("6fd401e3-fb52-4eed-b7df-28c99753ae55"), "0124567890", "admin@admin.com", "Admin", "System", "11987654321" },
                    { new Guid("e69cb7b8-164c-41ed-a670-7b40480c3887"), "33344455566", "ashe@avarosa.com", "Ashe", "Avarosa", "11987654323" }
                });

            migrationBuilder.InsertData(
                schema: "Condominium",
                table: "Apartment",
                columns: new[] { "Id", "BlockId", "Number", "OwnerId", "ResidentId" },
                values: new object[] { 1, 1, 1, new Guid("5a7a5658-ccbc-4451-b4bc-5a0264bd0a81"), null });

            migrationBuilder.InsertData(
                schema: "Condominium",
                table: "Apartment",
                columns: new[] { "Id", "BlockId", "Number", "OwnerId", "ResidentId" },
                values: new object[] { 2, 2, 1, new Guid("495dadfc-add1-4826-bde8-828c9b0c0134"), new Guid("495dadfc-add1-4826-bde8-828c9b0c0134") });

            migrationBuilder.InsertData(
                schema: "Condominium",
                table: "Apartment",
                columns: new[] { "Id", "BlockId", "Number", "OwnerId", "ResidentId" },
                values: new object[] { 3, 1, 2, new Guid("59de6d3b-2002-42fa-80e3-057f2cfc5cae"), new Guid("e69cb7b8-164c-41ed-a670-7b40480c3887") });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_Block",
                schema: "Condominium",
                table: "Apartment",
                columns: new[] { "Number", "BlockId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_BlockId",
                schema: "Condominium",
                table: "Apartment",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_OwnerId",
                schema: "Condominium",
                table: "Apartment",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_ResidentId",
                schema: "Condominium",
                table: "Apartment",
                column: "ResidentId",
                unique: true,
                filter: "[ResidentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Block",
                schema: "Condominium",
                table: "Block",
                column: "Block",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Cpf",
                schema: "Condominium",
                table: "Person",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                schema: "Condominium",
                table: "Person",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartment",
                schema: "Condominium");

            migrationBuilder.DropTable(
                name: "Block",
                schema: "Condominium");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Condominium");
        }
    }
}
