﻿using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IMealRepository : ICRUDRepository<Meal>
    {
        int CreateWithReturnId(Meal meal);
        Task<GetMealMacroDataResult> GetMealMacroData(int mealId);
    }
}
