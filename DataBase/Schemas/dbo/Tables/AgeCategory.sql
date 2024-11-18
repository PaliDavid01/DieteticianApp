CREATE TABLE [dbo].[AgeCategory]
(
	[AgeCategoryId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
	,[AgeCategoryName] NVARCHAR(50) NOT NULL
	,[AgeCategoryMinAge] INT NOT NULL
	,[AgeCategoryMaxAge] INT NOT NULL
	,[MaxDailyCalories] INT NOT NULL
)
