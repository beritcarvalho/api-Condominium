using AutoMapper;
using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
using CondominiumApi.Domain.Entities;
using CondominiumApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
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
                    list.Add(_mapper.Map<PersonViewModel>(person));
                };

                return list;
            }
            catch (Exception exception)
            {
                throw new Exception("ERR-PSX01 Falha interna no servidor");
            }
        }

        public async Task<PersonViewModel> AddPerson(PersonInputModel input)
        {
            try
            {
                var newPerson = _mapper.Map<Person>(input);

                newPerson.Create_Date = DateTime.Now;
                newPerson.Last_Update_Date = DateTime.Now;

                await _personRepository.InsertAsync(newPerson);

                return _mapper.Map<PersonViewModel>(newPerson);
            }
            catch (DbException exception)
            {
                throw new Exception("ERR-PSX03 Não foi possível realizar o cadastro");
            }
            catch
            {
                throw new Exception("ERR-PSX03 Falha interna no servidor");
            }
        }

        public async Task<PersonViewModel> GetById(Guid id)
        {
            try
            {
                var person = await _personRepository.GetByIdAsync(id);

                if (person is null)
                    return null;

                var resultPerson = _mapper.Map<PersonViewModel>(person);

                return resultPerson;
            }
            catch (Exception exception)
            {
                throw new Exception("ERR-PSX02 Falha interna no servidor");
            }
            
        }

        public async Task<PersonViewModel> RemoveById(Guid id)
        {
            try
            {
                var person = await _personRepository.GetByIdAsync(id);

                if (person is null)
                    return null;

                await _personRepository.RemoveAsync(person);
                return _mapper.Map<PersonViewModel>(person);
            }
            catch (DbException e)
            {
                throw new Exception("Não foi possível deletar o cadastro");
            }
            catch
            {
                throw new Exception("ERR-PSX05 Falha interna no servidor");
            }
        }

        public async Task<PersonViewModel> UpdateAccount(PersonUpdateInputModel input)
        {
            try
            {
                var person = await _personRepository.GetByIdAsync(input.Id);

                if (person is null)
                    return null;

                _mapper.Map(input, person);

                person.Last_Update_Date = DateTime.UtcNow;

                await _personRepository.UpdateAsync(person);
                return _mapper.Map<PersonViewModel>(person);
            }
            catch (DbUpdateException e)
            {
                throw new Exception("ERR-PSX04 Não foi possível atualizar o cadastro");
            }
            catch
            {
                throw new Exception("ERR-PSX04 Falha interna no servidor");
            }
        }

    }
}
