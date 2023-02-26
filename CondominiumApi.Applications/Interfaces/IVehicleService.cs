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
        Task<List<VehicleViewModel>> GetAllVehicles();
        Task<VehicleViewModel> GetVehicle(decimal? id, string? plate);
        Task<VehicleViewModel> AddVehicle(VehicleInputModel newVehicle);
        Task<VehicleViewModel> UpdateVehicle(VehicleInputModel currentVehicleData);
        Task<List<VehicleModelViewModel>> GetAllModels();
        Task<VehicleModelViewModel> GetModel(int id);
        Task<VehicleModelViewModel> AddModel(VehicleModelInputModel newModel);
        Task<VehicleModelViewModel> UpdateModel(VehicleModelInputModel currentModeleData);
        Task<List<BrandViewModel>> GetAllBrands();
        Task<BrandViewModel> GetBrand(int id);
        Task<BrandViewModel> AddBrand(BrandInputModel newModel);
        Task<BrandViewModel> UpdateBrand(BrandInputModel currentModeleData);
    }
}
