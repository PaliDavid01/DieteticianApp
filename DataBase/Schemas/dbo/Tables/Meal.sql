﻿CREATE TABLE [dbo].[Meal]
(
[MealId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,[MealName] NVARCHAR(50) NOT NULL
,[ServingCount] INT
,[MealDescription] NVARCHAR(250) NOT NULL
)