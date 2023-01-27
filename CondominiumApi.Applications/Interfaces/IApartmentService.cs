using CondominiumApi.Applications.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Interfaces
{
    public interface IApartmentService
    {
        Task<ApartmentViewModel> GetAll();
        Task<ApartmentViewModel> GetByIdWithInclude(int idApartment);
    }
}
