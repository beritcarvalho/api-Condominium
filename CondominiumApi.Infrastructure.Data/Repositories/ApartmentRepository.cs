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
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<Apartment> GetByIdWithIncludeAsync(int id)
        {
            var entity = await Context
                .Apartments
                .Where(apart => apart.Id == id)
                .Include(bloc => bloc.BlockOfApartment)
                .Include(bloc => bloc.Owner)
                .Include(bloc => bloc.Resident)
                .FirstOrDefaultAsync();

            return entity;
        }
    }
}
