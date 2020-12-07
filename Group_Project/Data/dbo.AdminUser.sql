CREATE TABLE [dbo].[AdminUser] (
    [AdminUserID]   INT          IDENTITY (1, 1) NOT NULL,
    [AdminUsername] VARCHAR (20) NOT NULL,
    [AdminPassword] VARCHAR (20) NOT NULL, 
    CONSTRAINT [PK_AdminUser] PRIMARY KEY ([AdminUserID])
);

