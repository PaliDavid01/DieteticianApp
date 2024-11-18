CREATE TABLE [dbo].[WeekMenuGenerateDataAllergen]
(
	[WeekMenuGenerateDataAllergenId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[WeekMenuGenerateDataId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[WeekMenuGenerateData]([WeekMenuGenerateDataId]),
	[AllergenId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Allergen]([AllergenId])
)
