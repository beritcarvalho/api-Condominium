using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public int BlockId { get; set; }
        public BlockOfApartment BlockOfApartment { get; set; }

        public Guid? OwnerId { get; set; }
        public Person? Owner { get; set; }

        public Guid? ResidentId { get; set; }
        public Person? Resident { get; set; }
    }
}
