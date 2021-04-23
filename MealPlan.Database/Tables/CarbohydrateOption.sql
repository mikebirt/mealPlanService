CREATE TABLE [dbo].[CarbohydrateOption]
(
	[Id] INT IDENTITY(1,1), 
    [Name] NVARCHAR(250) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [IsLowCarbOption] BIT NOT NULL,
    CONSTRAINT [PK_CarbOption] PRIMARY KEY CLUSTERED ([Id] ASC), 
)
