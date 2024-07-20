using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class RecipeLogic : CRUDLogic<Recipe>, IRecipeLogic
    {
        private readonly IRecipeRepository _repository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IBaseMaterialRepository _baseMaterialRepository;
        public RecipeLogic(IRecipeRepository repository, IIngredientRepository ingredientRepository, IBaseMaterialRepository baseMaterialRepository) : base(repository)
        {
            _repository = repository;
            _ingredientRepository = ingredientRepository;
            _baseMaterialRepository = baseMaterialRepository;
        }
        public async Task RecalculateMacros(int recipeId)
        {
            var ingredients = await _ingredientRepository.GetAllByRecipeId(recipeId);
            var basematerials = await _baseMaterialRepository.ReadAllAsync();
            var ingredientsWithBasematerials = ingredients.Select(i => new
            {
                Ingredient = i,
                BaseMaterial = basematerials.FirstOrDefault(b => b.MaterialId == i.BaseMaterialId)
            });
            var recipe = await _repository.ReadByIdAsync(recipeId);
            recipe.RecipeCalories = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Kilojule);
            recipe.RecipeProtein = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Protein);
            recipe.RecipeCarbohydrate = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Carbohydrate);
            recipe.RecipeFat = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Fat);
            recipe.RecipeSaturatedFat = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.SaturatedFat);
            recipe.RecipeTransFat = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity);
            recipe.RecipeSugar = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Sugar);
            recipe.RecipeFiber = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Fiber);
            recipe.RecipeSalt = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Salt);
            recipe.RecipeRetailPrice = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.RetailPrice);
            recipe.RecipeKalcium = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Kalcium);
            recipe.RecipeKalium = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Kalium);
            recipe.RecipeCholesterol = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.Cholesterol);
            recipe.RecipeCostPrice = ingredientsWithBasematerials.Sum(i => i.Ingredient.Quantity * i.BaseMaterial.CostPrice);
            await _repository.UpdateAsync(recipe);
        }
    }
}
