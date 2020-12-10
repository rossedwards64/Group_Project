CREATE TABLE [dbo].[User] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (MAX) NULL,
    [FileName]    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

