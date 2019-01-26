USE SoftUni

--1. Find names starting with "SA"
SELECT
	FirstName,
	LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

--2. Last names containing "ei"
SELECT
	FirstName,
	LastName
FROM Employees
WHERE LastName LIKE '%EI%'

--3. First names by condition
SELECT
	FirstName
FROM Employees
WHERE DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005 AND DepartmentID IN(3, 10)

--4. Find all except engineers
SELECT
	FirstName,
	LastName 
FROM Employees
WHERE JobTitle NOT LIKE '%ENGINEER%'

--5. Find towns with name length
SELECT
	[Name]
FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

--6. Find towns starting with 'M, K, B'
SELECT
	TownID,
	[Name]
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

--7. Find towns not starting with letters
SELECT
	TownID,
	[Name]
FROM Towns
WHERE [Name] NOT LIKE '[!RBD]%'
ORDER BY [Name]

GO
--8. Create view employees hired after 2000 year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT
	FirstName,
	LastName
FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000
GO
--9. Length of last name
SELECT
	FirstName,
	LastName
FROM Employees
WHERE LEN(LastName) = 5

--10. Rank employees by salary
SELECT
	EmployeeID,
	FirstName,
	LastName,
	Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE  Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

USE Geography
--12 Countries holding 'a' 3 or more times
SELECT CountryName,
       IsoCode AS [ISO Code]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode;

--13. Mix of names
SELECT Peaks.PeakName,
       Rivers.RiverName,
       LOWER(CONCAT(LEFT(Peaks.PeakName, LEN(Peaks.PeakName)-1), Rivers.RiverName)) AS Mix
FROM Peaks
     JOIN Rivers ON RIGHT(Peaks.PeakName, 1) = LEFT(Rivers.RiverName, 1)
ORDER BY Mix;

--14 Games from 2011 and 2012
USE Diablo

SELECT TOP(50)
	[Name],
	FORMAT(CAST([Start] AS DATE), 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) IN (2011, 2012)
ORDER BY [Start], [Name]

--15. User email providers
SELECT
	Username,
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], [Username]

--16. Users ip addreses
SELECT
	Username,
	IpAddress AS [IP Address]	
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17. Show all games duration
SELECT 
	[Name] AS [Game],
       CASE
           WHEN DATEPART(HOUR, Start) BETWEEN 0 AND 11
           THEN 'Morning'
           WHEN DATEPART(HOUR, Start) BETWEEN 12 AND 17
           THEN 'Afternoon'
           WHEN DATEPART(HOUR, Start) BETWEEN 18 AND 23
           THEN 'Evening'
           ELSE 'N\A'
       END AS [Part of the Day],
       CASE
           WHEN Duration <= 3
           THEN 'Extra Short'
           WHEN Duration BETWEEN 4 AND 6
           THEN 'Short'
           WHEN Duration > 6
           THEN 'Long'
           WHEN Duration IS NULL
           THEN 'Extra Long'
           ELSE 'Error - must be unreachable case'
       END AS [Duration]
FROM Games
ORDER BY [Name], [Duration], [Part of the Day]