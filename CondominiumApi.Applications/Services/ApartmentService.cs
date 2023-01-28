using AutoMapper;
using CondominiumApi.Applications.Dtos.InputModels;
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
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBlockRepository _blockRepository;
        private readonly IPersonRepository _personRepository;
        
        public ApartmentService(IMapper mapper,
            IApartmentRepository apartmentRepository,
            IBlockRepository blockRepository,
            IPersonRepository personRepository)
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
            _blockRepository = blockRepository;
            _personRepository = personRepository;
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

        public async Task<ApartmentViewModel> InsertNewApartment(ApartmentInputModel newApartment)
        {
            var apartment = new Apartment();
            
            var idBlock = GetIdBlockOfApartment(newApartment.Block.ToUpper());

            if (idBlock == null)
                return null;

            apartment.BlockId = (int)idBlock;

            apartment.Number = newApartment.Number;

            if (newApartment.OwnerCPF != null)
            {
                var owner = await _personRepository.GetPersonByCPF(newApartment.OwnerCPF);
                if (owner == null)
                    return null;

                apartment.Owner = owner;
            }

            if (newApartment.OwnerCPF == null && newApartment.ResidentCPF != null)
                return null;

            if (newApartment.ResidentCPF != null)
            {
                var resident = await _personRepository.GetPersonByCPF(newApartment.ResidentCPF);
                if (resident == null)
                    return null;

                apartment.Resident = resident;
            }          

            await _apartmentRepository.InsertAsync(apartment);

            var apartmentResult = _mapper.Map<ApartmentViewModel>(apartment);

            return apartmentResult;
        }

        private int? GetIdBlockOfApartment(string block)
        {
            switch (block)
            {
                case "A": return 1; break;
                case "B": return 2; break;
                case "C": return 3; break;
                default: return null; break;
            }
        }
    }
}
