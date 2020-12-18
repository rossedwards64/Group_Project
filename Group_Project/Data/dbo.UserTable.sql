CREATE TABLE [dbo].[UserTable] (
    [UserID]    INT            IDENTITY (1, 1) NOT NULL,
    [Username]  VARCHAR (20)   NOT NULL,
    [Password]  VARCHAR (20)   NOT NULL,
    [Role]      CHAR (10)      NOT NULL,
    [FirstName] VARCHAR (20)   NOT NULL,
    [FileName]  NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

