﻿CREATE TABLE [dbo].[Meal]
(
[MealId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,[MealName] NVARCHAR(50) NULL
,[ServingCount] INT NULL
,[MealDescription] NVARCHAR(250) NULL
)
