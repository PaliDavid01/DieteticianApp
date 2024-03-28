-- Allow explicit values to be inserted into the identity column of the Role table
SET IDENTITY_INSERT [dbo].[Role] ON

-- Insert data with specific RoleId values
INSERT INTO [dbo].[Role] (RoleId, RoleName, RoleDescription) VALUES (1, 'Dietitian', 'Responsible for overseeing the nutritional aspects of the food service program.')
INSERT INTO [dbo].[Role] (RoleId, RoleName, RoleDescription) VALUES (2, 'Chef', 'In charge of all activities related to the kitchen, including menu creation, kitchen staff management, and inventory ordering.')
INSERT INTO [dbo].[Role] (RoleId, RoleName, RoleDescription) VALUES (3, 'Kitchen-staff', 'Assists the chefs, prepares the ingredients, and performs all tasks necessary to ensure smooth kitchen operations.')
INSERT INTO [dbo].[Role] (RoleId, RoleName, RoleDescription) VALUES (4, 'Storage-staff', 'Responsible for storage area maintenance, inventory management, and proper goods storage.')
INSERT INTO [dbo].[Role] (RoleId, RoleName, RoleDescription) VALUES (5, 'Supervisor', 'Oversees staff operations, ensures policy execution, and manages workflow.')
INSERT INTO [dbo].[Role] (RoleId, RoleName, RoleDescription) VALUES (6, 'IT', 'Responsible for managing information technology and computer systems, ensuring efficient IT operations.')

-- Prevent further explicit values from being inserted into the identity column of the Role table
SET IDENTITY_INSERT [dbo].[Role] OFF
