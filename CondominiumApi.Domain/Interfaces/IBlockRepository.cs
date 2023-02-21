using CondominiumApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Interfaces
{
    public interface IBlockRepository : IBaseRepository<Block>
    {
        Task<Block> GetByIdAsync(int id);
        Task<Block> GetBlockOfApartment(string block);
    }
}
