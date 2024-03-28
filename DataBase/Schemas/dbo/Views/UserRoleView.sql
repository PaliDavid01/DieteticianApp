CREATE VIEW [dbo].[UserRoleView]
	AS SELECT
	[UserRole].[UserRoleId]
	,[UserRole].[UserId]
	,[UserRole].[RoleId]
	,[Role].[RoleName]
	FROM [dbo].[UserRole] AS [UserRole]
	LEFT JOIN [dbo].[Role] AS [Role] ON [UserRole].[RoleId] = [Role].[RoleId]


