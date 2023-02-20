using CondominiumApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Infrastructure.Data.Configurations.EntityConfigurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand", "Condominium")
             .HasComment("Tabela de marcas de veiculos");

            #region PrimaryKey

            builder
                .HasKey(brand => brand.Id)
                .HasName("PK_Brand");

            #endregion            

            #region Constrainsts

            builder.Property(brand => brand.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnType("INT")
                .HasComment("Chave Primária");

            builder.Property(brand => brand.Brand_Name)
                .IsRequired()
                .HasColumnName("Plate")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(30)
                .HasComment("Placa do veículo");

            #endregion

            #region Indexes          

            builder.HasIndex(brand => brand.Brand_Name, "IX_Brand_Name")
                .IsUnique();

            #endregion
        }
    }
}
