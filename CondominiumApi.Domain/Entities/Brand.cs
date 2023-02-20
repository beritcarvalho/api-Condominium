using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Brand_Name { get; set; }

        public ICollection<VehicleModel> Models { get; set; }
    }
}
