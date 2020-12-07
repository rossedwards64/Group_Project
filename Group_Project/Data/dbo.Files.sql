CREATE TABLE [dbo].[Files] (
    [FileUploader] VARCHAR (MAX) NOT NULL,
    [FileName]     VARCHAR (MAX) NOT NULL,
    [Date]         DATE          NOT NULL, 
    [FileID] INT NOT NULL, 
    CONSTRAINT [PK_Files] PRIMARY KEY ([FileID])
);

