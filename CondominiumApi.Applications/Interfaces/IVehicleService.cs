using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Interfaces
{
    public interface IVehicleService
    {
        Task<List<VehicleViewModel>> GetAll();
        Task<VehicleViewModel> GetVehicle(decimal? id, string? plate);
        Task<VehicleViewModel> AddVehicle(VehicleInputModel newVehicle);
        Task<VehicleViewModel> UpdateVehicle(VehicleInputModel currentVehicleData);
    }
}
