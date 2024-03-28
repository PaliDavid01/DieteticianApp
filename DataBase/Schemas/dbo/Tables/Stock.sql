
CREATE TABLE [dbo].[Stock] (
    [StockID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [MaterialID] INT NOT NULL,
    [MinimumStock] INT,
    [MaximumStock] INT,
    [PreCalculationPrice] DECIMAL(10,2),
    [CurrentStock] DECIMAL(10,2),
    [OrderUnitPrice] DECIMAL(10,2),
    [MaximumOrderPrice] DECIMAL(10,2),
    [CountingUnitPrice] DECIMAL(10,2),
    [SalePrice] DECIMAL(10,2),
    FOREIGN KEY ([MaterialID]) REFERENCES [dbo].[BaseMaterial]([MaterialID])
);
