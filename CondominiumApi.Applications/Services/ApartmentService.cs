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
        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public async Task<List<ApartmentViewModel>> GetAll()
        {
            var apartments = await _apartmentRepository.GetAllWithIncludeAsync();
            var apartmentsResults = new List<ApartmentViewModel>();

            foreach (var apartment in apartments)
            {
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
                apartmentsResults.Add(apartmentResult);
            }

            return apartmentsResults;
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
