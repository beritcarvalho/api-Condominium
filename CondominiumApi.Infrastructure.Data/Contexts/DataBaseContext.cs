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
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<BlockOfApartment> Blocks{ get; set; }        
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleModel> VehiclesModels { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ApartmentVehicle> ApartmentsVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new ApartmentConfiguration());
            builder.ApplyConfiguration(new BlockConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new VehicleModelConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new ApartmentVehicleConfiguration());
        }
    }
}
