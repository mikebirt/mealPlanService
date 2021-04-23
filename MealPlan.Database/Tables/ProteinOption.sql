CREATE TABLE [dbo].[ProteinOption]
(
	[Id] INT IDENTITY(1,1), 
    [Name] NVARCHAR(250) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [IsVegetarian] BIT NOT NULL,
    CONSTRAINT [PK_ProteinOption] PRIMARY KEY CLUSTERED ([Id] ASC), 
)
