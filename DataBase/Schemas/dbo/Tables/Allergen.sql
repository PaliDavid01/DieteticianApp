CREATE TABLE [dbo].[Allergen]
(
	[AllergenId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,[AllergenName] NVARCHAR(50) NOT NULL
,[AllergenDescription] NVARCHAR(250) NOT NULL
,[AllergenCode] VARCHAR(255) NOT NULL,
)
