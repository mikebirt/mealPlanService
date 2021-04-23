CREATE TABLE [dbo].[Meal]
(
	[Id] INT IDENTITY(1,1), 
    [Name] NVARCHAR(500) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [CuisineId] INT NOT NULL,
    [PreperationTimeId] INT NOT NULL,
    CONSTRAINT [FK_Meal_Cuisine] FOREIGN KEY ([CuisineId]) REFERENCES [Cuisine] ([Id]),
    CONSTRAINT [FK_Meal_PreperationTime] FOREIGN KEY ([PreperationTimeId]) REFERENCES [PreperationTime] ([Id]),
    CONSTRAINT [PK_Meal] PRIMARY KEY CLUSTERED ([Id] ASC), 
)
