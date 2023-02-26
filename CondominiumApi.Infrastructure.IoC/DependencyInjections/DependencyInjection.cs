using CondominiumApi.Applications.Interfaces;
using CondominiumApi.Applications.Services;
using CondominiumApi.Domain.Interfaces;
using CondominiumApi.Infrastructure.Data.Contexts;
using CondominiumApi.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CondominiumApi.Infrastructure.IoC.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            #region DataBaseConnection
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            AddServices(services);
            AddRepository(services);

            return services;
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IVehicleService, VehicleService>();
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IBlockRepository, BlockRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
        }     
    }
}
