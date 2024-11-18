namespace Models.DTOs
{
    public class WeekMenuDTO
    {
        public int? WeekMenuId { get; set; }
        public string? WeekMenuName { get; set; }
        public DateTime? WeekMenuStartDate { get; set; }
        public DateTime? WeekMenuEndDate { get; set; }
        public DayMenuDTO? Monday { get; set; }
        public DayMenuDTO? Tuesday { get; set; }
        public DayMenuDTO? Wednesday { get; set; }
        public DayMenuDTO? Thursday { get; set; }
        public DayMenuDTO? Friday { get; set; }
        public DayMenuDTO? Saturday { get; set; }
        public DayMenuDTO? Sunday { get; set; }
    }

    public class DayMenuDTO
    {
        public int? DayMenuId { get; set; }
        public string? DayMenuName { get; set; }
        public DateTime? DayMenuDate { get; set; }
        public MealDTO? Breakfast { get; set; }
        public MealDTO? Brunch { get; set; }
        public MealDTO? Lunch { get; set; }
        public MealDTO? AfternoonSnack { get; set; }
        public MealDTO? Dinner { get; set; }
    }

    public class MealDTO
    {
        public int? MealId { get; set; }
        public string? MealName { get; set; }
        public int? ServingCount { get; set; }
        public string? MealDescription { get; set; }
    }

    public class MealRecipeDTO
    {
        public int? MealRecipeId { get; set; }
        public int? RecipeId { get; set; }
        public MealDTO? Meal { get; set; }
        public int? Quantity { get; set; }
    }
}