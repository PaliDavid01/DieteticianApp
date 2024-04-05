
SET IDENTITY_INSERT [dbo].[UserRole] ON;

-- Insert data with a specific UserRoleId value
INSERT INTO [dbo].[UserRole] (UserRoleId, UserId, RoleId) 
VALUES (1, -- Specific UserRoleId to insert
        1, -- UserId
        6 -- RoleId as an example
        );
INSERT INTO [dbo].[UserRole] (UserRoleId, UserId, RoleId) VALUES (2, 1, 3);
INSERT INTO [dbo].[UserRole] (UserRoleId, UserId, RoleId) VALUES (3, 2, 5);
INSERT INTO [dbo].[UserRole] (UserRoleId, UserId, RoleId) VALUES (4, 3, 1);
-- Prevent further explicit values from being inserted into the identity column of the UserRole table
SET IDENTITY_INSERT [dbo].[UserRole] OFF;
