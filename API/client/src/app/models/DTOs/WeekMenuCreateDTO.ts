interface WeekMenuDTO {
  weekMenuId?: number;
  weekMenuName?: string | null;
  weekMenuStartDate?: Date;
  weekMenuEndDate?: Date;
  monday?: DayMenuDTO;
  tuesday?: DayMenuDTO;
  wednesday?: DayMenuDTO;
  thursday?: DayMenuDTO;
  friday?: DayMenuDTO;
  saturday?: DayMenuDTO;
  sunday?: DayMenuDTO;
}

interface DayMenuDTO {
  dayMenuId?: number;
  dayMenuName?: string | null;
  dayMenuDate?: Date;
  breakfast?: MealDTO;
  brunch?: MealDTO;
  lunch?: MealDTO;
  afternoonSnack?: MealDTO;
  dinner?: MealDTO;
}

interface MealDTO {
  mealId?: number;
  mealName?: string | null;
  servingCount?: number | null;
  mealDescription?: string | null;
}

interface MealRecipeDTO {
  mealRecipeId?: number;
  recipeId?: number;
  meal?: MealDTO;
  quantity?: number;
}
