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

        public async Task<Apartment> GetByIdWithInclude(int id)
        {
            var apartment = await Context
                .Apartments
                .Where(apart => apart.Id == id)
                .Include(bloc => bloc.BlockOfApartment)
                .Include(bloc => bloc.Owner)
                .Include(bloc => bloc.Resident)
                .FirstOrDefaultAsync();

            return apartment;
        }

        public async Task<List<Apartment>> GetAllWithInclude()
        {
            var apartment = await Context
                .Apartments             
                .Include(bloc => bloc.BlockOfApartment)
                .Include(bloc => bloc.Owner)
                .Include(bloc => bloc.Resident)
                .AsNoTracking()   
                .ToListAsync();

            return apartment;
        }

        public async Task<Apartment> GetByNumberAndBlockWithInclude(int number, int idblock)
        {
            var apartment = await Context
                .Apartments
                .Where(apart => apart.Number == number && apart.BlockId == idblock)
                .Include(bloc => bloc.BlockOfApartment)
                .Include(bloc => bloc.Owner)
                .Include(bloc => bloc.Resident)
                .FirstOrDefaultAsync();

            return apartment;
        }
    }
}
