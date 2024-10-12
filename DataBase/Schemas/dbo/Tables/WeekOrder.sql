CREATE TABLE [dbo].[WeekOrder]
(
	[WeekOrderId] INT NOT NULL  IDENTITY(1,1) PRIMARY KEY
	,[CustomerId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Customer]([CustomerId])
	,[StartDate] DATE NOT NULL
	,[EndDate] DATE NOT NULL
	,[MondayTypeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayOrder]([DayOrderId])
	,[TuesdayTypeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayOrder]([DayOrderId])
	,[WednesdayTypeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayOrder]([DayOrderId])
	,[ThursdayTypeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayOrder]([DayOrderId])
	,[FridayTypeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayOrder]([DayOrderId])
	,[SaturdayTypeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayOrder]([DayOrderId])
	,[SundayTypeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[DayOrder]([DayOrderId])
)
