using CondominiumApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Principal;

namespace UserApi.Infrastructure.Data.Configurations.EntityConfigurations
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartment", "Condominum")
                .HasComment("Tabela de Apartamentos");

            #region PrimaryKey

            builder
                .HasKey(apart => apart.Id)
                .HasName("PK_Apartment");

            builder
                .Property(apart => apart.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasComment(@"Chave Primária da tabela de apartamento ""Apartment""");

            #endregion

            #region ForeignKey
            
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
                .HasOne(apart => apart.Block)
                .WithMany(block => block.Apartments)
                .HasForeignKey(apart => apart.BlockId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Constrainsts

            builder.Property(apart => apart.Number)
                .IsRequired()
                .HasColumnName("Number")
                .HasColumnType("INT")
                .HasComment("Numero do Apartamento");

            builder.Property(apart => apart.OwnerId)
                .IsRequired()
                .HasComment("Chave da tabela de Pessoa");

            builder.Property(apart => apart.ResidentId)
                .HasComment("Chave da tabela de Pessoa");

            #endregion

            #region Indexes

            builder.HasIndex(apart => apart.OwnerId, "IX_Apartment_OwnerId")
                .IsUnique();

            builder.HasIndex(apart => apart.ResidentId, "IX_Apartment_ResidentId")
                .IsUnique();


            builder.HasIndex(apart => new {apart.Number, apart.BlockId}, "IX_Apartment_Block")
                .IsUnique();

            #endregion

            #region PopulationData

            builder.HasData(
                new Apartment
                {
                    Id = 1,
                    Number = 1,
                    BlockId = 1,
                    OwnerId = Guid.Parse("6fd401e3-fb52-4eed-b7df-28c99753ae55")
                });

            #endregion

        }
    }
}
