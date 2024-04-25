CREATE TABLE [dbo].[Ingredient]
(
	[IngredientId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
	, [BaseMaterialId] INT NOT NULL
	, [Quantity] DECIMAL(18, 6) NOT NULL
	, [RecipeId] INT NOT NULL
	FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId])
	,FOREIGN KEY ([BaseMaterialId]) REFERENCES [dbo].[BaseMaterial] ([MaterialId])
)
