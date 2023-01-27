﻿using CondominiumApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Principal;

namespace UserApi.Infrastructure.Data.Configurations.EntityConfigurations
{
    public class BlockConfiguration : IEntityTypeConfiguration<BlockOfApartment>
    {
        public void Configure(EntityTypeBuilder<BlockOfApartment> builder)
        {                    
            builder.ToTable("Block", "Condominum")
                .HasComment("Tabela de Bloco de apartamentos");

            #region PrimaryKey

            builder
                .HasKey(person => person.Id)
                .HasName("PK_Block");

            builder
                .Property(person => person.Id)
                .ValueGeneratedOnAdd()
                .HasComment(@"Chave Primária da tabela de blocos de apartamento ""Block""");

            #endregion

            #region Constrainsts

            builder.Property(person => person.Block)
                .IsRequired()
                .HasColumnName("Block")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2)
                .HasComment("Bloco por Apartamento");

            #endregion

            #region Indexes

            builder
                .HasIndex(person => person.Block, "IX_Block")
                .IsUnique();

            #endregion

            #region PopulationData

            builder.HasData(
            new BlockOfApartment
            {
                Id = 1,
                Block = "A"
            },
            new BlockOfApartment
            {
                Id = 2,
                Block = "B"
            },
            new BlockOfApartment
            {
                Id = 3,
                Block = "C"
            });

            #endregion
        }
    }
}
