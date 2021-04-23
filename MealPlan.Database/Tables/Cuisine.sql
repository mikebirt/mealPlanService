CREATE TABLE [dbo].[Cuisine]
(
	[Id] INT IDENTITY(1,1), 
    [Name] NVARCHAR(250) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_Cuisine] PRIMARY KEY CLUSTERED ([Id] ASC), 
)
