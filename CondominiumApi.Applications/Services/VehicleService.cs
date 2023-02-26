using AutoMapper;
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

        public VehicleService(IMapper mapper, 
            IVehicleRepository vehicleRepository,
            IApartmentRepository apartmentRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<List<VehicleViewModel>> GetAll()
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
    }
}
