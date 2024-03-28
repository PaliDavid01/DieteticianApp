
CREATE TABLE [dbo].[Ecodes] (
    [EcodeID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [MaterialID] INT NOT NULL,
    [Ecode] VARCHAR(255) NOT NULL,
    [Description] TEXT,
    FOREIGN KEY ([MaterialID]) REFERENCES [dbo].[BaseMaterial]([MaterialID])
);
