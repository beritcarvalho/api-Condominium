using CondominiumApi.Domain.Entities;
using CondominiumApi.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Infrastructure.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
