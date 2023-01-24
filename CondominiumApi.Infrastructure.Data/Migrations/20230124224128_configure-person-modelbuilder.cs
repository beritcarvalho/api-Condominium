using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominiumApi.Infrastructure.Data.Migrations
{
    public partial class configurepersonmodelbuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Condominum");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Person",
                newSchema: "Condominum");

            migrationBuilder.AlterTable(
                name: "Person",
                schema: "Condominum",
                comment: "Tabela de Pessoas Cadastradas");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "Condominum",
                table: "Person",
                type: "VARCHAR(11)",
                maxLength: 11,
                nullable: false,
                comment: "Telefone para contato",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Last_Update_Date",
                schema: "Condominum",
                table: "Person",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Ultima atualização do cadastro",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                schema: "Condominum",
                table: "Person",
                type: "NVARCHAR(30)",
                maxLength: 30,
                nullable: false,
                comment: "Sobrenome",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                schema: "Condominum",
                table: "Person",
                type: "NVARCHAR(30)",
                maxLength: 30,
                nullable: false,
                comment: "Nome",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Condominum",
                table: "Person",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                comment: "Email",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Create_Date",
                schema: "Condominum",
                table: "Person",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Data de Criação do Cadastro",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                schema: "Condominum",
                table: "Person",
                type: "VARCHAR(11)",
                maxLength: 11,
                nullable: false,
                comment: "CPF",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "Condominum",
                table: "Person",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Chave Primária da tabela de pessoas \"Person\"",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                schema: "Condominum",
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

            migrationBuilder.CreateIndex(
                name: "IX_Person_Cpf",
                schema: "Condominum",
                table: "Person",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                schema: "Condominum",
                table: "Person",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Person_Cpf",
                schema: "Condominum",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_Email",
                schema: "Condominum",
                table: "Person");

            migrationBuilder.DeleteData(
                schema: "Condominum",
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("495dadfc-add1-4826-bde8-828c9b0c0134"));

            migrationBuilder.DeleteData(
                schema: "Condominum",
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("59de6d3b-2002-42fa-80e3-057f2cfc5cae"));

            migrationBuilder.DeleteData(
                schema: "Condominum",
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("5a7a5658-ccbc-4451-b4bc-5a0264bd0a81"));

            migrationBuilder.DeleteData(
                schema: "Condominum",
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("6fd401e3-fb52-4eed-b7df-28c99753ae55"));

            migrationBuilder.DeleteData(
                schema: "Condominum",
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("e69cb7b8-164c-41ed-a670-7b40480c3887"));

            migrationBuilder.RenameTable(
                name: "Person",
                schema: "Condominum",
                newName: "Person");

            migrationBuilder.AlterTable(
                name: "Person",
                oldComment: "Tabela de Pessoas Cadastradas");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)",
                oldMaxLength: 11,
                oldComment: "Telefone para contato");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Last_Update_Date",
                table: "Person",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Ultima atualização do cadastro");

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(30)",
                oldMaxLength: 30,
                oldComment: "Sobrenome");

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(30)",
                oldMaxLength: 30,
                oldComment: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldComment: "Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Create_Date",
                table: "Person",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Data de Criação do Cadastro");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)",
                oldMaxLength: 11,
                oldComment: "CPF");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Chave Primária da tabela de pessoas \"Person\"");
        }
    }
}
