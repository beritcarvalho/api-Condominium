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
    public class BlockRepository : BaseRepository<Block>, IBlockRepository
    {
        public BlockRepository(DataBaseContext context) : base(context)
        {
        }
        public async Task<Block> GetBlockOfApartment(string block)
        {
            var entity = await Context
                .Blocks
                .Where(bloc => bloc.Name == block).FirstOrDefaultAsync();

            return entity;
        }
    }
}
