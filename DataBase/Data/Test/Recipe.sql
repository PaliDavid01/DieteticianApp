SET IDENTITY_INSERT [dbo].[Recipe] ON;
INSERT INTO [dbo].[Recipe] (
	[RecipeId], 
	[RecipeName],
	[RecipeDescription], 
	[RecipeCategoryId],
	[RecipeCostPrice], 
	[RecipeRetailPrice], 
	[RecipeKilojule],
	[RecipeCalories],
	[RecipeProtein], 
	[RecipeFat], 
	[RecipeCarbohydrate], 
	[RecipeCholesterol], 
	[RecipeSugar], 
	[RecipeSalt], 
	[RecipeSaturatedFat], 
	[RecipeTransFat], 
	[RecipeFiber], 
	[RecipeKalcium], 
	[RecipeKalium], 
	[RecipeQuantity], 
	[RecipeMeasure])
	VALUES
	(1, N'Palacsinta', N'Hagyományos palacsinta', 4, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, N'db')

SET IDENTITY_INSERT [dbo].[Recipe] OFF;
