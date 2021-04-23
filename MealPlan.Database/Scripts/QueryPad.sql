
declare @wantVeggie bit
declare @wantLowCarb bit

declare @PrepTimes TABLE
(
	Id INT
)

DECLARE @CarbTypeInclude TABLE
(
	Id INT
)

DECLARE @CarbTypeExclude TABLE
(
	Id INT
)

DECLARE @ProteinTypeInclude TABLE
(
	Id INT
)

DECLARE @ProteinTypeExclude TABLE
(
	Id INT
)



-- Set test values
INSERT INTO @PrepTimes(Id) VALUES(1)
INSERT INTO @PrepTimes(Id) VALUES(2)
INSERT INTO @PrepTimes(Id) VALUES(3)

-- INSERT INTO @CarbTypeInclude(Id) VALUES(4)

-- INSERT INTO @ProteinTypeExclude(Id) VALUES (4)

SET @wantVeggie = NULL
SET @wantLowCarb = NULL

-- QUERY
select distinct Meal.Id, Meal.Name, Cuisine.Name
from Meal
inner join MealCarbohydrateOption mco
	on meal.Id = mco.MealId
inner join CarbohydrateOption co
	on co.Id = mco.CarbohydrateOptionId
inner join MealProteinOption mpo
	on meal.Id = mpo.MealId
inner join ProteinOption po
	on po.id = mpo.ProteinOptionId
inner join Cuisine 
	on meal.CuisineId = Cuisine.Id
where (Meal.PreperationTimeId in (SELECT Id FROM @PrepTimes) OR (SELECT COUNT(Id) FROM @PrepTimes) = 0)

and (co.Id in (SELECT Id FROM @CarbTypeInclude) OR (SELECT COUNT(Id) FROM @CarbTypeInclude) = 0)
and (co.Id not in (SELECT Id FROM @CarbTypeExclude))

and (po.Id in (SELECT Id FROM @ProteinTypeInclude) OR (SELECT COUNT(Id) FROM @ProteinTypeInclude) = 0)
and (po.Id not in (SELECT Id FROM @ProteinTypeExclude))

and (co.IsLowCarbOption = @wantLowCarb OR @wantLowCarb IS NULL)
and (po.IsVegetarian = @wantVeggie OR @wantVeggie IS NULL)
order by Cuisine.Name, Meal.Name