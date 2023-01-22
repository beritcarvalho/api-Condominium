﻿using CondominiumApi.Applications.Dtos.InputModels;
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
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IList<PersonViewModel>> GetAll() 
        {            
            var list = new List<PersonViewModel>();
            var people = await _personRepository.GetAllAsync();

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
        public async Task<PersonViewModel> AddAccount(PersonInputModel input)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonViewModel> GetById(int id)
        {
            throw new NotImplementedException();
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
