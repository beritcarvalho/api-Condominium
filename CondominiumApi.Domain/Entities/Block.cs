using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Entities
{
    public class BlockOfApartment
    {
        public int Id { get; set; }
        public string Block_Name { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }
}
