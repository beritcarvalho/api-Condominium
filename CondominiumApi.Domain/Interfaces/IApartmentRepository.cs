using CondominiumApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Interfaces
{
    public interface IApartmentRepository : IBaseRepository<Apartment>
    {
        Task<List<Apartment>> GetAllWithInclusions();
        Task<Apartment> GetByIdWithInclusions(int id);
        Task<Apartment> GetByNumberAndBlockWithInclusions(int number, int block);
    }
}
