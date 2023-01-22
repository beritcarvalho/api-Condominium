using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Services
{
    public class PersonService : IPersonService
    {
        public async Task<IList<PersonViewModel>> GetAll() 
        {
            throw new NotImplementedException();
        }
        public Task<PersonViewModel> AddAccount(PersonInputModel input)
        {
            throw new NotImplementedException();
        }

        public Task<PersonViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonViewModel> RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonViewModel> UpdateAccount(PersonInputModel input)
        {
            throw new NotImplementedException();
        }
    }
}
