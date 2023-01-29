using CondominiumApi.Domain.Entities;
using CondominiumApi.Infrastructure.Data.Configurations.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Infrastructure.Data.Configurations.EntityConfigurations;

namespace CondominiumApi.Infrastructure.Data.Contexts
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<BlockOfApartment> Blocks{ get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new ApartmentConfiguration());
            builder.ApplyConfiguration(new BlockConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
        }
    }
}
