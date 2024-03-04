﻿CREATE TABLE [dbo].[UserRole]
(
	[UserRoleId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([UserId]),
	[RoleId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Role]([RoleId]),
	[DateAssigned] DATETIME NOT NULL,
	[DateRevoked] DATETIME NULL,
	[IsActive] BIT NOT NULL
)
