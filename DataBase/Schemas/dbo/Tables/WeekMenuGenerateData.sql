CREATE TABLE [dbo].[WeekMenuGenerateData]
(
	[WeekMenuGenerateDataId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[WeekMenuId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[WeekMenu]([WeekMenuId]),
	[AgeCategoryId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[AgeCategory]([AgeCategoryId]),

)
