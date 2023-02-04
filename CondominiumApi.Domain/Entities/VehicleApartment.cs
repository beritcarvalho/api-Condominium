﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Entities
{
    public class ApartmentVehicles
    {
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public decimal VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public bool Active { get; set; }
        public DateTime? Inactive_Date { get; set; }
    }
}
