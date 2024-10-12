CREATE TABLE [dbo].[Customer]
(
	[CustomerId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
	,[CustomerName] NVARCHAR(50) NOT NULL
	,[HasAllergies] BIT NOT NULL
	,[HasDiabetes] BIT NOT NULL
	,[AgeCategoryId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[AgeCategory]([AgeCategoryId])
)
