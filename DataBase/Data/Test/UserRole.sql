
SET IDENTITY_INSERT [dbo].[UserRole] ON;

-- Insert data with a specific UserRoleId value
INSERT INTO [dbo].[UserRole] (UserRoleId, UserId, RoleId, DateAssigned, IsActive) 
VALUES (1, -- Specific UserRoleId to insert
        1, -- UserId
        6, -- RoleId as an example
        GETDATE(), -- DateAssigned as current date and time
        1); -- IsActive set to true (bit value for true)
INSERT INTO [dbo].[UserRole] (UserRoleId, UserId, RoleId, DateAssigned, IsActive) VALUES (2, 1, 3, GETDATE(), 1);
INSERT INTO [dbo].[UserRole] (UserRoleId, UserId, RoleId, DateAssigned, IsActive) VALUES (3, 2, 5, GETDATE(), 1);
INSERT INTO [dbo].[UserRole] (UserRoleId, UserId, RoleId, DateAssigned, IsActive) VALUES (4, 3, 1, GETDATE(), 1);
-- Prevent further explicit values from being inserted into the identity column of the UserRole table
SET IDENTITY_INSERT [dbo].[UserRole] OFF;
