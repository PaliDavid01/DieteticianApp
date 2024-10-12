CREATE TABLE [dbo].[DayMenu]
(
	[DayMenuId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
	,[DayMenuName] NVARCHAR(50) NOT NULL
	,[DayMenuDate] DATE NOT NULL
	,[BreakfastId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Meal]([MealId])
	,[BrunchId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Meal]([MealId])
	,[LunchId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Meal]([MealId])
	,[AfternoonSnackId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Meal]([MealId])
	,[DinnerId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Meal]([MealId])
)
