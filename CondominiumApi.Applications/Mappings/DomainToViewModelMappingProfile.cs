using AutoMapper;
using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ValueObjects;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region Mapeamento Person
            
            CreateMap<Person, PersonViewModel>();      
            CreateMap<PersonInputModel, Person>();
            CreateMap<PersonUpdateInputModel, Person>();

            #endregion

            #region Mapeamento Apartment

            CreateMap<Apartment, ApartmentViewModel>()
                .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.BlockOfApartment.Block))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(
                    src => new NameValueObject { First_Name = src.Owner.First_Name, Last_Name = src.Owner.Last_Name }))
                .ForMember(dest => dest.Resident, opt => opt.MapFrom(
                    src => new NameValueObject { First_Name = src.Resident.First_Name, Last_Name = src.Resident.Last_Name }));

            #endregion
        }

    }
}
