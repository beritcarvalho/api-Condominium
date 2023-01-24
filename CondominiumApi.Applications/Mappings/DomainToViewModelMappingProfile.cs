using AutoMapper;
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
            CreateMap<Person, PersonViewModel>()
                .ReverseMap();
            #endregion
        }

    }
}
