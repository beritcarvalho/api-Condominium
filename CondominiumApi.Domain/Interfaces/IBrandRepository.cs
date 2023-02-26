using CondominiumApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Interfaces
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        Task<Brand> GetByIdAsync(int id);
    }
}
