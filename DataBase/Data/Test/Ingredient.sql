SET IDENTITY_INSERT [dbo].[Ingredient] ON;
INSERT INTO [dbo].[Ingredient] ([IngredientId], [BaseMaterialId], [Quantity], [RecipeId]) VALUES (1, 1, 0.2, 1);
INSERT INTO [dbo].[Ingredient] ([IngredientId], [BaseMaterialId], [Quantity], [RecipeId]) VALUES (2, 3, 0.02, 1);
INSERT INTO [dbo].[Ingredient] ([IngredientId], [BaseMaterialId], [Quantity], [RecipeId]) VALUES (3, 5, 2, 1);
INSERT INTO [dbo].[Ingredient] ([IngredientId], [BaseMaterialId], [Quantity], [RecipeId]) VALUES (4, 6, 0.0005, 1);
INSERT INTO [dbo].[Ingredient] ([IngredientId], [BaseMaterialId], [Quantity], [RecipeId]) VALUES (5, 9, 0.075, 1);
INSERT INTO [dbo].[Ingredient] ([IngredientId], [BaseMaterialId], [Quantity], [RecipeId]) VALUES (6, 10, 0.2, 1);

SET IDENTITY_INSERT [dbo].[Ingredient] OFF;