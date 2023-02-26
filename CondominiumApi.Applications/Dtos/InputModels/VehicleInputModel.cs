using CondominiumApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Dtos.InputModels
{
    public class VehicleInputModel
    {
        public decimal Id { get; set; }
        public string Plate { get; set; }
        public int VehicleModelId { get; set; }
        public int Vehicle_Type { get; set; }
        public bool Handicap { get; set; }
    }
}
