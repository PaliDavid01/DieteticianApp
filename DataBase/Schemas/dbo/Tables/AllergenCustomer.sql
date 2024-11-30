CREATE TABLE [dbo].[AllergenCustomer]
(
	[AllergenCustomerId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
	,[AllergenId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Allergen]([AllergenId])
	,[CustomerId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Customer]([CustomerId])
)
