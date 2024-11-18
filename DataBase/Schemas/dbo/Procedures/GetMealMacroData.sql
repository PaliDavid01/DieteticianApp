CREATE PROCEDURE [dbo].[GetMealMacroData]
    @MealId INT
AS
BEGIN
    SET NOCOUNT ON;  -- Prevents extra result sets from being returned

    SELECT TOP(1)
        m.[MealId],
        SUM(r.[RecipeCostPrice]) AS [TotalCostPrice],  -- Aggregated CostPrice
        SUM(r.[RecipeRetailPrice]) AS [TotalRetailPrice],  -- Aggregated RetailPrice
        SUM(r.[RecipeKilojule]) AS [TotalKilojule],  -- Aggregated Kilojule
        SUM(r.[RecipeCalories]) AS [TotalCalories],  -- Aggregated Calories
        SUM(r.[RecipeProtein]) AS [TotalProtein],    -- Aggregated Protein
        SUM(r.[RecipeFat]) AS [TotalFat],            -- Aggregated Fat
        SUM(r.[RecipeCarbohydrate]) AS [TotalCarbohydrate],  -- Aggregated Carbohydrate
        SUM(r.[RecipeCholesterol]) AS [TotalCholesterol],    -- Aggregated Cholesterol
        SUM(r.[RecipeSugar]) AS [TotalSugar],        -- Aggregated Sugar
        SUM(r.[RecipeSalt]) AS [TotalSalt],          -- Aggregated Salt
        SUM(r.[RecipeSaturatedFat]) AS [TotalSaturatedFat],  -- Aggregated Saturated Fat
        SUM(r.[RecipeTransFat]) AS [TotalTransFat],  -- Aggregated Trans Fat
        SUM(r.[RecipeFiber]) AS [TotalFiber],        -- Aggregated Fiber
        SUM(r.[RecipeKalcium]) AS [TotalKalcium],    -- Aggregated Kalcium
        SUM(r.[RecipeKalium]) AS [TotalKalium],      -- Aggregated Kalium
        [HasAllergen] = CASE
			WHEN COUNT(DISTINCT a.[AllergenId]) > 0 THEN 1
			ELSE 0
		END,
        [Allergens] = STRING_AGG(a.[AllergenName], ', ')  -- Concatenated AllergenNames
    FROM
        [dbo].[Meal] m
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
        m.[MealId] = @MealId
    GROUP BY
        m.[MealId];
END;
