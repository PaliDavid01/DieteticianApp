CREATE VIEW [dbo].[RecipeGenerateDataView]
AS SELECT 
	recipe.[RecipeId],
	[AllergenIds] = STRING_AGG(allergen.[AllergenId], ',')
	FROM [dbo].[Recipe] as recipe
	LEFT JOIN [dbo].[Ingredient] as ingredient ON recipe.[RecipeId] = ingredient.[RecipeId]
	LEFT JOIN [dbo].[BaseMaterial] as material ON ingredient.[BaseMaterialId] = material.[MaterialId]
	LEFT JOIN [dbo].[AllergenMaterial] as allergenMaterial ON material.[MaterialId] = allergenMaterial.[MaterialId]
	LEFT JOIN [dbo].[Allergen] as allergen ON allergenMaterial.[AllergenId] = allergen.[AllergenId]
	GROUP BY recipe.[RecipeId]
