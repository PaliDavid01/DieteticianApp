
CREATE TABLE [dbo].[AllergenMaterial] (
    [AllergenMaterialID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [MaterialID] INT NOT NULL,
    [AllergenID] INT NOT NULL,
    FOREIGN KEY ([MaterialID]) REFERENCES [dbo].[BaseMaterial]([MaterialID])
    ,FOREIGN KEY ([AllergenID]) REFERENCES [dbo].[Allergen]([AllergenID])
);
