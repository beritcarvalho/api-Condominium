using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
using CondominiumApi.Domain.Enums.CondominiumApi.Domain.Enums;
using CondominiumApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<VehicleViewModel>> GetAll()
        {
            var vehicles = await _vehicleRepository.GetAllWithInclusions();

            var vehiclesResults = new List<VehicleViewModel>();

            foreach(var vehicle in vehicles) 
            {
                vehiclesResults.Add(new VehicleViewModel
                {
                    Id = vehicle.Id,
                    Plate = vehicle.Plate,
                    Model = vehicle.VehicleModel.Model_Name,
                    Brand = vehicle.VehicleModel.Brand.Brand_Name,
                    Vehicle_Type = ((EVehicleType)vehicle.Vehicle_Type).ToString(),
                    Handicap = vehicle.Handicap,
                    Create_Date = vehicle.Create_Date,
                    Last_Update_Date = vehicle.Last_Update_Date
                });
            }

            return vehiclesResults;
        }

        public async Task<VehicleViewModel> GetVehicle()
        {
            var list = await _vehicleRepository.GetAllWithInclusions();

            var listView = new List<VehicleViewModel>();
            foreach (var vehicle in list)
            {
                listView.Add(new VehicleViewModel
                {
                    Id = vehicle.Id
                });
            }

            return null;
        }
    }
}
