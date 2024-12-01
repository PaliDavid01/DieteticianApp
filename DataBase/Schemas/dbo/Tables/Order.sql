CREATE TABLE [dbo].[Order]
(
	[OrderId] INT NOT NULL  IDENTITY(1,1) PRIMARY KEY,
	[CustomerId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Customer]([CustomerId]),
	[OrderStartDate] DATE,
	[OrderEndDate] DATE,

)
