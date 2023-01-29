﻿using CondominiumApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Principal;

namespace UserApi.Infrastructure.Data.Configurations.EntityConfigurations
{
    public class BlockConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {                    
            builder.ToTable("Block", "Condominium")
                .HasComment("Tabela de Bloco de apartamentos");

            #region PrimaryKey

            builder
                .HasKey(block => block.Id)
                .HasName("PK_Block");

            builder
                .Property(block => block.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasComment("Chave Primária");

            #endregion

            #region Constrainsts

            builder.Property(block => block.Name)
                .IsRequired()
                .HasColumnName("Block")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2)
                .HasComment("Bloco por Apartamento");

            #endregion

            #region Indexes

            builder
                .HasIndex(block => block.Name, "IX_Block")
                .IsUnique();

            #endregion

            #region PopulationData

            builder.HasData(
            new Block
            {
                Id = 1,
                Name = "A"
            },
            new Block
            {
                Id = 2,
                Name = "B"
            },
            new Block
            {
                Id = 3,
                Name = "C"
            });

            #endregion
        }
    }
}
