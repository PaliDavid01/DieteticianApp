CREATE TABLE [dbo].[DayOrder]
(
	[DayOrderId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
	,[WantBreakfast] BIT NOT NULL
	,[WantBrunch] BIT NOT NULL
	,[WantLunch] BIT NOT NULL
	,[WantAfternoonSnack] BIT NOT NULL
	,[WantDinner] BIT NOT NULL
)
