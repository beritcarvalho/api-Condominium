using CondominiumApi.Domain.Entities;

namespace CondominiumApi.Domain.Interfaces
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        Task<List<Vehicle>> GetAllWithInclusions();
        Task<Vehicle> GetVehicleWithInclusions(decimal id);
        Task<Vehicle> GetVehicleWithInclusions(string plate);
    }
}
