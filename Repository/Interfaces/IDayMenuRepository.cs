﻿using Models;
using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IDayMenuRepository : ICRUDRepository<DayMenu>
    {
        Task<IEnumerable<DayMenu>> GetDayMenuByWeekMenuId(int weekMenuId);
        Task<GetDayMenuMacroDataResult> GetGetDayMenuMacroData(int dayMenuId);
        Task SaveGeneratedDaymenu(int dayMenuId, Dictionary<MealType, MealRecipe> dayMenu);
    }
}
