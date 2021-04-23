CREATE TABLE [dbo].[PreperationTime]
(
	[Id] INT IDENTITY(1,1), 
    [Name] NVARCHAR(250) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_PrepTime] PRIMARY KEY CLUSTERED ([Id] ASC), 
)
