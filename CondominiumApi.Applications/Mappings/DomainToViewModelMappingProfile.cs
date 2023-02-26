using AutoMapper;
using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ValueObjects;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Domain.Entities;
using CondominiumApi.Domain.Enums.CondominiumApi.Domain.Enums;
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
            #region Person
            
            CreateMap<Person, PersonViewModel>();      
            CreateMap<PersonInputModel, Person>();
            CreateMap<PersonUpdateInputModel, Person>();

            #endregion

            #region Apartment

            CreateMap<Apartment, ApartmentViewModel>()
                .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.Block.Block_Name))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(
                    src => new NameValueObject { First_Name = src.Owner.First_Name, Last_Name = src.Owner.Last_Name }))
                .ForMember(dest => dest.Resident, opt => opt.MapFrom(
                    src => new NameValueObject { First_Name = src.Resident.First_Name, Last_Name = src.Resident.Last_Name }));

            #endregion

            #region Vehicle

            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.VehicleModel.Model_Name))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.VehicleModel.Brand.Brand_Name))
                .ForMember(dest => dest.Vehicle_Type, opt => opt.MapFrom(src => ((EVehicleType)src.Vehicle_Type).ToString()));

            CreateMap<VehicleInputModel, Vehicle>()
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate.ToUpper()));

            #endregion

        }

    }
}
