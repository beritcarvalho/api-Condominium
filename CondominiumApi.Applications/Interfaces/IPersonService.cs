using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Interfaces
{
    public interface IPersonService
    {
        Task<IList<PersonViewModel>> GetAll();
        Task<PersonViewModel> GetById(Guid id);
        Task<PersonViewModel> AddAccount(PersonInputModel input);
        Task<PersonViewModel> UpdateAccount(PersonInputModel input);
        Task<PersonViewModel> RemoveById(int id);
    }
}
