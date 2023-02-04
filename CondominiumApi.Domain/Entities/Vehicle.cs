using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Entities
{
    public class Vehicle
    {
        public decimal Id { get; set; }
        public string Plate { get; set; }

        public int VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }

        public int Vehicle_Type { get; set; }
        public bool Handicap { get; set; }
        public DateTime Create_Date { get; set; }
        
        public DateTime Last_Update_Date { get; set; }
        

        public ICollection<ApartmentVehicles> ApartmentVehicles { get; set; }
    }
}
