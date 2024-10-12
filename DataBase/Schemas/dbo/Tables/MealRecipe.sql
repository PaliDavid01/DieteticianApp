CREATE TABLE [dbo].[MealRecipe]
(
	[MealRecipeId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
	,[RecipeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Recipe]([RecipeId])
	,[MealId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Meal]([MealId])
	,[Quantity] FLOAT NOT NULL
)
