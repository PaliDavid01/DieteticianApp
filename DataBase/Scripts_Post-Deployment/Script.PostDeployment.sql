/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\..\Data\Test\User.sql
:r .\..\Data\Test\Role.sql
:r .\..\Data\Test\UserRole.sql
:r .\..\Data\Test\Allergen.sql
:r .\..\Data\Test\MaterialGroup.sql
:r .\..\Data\Test\BaseMaterial.sql
:r .\..\Data\Test\AllergenMaterial.sql
:r .\..\Data\Test\RecipeCategory.sql
:r .\..\Data\Test\Recipe.sql
:r .\..\Data\Test\Ingredient.sql

