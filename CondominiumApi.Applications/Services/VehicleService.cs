using AutoMapper;
using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
using CondominiumApi.Domain.Entities;
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
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public VehicleService(IMapper mapper, 
            IVehicleRepository vehicleRepository,
            IApartmentRepository apartmentRepository,
            IVehicleModelRepository vehicleModelRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _apartmentRepository = apartmentRepository;
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<List<VehicleViewModel>> GetAllVehicles()
        {
            var vehicles = await _vehicleRepository.GetAllWithInclusions();

            if (vehicles is null)
                return null;

            var vehiclesResults = new List<VehicleViewModel>();

            foreach(var vehicle in vehicles) 
            {
                vehiclesResults.Add(_mapper.Map<VehicleViewModel>(vehicle));
            }

            return vehiclesResults;
        }

        public async Task<VehicleViewModel> GetVehicle(decimal? id, string? plate)
        {
            Vehicle? vehicle = null;  

            if (id is not null)
                vehicle = await _vehicleRepository.GetVehicleWithInclusions((decimal)id);
            else if(plate is not null)
                vehicle = await _vehicleRepository.GetVehicleWithInclusions(plate);

            if (vehicle is null)
                return null;

            var result = _mapper.Map<VehicleViewModel>(vehicle);

            return result;
        }

        public async Task<VehicleViewModel> AddVehicle(VehicleInputModel newVehicle)
        {
            var vehicle = _mapper.Map<Vehicle>(newVehicle);
            vehicle.Create_Date = DateTime.Now;
            vehicle.Last_Update_Date = DateTime.Now;
            await _vehicleRepository.InsertAsync(vehicle);
            return _mapper.Map<VehicleViewModel>(vehicle);        
        }

        public async Task<VehicleViewModel> UpdateVehicle(VehicleInputModel currentVehicleData)        
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(currentVehicleData.Id);

            if (vehicle is null)
                return null;
            
            vehicle = _mapper.Map(currentVehicleData, vehicle);
            vehicle.Last_Update_Date = DateTime.Now;
            await _vehicleRepository.UpdateAsync(vehicle);
            return _mapper.Map<VehicleViewModel>(vehicle);
        }


        public async Task<VehicleViewModel> GetVehicleAparment(decimal? id, string? plate)
        {
            Vehicle? vehicle = null;

            if (id is not null)
                vehicle = await _vehicleRepository.GetVehicleWithInclusions((decimal)id);
            else if (plate is not null)
                vehicle = await _vehicleRepository.GetVehicleWithInclusions(plate);

            if (vehicle is null)
                return null;

            var amr = vehicle.ApartmentsVehicles.FirstOrDefault(vehi => vehi.Active);

            if (amr is null)
                return null;


            var apart = await _apartmentRepository.GetByIdWithInclusions(amr.ApartmentId);

            var result = _mapper.Map<VehicleViewModel>(vehicle);

            //result.Apartment = $"{apart.Number}-{apart.Block.Block_Name}";

            return result;
        }

        public async Task<List<VehicleModelViewModel>> GetAllModels()
        {
            var models = await _vehicleModelRepository.GetAllAsync();

            if (models is null)
                return null;

            var modelsResult = new List<VehicleModelViewModel>();

            foreach (var model in models)
                modelsResult.Add(_mapper.Map<VehicleModelViewModel>(model));

            return modelsResult;
        }

        public async Task<VehicleModelViewModel> GetModel(int id)
        {
            var model = await _vehicleModelRepository.GetByIdAsync(id);

            if (model is null)
                return null;

            return _mapper.Map<VehicleModelViewModel>(model);
        }

        public async Task<VehicleModelViewModel> AddModel(VehicleModelInputModel newModel)
        {
            var model = _mapper.Map<VehicleModel>(newModel);
            await _vehicleModelRepository.InsertAsync(model);
            return _mapper.Map<VehicleModelViewModel>(model);
        }

        public async Task<VehicleModelViewModel> UpdateModel(VehicleModelInputModel currentModeleData)
        {
            var model = await _vehicleModelRepository.GetByIdAsync(currentModeleData.Id);

            if (model is null)
                return null;

            model = _mapper.Map(currentModeleData, model);

            await _vehicleModelRepository.UpdateAsync(model);

            return _mapper.Map<VehicleModelViewModel>(model);
        }
    }
}
