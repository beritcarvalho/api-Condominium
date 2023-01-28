using CondominiumApi.Applications.Dtos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Dtos.InputModels
{
    public class ApartmentInputModel
    {
        public int Number { get; set; }
        public string Block { get; set; }
        public string? OwnerCPF { get; set; }
        public string? ResidentCPF { get; set; }
    }
}
