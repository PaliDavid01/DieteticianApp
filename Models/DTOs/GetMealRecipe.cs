namespace Models.DTOs
{
    public class GetMealRecipe
    {
        public int MealRecipeId { get; set; }
        public int MealId { get; set; }
        public int RecipeId { get; set; }
        public string? RecipeName { get; set; }
        public double Quantity { get; set; }
    }
}
