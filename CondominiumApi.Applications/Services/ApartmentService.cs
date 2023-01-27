using CondominiumApi.Applications.Dtos.ValueObjects;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
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
        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public Task<ApartmentViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ApartmentViewModel> GetByIdWithInclude(int idApartment)
        {
            var apartment = await _apartmentRepository.GetByIdWithIncludeAsync(idApartment);
            
            var owner = new NameValueObject
            {
                First_Name = apartment.Owner?.First_Name,
                Last_Name = apartment.Owner?.Last_Name,
            };

            var resident = new NameValueObject
            {
                First_Name = apartment.Resident?.First_Name,
                Last_Name = apartment.Resident?.Last_Name,
            };

            var apartmentResult = new ApartmentViewModel
            {
                Id = apartment.Id,
                Number = apartment.Number,
                Block = apartment.BlockOfApartment.Block,
                Owner = owner,
                Resident = resident,
            };

            return apartmentResult;
        }
    }
}
