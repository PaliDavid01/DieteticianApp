﻿using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IAllergenMaterialRepository : ICRUDRepository<AllergenMaterial>
    {
        Task<IEnumerable<AllergenMaterialView>> GetAllergensByMaterialId(int Id);
    }
}
