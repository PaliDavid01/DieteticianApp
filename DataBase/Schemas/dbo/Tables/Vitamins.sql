
CREATE TABLE [dbo].[Vitamins] (
    [VitaminID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [MaterialID] INT NOT NULL,
    [VitaminA] INT,
    [VitaminC] INT,
    [VitaminD] INT,
    [VitaminE] INT,
    [VitaminK] INT,
    [PHA] INT,
    [Fiber] INT,
    FOREIGN KEY ([MaterialID]) REFERENCES [dbo].[BaseMaterial]([MaterialID])
);
