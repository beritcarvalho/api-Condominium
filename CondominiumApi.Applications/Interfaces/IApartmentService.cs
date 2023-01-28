using CondominiumApi.Applications.Dtos.InputModels;
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
        Task<List<ApartmentViewModel>> GetAll();
        Task<ApartmentViewModel> GetByIdWithInclude(int idApartment);
        Task<ApartmentViewModel> InsertNewApartment(ApartmentInputModel newApartment);
        Task<ApartmentViewModel> UpdateApartment(ApartmentInputModel newApartment);
        Task<ApartmentViewModel> ResetApartmentData(ApartmentInputModel newApartment);
    }
}
