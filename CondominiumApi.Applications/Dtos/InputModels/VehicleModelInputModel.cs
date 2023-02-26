using CondominiumApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Dtos.InputModels
{
    public class VehicleModelInputModel
    {
        public int Id { get; set; }
        public string Model_Name { get; set; }
        public int BrandId { get; set; }
    }
}
