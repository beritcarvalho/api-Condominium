using CondominiumApi.Domain.Entities;
using CondominiumApi.Domain.Interfaces;
using CondominiumApi.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Infrastructure.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<Person> GetPersonByCPF(string cpf)
        {
            var entity = await Context
                .People
                .Where(person => person.Cpf == cpf).FirstOrDefaultAsync();

            return entity;
        }
    }
}
