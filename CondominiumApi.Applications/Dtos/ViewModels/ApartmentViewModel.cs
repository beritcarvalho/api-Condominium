using CondominiumApi.Applications.Dtos.ValueObjects;
using CondominiumApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Applications.Dtos.ViewModels
{
    public class ApartmentViewModel
    {
        public int? Id { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
        public NameValueObject Owner { get; set; }
        public NameValueObject Resident { get; set; }        
    }
}
