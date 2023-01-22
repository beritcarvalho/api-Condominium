using CondominiumApi.Applications.Dtos.InputModels;
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
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IList<PersonViewModel>> GetAll() 
        {
            try
            {
                var people = await _personRepository.GetAllAsync();


                if (people.Count == 0)
                    return null;

                var list = new List<PersonViewModel>();
                foreach (var person in people)
                {
                    list.Add(new PersonViewModel
                    {
                        Id = person.Id,
                        First_Name = person.First_Name,
                        Last_Name = person.Last_Name,
                        Cpf = person.Cpf,
                        Phone = person.Phone,
                        Email = person.Email,
                        Create_Date = person.Create_Date,
                        Last_Update_Date = person.Last_Update_Date
                    });
                };

                return list;
            }
            catch (Exception exception)
            {
                throw new Exception("ERR-PSX01 Falha interna no servidor");
            }
        }
        public async Task<PersonViewModel> AddAccount(PersonInputModel input)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonViewModel> GetById(Guid id)
        {
            try
            {
                var person = await _personRepository.GetByIdAsync(id);

                if (person == null)
                    return null;

                var resultPerson = new PersonViewModel
                {
                    Id = person.Id,
                    First_Name = person.First_Name,
                    Last_Name = person.Last_Name,
                    Cpf = person.Cpf,
                    Phone = person.Phone,
                    Email = person.Email,
                    Create_Date = person.Create_Date,
                    Last_Update_Date = person.Last_Update_Date
                };

                return resultPerson;
            }
            catch (Exception exception)
            {
                throw new Exception("ERR-PSX02 Falha interna no servidor");
            }
            
        }

        public async Task<PersonViewModel> RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonViewModel> UpdateAccount(PersonInputModel input)
        {
            throw new NotImplementedException();
        }
    }
}
