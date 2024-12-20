﻿using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IBaseMaterialRepository : ICRUDRepository<BaseMaterial>
    {
        Task<BaseMaterial> GetAllExtended();
        void LoadData();
    }
}
