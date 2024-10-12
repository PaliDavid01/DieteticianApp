﻿using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    internal class DayOrderRepository : CRUDRepository<DayOrder>, IDayOrderRepository
    {
        public DayOrderRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}