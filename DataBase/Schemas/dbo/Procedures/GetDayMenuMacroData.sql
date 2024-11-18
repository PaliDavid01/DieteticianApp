CREATE PROCEDURE [dbo].[GetDayMenuMacroData]
    @DayMenuId INT
AS
BEGIN
    SET NOCOUNT ON;  -- Prevents extra result sets from being returned

    SELECT
        SUM(r.[RecipeCostPrice]) AS [TotalCostPrice],
        SUM(r.[RecipeRetailPrice]) AS [TotalRetailPrice],
        SUM(r.[RecipeKilojule]) AS [TotalKilojule],
        SUM(r.[RecipeCalories]) AS [TotalCalories],
        SUM(r.[RecipeProtein]) AS [TotalProtein],
        SUM(r.[RecipeFat]) AS [TotalFat],
        SUM(r.[RecipeCarbohydrate]) AS [TotalCarbohydrate],
        SUM(r.[RecipeCholesterol]) AS [TotalCholesterol],
        SUM(r.[RecipeSugar]) AS [TotalSugar],
        SUM(r.[RecipeSalt]) AS [TotalSalt],
        SUM(r.[RecipeSaturatedFat]) AS [TotalSaturatedFat],
        SUM(r.[RecipeTransFat]) AS [TotalTransFat],
        SUM(r.[RecipeFiber]) AS [TotalFiber],
        SUM(r.[RecipeKalcium]) AS [TotalKalcium],
        SUM(r.[RecipeKalium]) AS [TotalKalium],
        MAX(CASE WHEN a.[AllergenId] IS NOT NULL THEN 1 ELSE 0 END) AS [HasAllergen],
        STRING_AGG(a.[AllergenName], ', ') AS [Allergens]
    FROM
        [dbo].[DayMenu] dm
    LEFT JOIN
        [dbo].[Meal] m ON m.[MealId] IN (dm.[BreakfastId], dm.[BrunchId], dm.[LunchId], dm.[AfternoonSnackId], dm.[DinnerId])
    LEFT JOIN
        [dbo].[MealRecipe] mr ON m.[MealId] = mr.[MealId]
    LEFT JOIN
        [dbo].[Recipe] r ON mr.[RecipeId] = r.[RecipeId]
    LEFT JOIN
        [dbo].[Ingredient] i ON r.[RecipeId] = i.[RecipeId]
    LEFT JOIN
        [dbo].[BaseMaterial] bm ON i.[BaseMaterialId] = bm.[MaterialId]
    LEFT JOIN
        [dbo].[AllergenMaterial] am ON bm.[MaterialId] = am.[MaterialId]
    LEFT JOIN
        [dbo].[Allergen] a ON am.[AllergenId] = a.[AllergenId]
    WHERE
        dm.[DayMenuId] = @DayMenuId
    GROUP BY
        dm.[DayMenuId];
END;