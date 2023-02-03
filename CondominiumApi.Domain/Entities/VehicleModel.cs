using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Entities
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
