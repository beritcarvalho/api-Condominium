using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Entities
{
    public class Block
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }
}
