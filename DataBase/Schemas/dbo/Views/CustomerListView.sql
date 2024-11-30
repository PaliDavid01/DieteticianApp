CREATE VIEW [dbo].[CustomerListView] AS SELECT
	[Customer].[CustomerId],
	[Customer].[CustomerName],
	[Customer].[HasAllergies],
	[Customer].[HasDiabetes],
	[AgeCategory].[AgeCategoryName],
	[AgeCategory].[AgeCategoryId],
	STRING_AGG([Allergen].[AllergenName], ', ') AS [Allergies]
	FROM [dbo].[Customer]
	JOIN [dbo].[AgeCategory] ON [Customer].[AgeCategoryId] = [AgeCategory].[AgeCategoryId]
	 JOIN [dbo].[AllergenCustomer] ON [Customer].[CustomerId] = [AllergenCustomer].[CustomerId]
	 JOIN [dbo].[Allergen] ON [AllergenCustomer].[AllergenId] = [Allergen].[AllergenId]
	GROUP BY     [Customer].[CustomerId],
    [Customer].[CustomerName],
    [Customer].[HasAllergies],
    [Customer].[HasDiabetes],
    [AgeCategory].[AgeCategoryName],
	[AgeCategory].[AgeCategoryId];