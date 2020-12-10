CREATE TABLE [dbo].[UserTable] (
    [UserID]    INT          IDENTITY (1, 1) NOT NULL,
    [Username]  VARCHAR (20) NOT NULL,
    [Password]  VARCHAR (20) NULL,
    [Role]      CHAR (10)    NULL,
    [FirstName] VARCHAR (20) NULL,
    [FileName] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

