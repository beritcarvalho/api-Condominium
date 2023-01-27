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
        Task<List<Apartment>> GetAllWithIncludeAsync();
        Task<Apartment> GetByIdWithIncludeAsync(int id);
        Task<Apartment> UpdateAsync(Apartment updatedApartment);
    }
}
