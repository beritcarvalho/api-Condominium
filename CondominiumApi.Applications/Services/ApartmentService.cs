using AutoMapper;
using CondominiumApi.Applications.Dtos.ValueObjects;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
using CondominiumApi.Domain.Entities;
using CondominiumApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<List<ApartmentViewModel>> GetAll()
        {
            var apartments = await _apartmentRepository.GetAllWithIncludeAsync();
            var apartmentsResult = new List<ApartmentViewModel>();

            foreach (var apartment in apartments)
            {
                var apartmentViewModel = _mapper.Map<ApartmentViewModel>(apartment);
                apartmentsResult.Add(apartmentViewModel);
            }

            return apartmentsResult;
        }

        public async Task<ApartmentViewModel> GetByIdWithInclude(int idApartment)
        {
            var apartment = await _apartmentRepository.GetByIdWithIncludeAsync(idApartment);

            var apartmentResult = _mapper.Map<ApartmentViewModel>(apartment);

            return apartmentResult;
        }
    }
}
