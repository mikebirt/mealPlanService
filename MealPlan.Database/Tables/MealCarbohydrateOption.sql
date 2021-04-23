CREATE TABLE [dbo].[MealCarbohydrateOption]
(
    [MealId] INT NOT NULL,
    [CarbohydrateOptionId] INT NOT NULL,
    CONSTRAINT [FK_MealCarbohydrateOption_Meal] FOREIGN KEY ([MealId]) REFERENCES [Meal] ([Id]),
    CONSTRAINT [FK_MealCarbohydrateOption_CarbohydrateOption] FOREIGN KEY ([CarbohydrateOptionId]) REFERENCES [CarbohydrateOption] ([Id]),
    CONSTRAINT [PK_MealCarbohydrateOption] PRIMARY KEY ([MealId], [CarbohydrateOptionId])
)
