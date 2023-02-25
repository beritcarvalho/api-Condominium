using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<VehicleViewModel>> GetAll()
        {
            var vehicles = await _vehicleRepository.GetAllWithInclusions();

            var vehiclesResults = new List<VehicleViewModel>();

            foreach(var vehicle in vehicles) 
            {
                vehiclesResults.Add(_mapper.Map<VehicleViewModel>(vehicle));
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
