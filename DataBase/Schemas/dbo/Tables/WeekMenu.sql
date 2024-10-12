CREATE TABLE [dbo].[WeekMenu]
(
	[WeekMenuId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[WeekMenuName] NVARCHAR(50) NOT NULL,
	[WeekMenuStartDate] DATE NOT NULL,
	[WeekMenuEndDate] DATE NOT NULL,
	[MondayId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayMenu]([DayMenuId]),
	[TuesdayId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayMenu]([DayMenuId]),
	[WednesdayId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayMenu]([DayMenuId]),
	[ThursdayId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayMenu]([DayMenuId]),
	[FridayId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayMenu]([DayMenuId]),
	[SaturdayId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayMenu]([DayMenuId]),
	[SundayId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayMenu]([DayMenuId])
)
