using CondominiumApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Dtos.ViewModels
{
    public class VehicleViewModel
    {
        public decimal Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Vehicle_Type { get; set; }
        public bool Handicap { get; set; }
    }
}
