using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominiumApi.Infrastructure.Data.Migrations
{
    public partial class addindexess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicle_Apartment",
                schema: "Condominium",
                table: "ApartmentsVehicles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Apartment",
                schema: "Condominium",
                table: "ApartmentsVehicles",
                columns: new[] { "VehicleId", "ApartmentId" },
                unique: true);
        }
    }
}
