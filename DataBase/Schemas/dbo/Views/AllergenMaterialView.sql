CREATE VIEW [dbo].[AllergenMaterialView]
	AS SELECT
	[AllergenMaterial].[AllergenMaterialID]
	,[AllergenMaterial].[MaterialID]
	,[Allergen].[AllergenCode]
	,[Allergen].[AllergenName]
	,[Allergen].[AllergenDescription]	
	FROM [AllergenMaterial]
	LEFT Join [dbo].[Allergen] As [Allergen] ON [AllergenMaterial].[AllergenID] = [Allergen].[AllergenID]
