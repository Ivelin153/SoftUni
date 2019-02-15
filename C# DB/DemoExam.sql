--1. DDL
CREATE DATABASE ColonialJourney
USE ColonialJourney
CREATE TABLE Planets(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)
 
CREATE TABLE Spaceports(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id)
)

CREATE TABLE Spaceships(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT (0)
)

CREATE TABLE Colonists(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) CHECK(Purpose IN('Medical','Technical','Educational','Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id),
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id)
)

CREATE TABLE TravelCards(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber VARCHAR(10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8) CHECK (JobDuringJourney IN('Pilot','Engineer','Trooper','Cleaner','Cook')),
	ColonistId INT NOT NULL FOREIGN KEY REFERENCES Colonists(Id),
	JourneyId INT NOT NULL FOREIGN KEY REFERENCES Journeys(Id)
)


--2. Insert
INSERT INTO Planets VALUES
	('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')

INSERT INTO Spaceships VALUES
	('Golf', 'VW', 3),
	('WakaWaka', 'Wakanda', 4),
	('Falcon9', 'SpaceX', 1),
	('Bed', 'Vidolov', 6)

--3. Update
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

--4. Delete
DELETE FROM TravelCards
WHERE JourneyId IN (1, 2, 3)

DELETE FROM Journeys
WHERE Id IN (1, 2, 3)

--SECTION 3. QUERYING 
--5. Select all travel cards
SELECT
	CardNumber,
	JobDuringJourney
FROM TravelCards
ORDER BY CardNumber ASC

--6.
SELECT 
	Id,
	(CONCAT(FirstName, ' ', LastName)) AS FullName,
	Ucn
FROM Colonists
ORDER BY 
	FirstName,
	LastName,
	Id ASC

--7.
SELECT 
	Id,
	CONVERT(varchar, JourneyStart, 103) AS JourneyStart,
	CONVERT(varchar, JourneyEnd, 103) AS JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

--8. Select all pilots
SELECT
	c.Id,
	CONCAT(FirstName, ' ', LastName) AS full_name
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id ASC

--9. Count colonists
SELECT 
	COUNT(*)
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
JOIN Journeys AS j ON j.Id = tc.JourneyId
WHERE j.Purpose = 'Technical'

--10. Select the fastest spaceship
SELECT TOP 1
	ss.[Name] AS SpaceshipName,
	sp.[Name] AS SpaceportName
FROM Spaceships AS ss
JOIN Journeys AS j ON j.SpaceshipId = ss.Id
JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId

--11. Select spaceships with pilots younger than 30y
SELECT 
	ss.[Name],
	ss.Manufacturer
FROM Spaceships AS ss
JOIN Journeys AS j ON j.SpaceshipId = ss.Id
JOIN TravelCards AS tc ON tc.JourneyId = j.Id
JOIN Colonists AS c ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot' 
	AND DATEDIFF(YEAR, c.BirthDate, GETDATE()) < 30
ORDER BY ss.[Name]

--12. Select all educational mission
SELECT
	p.[Name],
	sp.[Name]
FROM Planets AS p
JOIN Spaceports AS sp ON sp.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
WHERE j.Purpose = 'Educational'
ORDER BY sp.[Name] DESC

--13.
SELECT 
	p.[Name],
	COUNT(j.DestinationSpaceportId) AS JourneysCount
FROM Planets AS p
JOIN Spaceports AS sp ON sp.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
GROUP BY p.[Name]
ORDER BY 
	JourneysCount DESC,
	p.[Name]

--14. Select the shortest journey
SELECT TOP 1
	j.Id,
	p.[Name],
	sp.[Name] AS SpaceportName,
	j.Purpose AS JourneyPurpose
FROM Journeys AS j
JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
JOIN Planets AS p ON p.Id = sp.PlanetId
ORDER BY DATEDIFF(SECOND, j.JourneyStart, j.JourneyEnd) ASC

--15. Select the less popular job
SELECT TOP(1) 
	tc.JourneyId,
	tc.JobDuringJourney AS JobName
FROM TravelCards AS tc
WHERE tc.JourneyId = (SELECT TOP(1) j.Id FROM Journeys AS j ORDER BY DATEDIFF(MINUTE, j.JourneyStart, j.JourneyEnd) DESC)
GROUP BY tc.JobDuringJourney, tc.JourneyId
ORDER BY COUNT(tc.JobDuringJourney)

--16.
SELECT
	k.JobDuringJourney,
	c.FirstName + ' ' + c.LastName AS FullName,
	k.JobRank
FROM (
	SELECT tc.JobDuringJourney AS JobDuringJourney, tc.ColonistId,
		RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY co.Birthdate ASC) AS JobRank
	FROM TravelCards AS tc
	JOIN Colonists AS co ON co.Id = tc.ColonistId
	GROUP BY tc.JobDuringJourney, co.Birthdate, tc.ColonistId
) AS k
JOIN Colonists AS c ON c.Id = k.ColonistId
WHERE k.JobRank = 2
ORDER BY k.JobDuringJourney

--17.
 SELECT 
	p.[Name], 
	COUNT(s.[Name]) AS [Count]
FROM Planets AS p
LEFT JOIN Spaceports AS s ON s.PlanetId = p.Id
GROUP BY p.Name
ORDER BY [Count] DESC, [Name] ASC

GO
--18.
CREATE FUNCTION dbo.udf_GetColonistsCount (@planetName VARCHAR(30))
RETURNS INT 
AS
BEGIN
	RETURN 
		(SELECT 
			COUNT(*) 
		FROM Journeys AS j
		JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
		JOIN Planets AS p ON p.Id = s.PlanetId
		JOIN TravelCards AS tc ON tc.JourneyId = j.Id
		JOIN Colonists AS c ON c.Id = tc.ColonistId
		WHERE p.Name = @planetName)
END

--19. Change Journey Purpose 
GO
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(30))
AS
BEGIN
	DECLARE @TargetJourneyId INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)

	IF (@TargetJourneyId IS NULL)
	BEGIN
		;THROW 51000, 'The journey does not exist!', 1
	END

	DECLARE @CurrentJourneyPurpose VARCHAR(30) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

	IF (@CurrentJourneyPurpose = @NewPurpose)
	BEGIN
		;THROW 51000, 'You cannot change the purpose!', 2
	END

	UPDATE Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @JourneyId
END

--20. Deleted Journeys
CREATE TABLE DeletedJourneys
(
	Id INT,
	JourneyStart DATETIME,
	JourneyEnd DATETIME,
	Purpose VARCHAR(11),
	DestinationSpaceportId INT,
	SpaceshipId INT
)
GO
CREATE TRIGGER t_DeleteJourney
	ON Journeys
	AFTER DELETE
AS
	BEGIN
		INSERT INTO DeletedJourneys(Id,JourneyStart,JourneyEnd,Purpose,DestinationSpaceportId,
		SpaceshipId)
		SELECT 
			Id,
			JourneyStart,
			JourneyEnd,
			Purpose,
			DestinationSpaceportId,
			SpaceshipId
		FROM deleted
	END
