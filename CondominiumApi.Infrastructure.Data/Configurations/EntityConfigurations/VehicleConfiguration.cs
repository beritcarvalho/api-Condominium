using CondominiumApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Infrastructure.Data.Configurations.EntityConfigurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle", "Condominium")
                .HasComment("Tabela de veiculos do condomínio");

            #region PrimaryKey

            builder
                .HasKey(vehicle => vehicle.Id)
                .HasName("PK_Vehicle");

            #endregion

            #region ForeignKey
            /*
            builder
                .HasOne(apart => apart.Owner)
                .WithOne(person => person.ApartmentOwner)
                .HasForeignKey<Apartment>(apart => apart.OwnerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Apartment_Owner_PersonId");

            builder.HasOne(apart => apart.Resident)
                .WithOne(person => person.ApartmentResident)
                .HasForeignKey<Apartment>(apart => apart.ResidentId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Apartment_Resident_PersonId");

            builder
                .HasOne(apart => apart.BlockOfApartment)
                .WithMany(block => block.Apartments)
                .HasForeignKey(apart => apart.BlockId)
                .OnDelete(DeleteBehavior.NoAction);*/


            #endregion

            #region Constrainsts

            builder.Property(vehicle => vehicle.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnType("DECIMAL(6,0)")
                .HasComment("Chave Primária");

            builder.Property(vehicle => vehicle.Plate)
                .IsRequired()
                .HasColumnName("Plate")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(7)
                .HasComment("Placa do veículo");

            builder.Property(apart => apart.VehicleModelId)
                .IsRequired()
                .HasComment("Chave da tabela de Model");

            builder.Property(apart => apart.ApartmentId)
                .IsRequired()
                .HasComment("Chave da tabela de Apartment");

            builder.Property(vehicle => vehicle.Create_Date)
                .IsRequired()
                .HasColumnName("Create_Date")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .HasComment("Data de cadastramento do veículo");

            builder.Property(apart => apart.Vehicle_Type)
                .IsRequired()
                .HasColumnName("Vehicle_Type")
                .HasColumnType("INT")
                .HasComment("Indica tipo de veiculo. 1 == Automóvel, 2 == Motoclicleta, 3 == Caminhão");

            builder.Property(apart => apart.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("BIT")
                .HasDefaultValueSql("0")
                .HasComment("Indica se o veículo está ativo");

            builder.Property(vehicle => vehicle.Inactive_Date)
                .HasColumnName("Inactive_Date")
                .HasColumnType("DATETIME")
                .HasComment("Data de desativação do veículo");

            builder.Property(apart => apart.Handicap)
                .IsRequired()
                .HasColumnName("Handicap")
                .HasColumnType("BIT")
                .HasDefaultValueSql("0")
                .HasComment("Indica se o veículo é adpatado para PcD");

            builder.Property(vehicle => vehicle.Last_Update_Date)
                .IsRequired()
                .HasColumnName("Last_Update_Date")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .HasComment("Ultima atualização do cadastro do veículo");

            #endregion

            #region Indexes          

            builder.HasIndex(vehicle => vehicle.Plate, "IX_Vehicle_Plate")
                .IsUnique();
             
            #endregion
        }
    }
}
