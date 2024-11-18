SET IDENTITY_INSERT [dbo].[AgeCategory] ON
INSERT INTO [dbo].[AgeCategory] ([AgeCategoryId], [AgeCategoryName], [AgeCategoryMinAge], [AgeCategoryMaxAge], [MaxDailyCalories]) VALUES (1, N'Óvodás', 3, 6, 1400);
INSERT INTO [dbo].[AgeCategory] ([AgeCategoryId], [AgeCategoryName], [AgeCategoryMinAge], [AgeCategoryMaxAge], [MaxDailyCalories]) VALUES (2, N'Gyermek', 7, 11, 1700);
INSERT INTO [dbo].[AgeCategory] ([AgeCategoryId], [AgeCategoryName], [AgeCategoryMinAge], [AgeCategoryMaxAge], [MaxDailyCalories]) VALUES (3, N'Serdülő', 12, 18, 2700);
INSERT INTO [dbo].[AgeCategory] ([AgeCategoryId], [AgeCategoryName], [AgeCategoryMinAge], [AgeCategoryMaxAge], [MaxDailyCalories]) VALUES (4, N'Fiatal felnőtt', 19, 30, 2800);
INSERT INTO [dbo].[AgeCategory] ([AgeCategoryId], [AgeCategoryName], [AgeCategoryMinAge], [AgeCategoryMaxAge], [MaxDailyCalories]) VALUES (5, N'Felnőtt', 30, 60, 2700);
INSERT INTO [dbo].[AgeCategory] ([AgeCategoryId], [AgeCategoryName], [AgeCategoryMinAge], [AgeCategoryMaxAge], [MaxDailyCalories]) VALUES (6, N'Idős', 60, 100, 2500);
SET IDENTITY_INSERT [dbo].[AgeCategory] OFF
