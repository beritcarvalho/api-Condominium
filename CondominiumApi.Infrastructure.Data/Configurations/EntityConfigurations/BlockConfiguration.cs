using CondominiumApi.Domain.Entities;
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
        }
    }
}
