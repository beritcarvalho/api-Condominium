using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominiumApi.Infrastructure.Data.Migrations
{
    public partial class addindexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Plate",
                schema: "Condominium",
                table: "Brand",
                newName: "Brand_Name");

            migrationBuilder.AlterColumn<string>(
                name: "Brand_Name",
                schema: "Condominium",
                table: "Brand",
                type: "NVARCHAR(30)",
                maxLength: 30,
                nullable: false,
                comment: "Marca do veiculo",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(30)",
                oldMaxLength: 30,
                oldComment: "Placa do veículo");

            migrationBuilder.CreateIndex(
                name: "IX_Teste",
                schema: "Condominium",
                table: "ApartmentsVehicles",
                columns: new[] { "VehicleId", "ApartmentId" },
                unique: true,
                filter: "[Active] = 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teste",
                schema: "Condominium",
                table: "ApartmentsVehicles");

            migrationBuilder.RenameColumn(
                name: "Brand_Name",
                schema: "Condominium",
                table: "Brand",
                newName: "Plate");

            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                schema: "Condominium",
                table: "Brand",
                type: "NVARCHAR(30)",
                maxLength: 30,
                nullable: false,
                comment: "Placa do veículo",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(30)",
                oldMaxLength: 30,
                oldComment: "Marca do veiculo");
        }
    }
}
