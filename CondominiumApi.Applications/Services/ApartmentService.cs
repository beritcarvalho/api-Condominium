using AutoMapper;
using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ValueObjects;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
using CondominiumApi.Domain.Entities;
using CondominiumApi.Domain.Exceptions;
using CondominiumApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
            try
            {
                var apartments = await _apartmentRepository.GetAllWithInclude();

                if (apartments == null)
                    return null;

                var apartmentsResult = new List<ApartmentViewModel>();

                foreach (var apartment in apartments)
                {
                    var apartmentViewModel = _mapper.Map<ApartmentViewModel>(apartment);
                    apartmentsResult.Add(apartmentViewModel);
                }

                return apartmentsResult;
            }
            catch
            {
                throw new Exception("ERR-APSX01 Falha interna no servidor");
            }
        }

        public async Task<ApartmentViewModel> GetByIdWithInclude(int idApartment)
        {
            try
            {
                var apartment = await _apartmentRepository.GetByIdWithInclude(idApartment);

                if (apartment == null)
                    return null;

                var apartmentResult = _mapper.Map<ApartmentViewModel>(apartment);

                return apartmentResult;
            }
            catch
            {
                throw new Exception("ERR-APSX02 Falha interna no servidor");
            }
        }

        public async Task<ApartmentViewModel> InsertNewApartment(ApartmentInputModel newApartment)
        {
            try
            {
                var apartment = new Apartment();

                var idBlock = GetIdBlockOfApartment(newApartment.Block);
                
                if (idBlock == null)
                    throw new NotFoundException("ERR-APSX01 O Bloco informado não foi encontrado");

                apartment.BlockId = (int)idBlock;
                apartment.Number = newApartment.Number;
                apartment.Create_Date = DateTime.Now;
                apartment.Last_Update_Date = DateTime.Now;

                apartment = await IncludeOwnerResidentDataAsync(apartment, newApartment.OwnerCPF, newApartment.ResidentCPF);

                await _apartmentRepository.InsertAsync(apartment);

                var apartmentResult = _mapper.Map<ApartmentViewModel>(apartment);

                return apartmentResult;
            }
            catch(ValidationException validationException)
            {
                throw validationException;
            }
            catch (NotFoundException exception)
            {
                throw exception;
            }
            catch (DbException exception)
            {
                throw new Exception("ERR-APSX01 Não foi possível cadastrar o apartamento");
            }
            catch
            {
                throw new Exception("ERR-APSX03 Falha interna no servidor");
            }
        }

        public async Task<ApartmentViewModel> ResetApartmentData(ApartmentInputModel newApartment)
        {
            var idBlock = GetIdBlockOfApartment(newApartment.Block);

            if (idBlock == null)
                return null;

            var apartment = await _apartmentRepository.GetByNumberAndBlockWithInclude(newApartment.Number, (int)idBlock);

            if (apartment == null)
                return null;

            apartment.Owner = null;
            apartment.Resident = null;
            apartment.Last_Update_Date = DateTime.Now;

            await _apartmentRepository.UpdateAsync(apartment);

            return _mapper.Map<ApartmentViewModel>(apartment);
        }

        public async Task<ApartmentViewModel> UpdateApartment(ApartmentInputModel newApartment)
        {
            var idBlock = GetIdBlockOfApartment(newApartment.Block);

            if (idBlock == null)
                return null;

            var apartment = await _apartmentRepository.GetByNumberAndBlockWithInclude(newApartment.Number, (int)idBlock);

            if (apartment == null)
                return null;

            apartment = apartment = await IncludeOwnerResidentDataAsync(apartment, newApartment.OwnerCPF, newApartment.ResidentCPF);

            apartment.Last_Update_Date = DateTime.Now;
      
            await _apartmentRepository.UpdateAsync(apartment);

            return _mapper.Map<ApartmentViewModel>(apartment);
        }

        private int? GetIdBlockOfApartment(string block)
        {
            block = block.ToUpper();
            switch (block)
            {
                case "A": return 1; break;
                case "B": return 2; break;
                case "C": return 3; break;
                default: return null; break;
            }
        }

        private async Task<Apartment> IncludeOwnerResidentDataAsync(Apartment apartment, string? OwnerCPF, string? ResidentCPF)
        {
            if (apartment.Owner != null && OwnerCPF == null)
                throw new ValidationException("O apartamento informado não tem proprietário");

            if (OwnerCPF != null)
            {
                var owner = await _personRepository.GetPersonByCPF(OwnerCPF);
                
                if (owner == null)
                    throw new NotFoundException("O proprietário informado não foi encontrado");

                apartment.Owner = new Person();
                apartment.Owner = owner;
            }

            if (OwnerCPF == null && ResidentCPF != null)
                throw new ValidationException("Para atribuir morador é obrigatório informar o proprietário!");

            if (ResidentCPF == null)
            {
                apartment.Resident = null;
            }

            if (ResidentCPF != null)
            {
                var resident = await _personRepository.GetPersonByCPF(ResidentCPF);
                
                if (resident == null)
                    throw new NotFoundException("O proprietário informado não foi encontrado");

                apartment.Resident = new Person();
                apartment.Resident = resident;
            }

            return apartment;
        }
    }
}
