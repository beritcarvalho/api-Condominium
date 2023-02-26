using CondominiumApi.Domain.Entities;
using CondominiumApi.Domain.Interfaces;
using CondominiumApi.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Infrastructure.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<List<Vehicle>> GetAllWithInclusions()
        {
            return await Context.Vehicles
                .Include(brad => brad.VehicleModel.Brand)
                .ToListAsync();            
        }

        public async Task<Vehicle> GetVehicleWithInclusions(decimal id)
        {
            return await Context.Vehicles
                .Where(vehicle => vehicle.Id == id)
                .Include(brad => brad.VehicleModel.Brand)
                .FirstAsync();
        }

        public async Task<Vehicle> GetVehicleWithInclusions(string plate)
        {
            return await Context.Vehicles
                .Where(vehicle => vehicle.Plate == plate)
                .Include(vehicle => vehicle.VehicleModel.Brand)
                .FirstAsync();
        }
    }
}
