CREATE TABLE [dbo].[RecipeCategory]
(
	[RecipeCategoryId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
	, [CategoryName] NVARCHAR(50) NOT NULL
	, [Description] NVARCHAR(1000) NOT NULL
)
