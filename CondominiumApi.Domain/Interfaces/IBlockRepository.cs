﻿using CondominiumApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Interfaces
{
    public interface IBlockRepository : IBaseRepository<BlockOfApartment>
    {
        Task<BlockOfApartment> GetByIdAsync(int id);
        Task<BlockOfApartment> GetBlockOfApartment(string block);
    }
}
