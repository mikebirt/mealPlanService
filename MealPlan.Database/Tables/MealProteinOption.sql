CREATE TABLE [dbo].[MealProteinOption]
(
    [MealId] INT NOT NULL,
    [ProteinOptionId] INT NOT NULL,
    CONSTRAINT [FK_MealProteinOption_Meal] FOREIGN KEY ([MealId]) REFERENCES [Meal] ([Id]),
    CONSTRAINT [FK_MealProteinOption_ProteinOption] FOREIGN KEY ([ProteinOptionId]) REFERENCES [ProteinOption] ([Id]), 
    CONSTRAINT [PK_MealProteinOption] PRIMARY KEY ([MealId], [ProteinOptionId])
)
