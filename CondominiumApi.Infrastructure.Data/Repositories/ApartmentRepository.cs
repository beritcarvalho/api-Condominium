using CondominiumApi.Domain.Entities;
using CondominiumApi.Domain.Interfaces;
using CondominiumApi.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Infrastructure.Data.Repositories
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
