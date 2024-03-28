
CREATE TABLE [dbo].[BaseMaterial] (
    [MaterialID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [MaterialCode] VARCHAR(255) NOT NULL,
    [ActivityDescription] VARCHAR(255),
    [VATRate] INT,
    [Quantity] DECIMAL(10,2),
    [LedgerAccountNumber] INT,
    [Rounding] INT,
    [ITJ_SZTJ] VARCHAR(255),
    [MaterialGroupName] VARCHAR(255),
    [MaterialGroupId] INT,
    [Note] TEXT,
    [CostPrice] DECIMAL(10,2),
    [RetailPrice] DECIMAL(10,2),
    [SupplierCode] VARCHAR(255)
);
