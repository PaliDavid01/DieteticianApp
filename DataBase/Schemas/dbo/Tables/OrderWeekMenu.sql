CREATE TABLE [dbo].[OrderWeekMenu]
(
	[OrderWeekMenuId] INT NOT NULL  IDENTITY(1,1) PRIMARY KEY,
	[OrderId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Order]([OrderId]),
	[WeekMenuId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[WeekMenu]([WeekMenuId]),
)
