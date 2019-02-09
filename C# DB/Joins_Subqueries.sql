USE SoftUni

--1. Employee Address
SELECT TOP 5
	e.EmployeeID,
	e.JobTitle,
	a.AddressID,
	a.AddressText
FROM
	Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY AddressID 


--2. Adresses with Towns
SELECT TOP 50
	e.FirstName,
	e.LastName,
	t.Name AS Town,
	a.AddressText
FROM
	Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY 
	FirstName,
	LastName

--3. Sales Employee
SELECT
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name]
FROM
	Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE 
	d.[Name] = 'Sales'
ORDER BY EmployeeID

--4. Employee departments
SELECT TOP 5
	EmployeeID,
	FirstName,
	Salary,
	d.[Name]
FROM
	Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE 
	e.Salary > 15000
ORDER BY d.DepartmentID

--5. Employees without project
SELECT TOP 3
	e.EmployeeID,
	FirstName
FROM 
	Employees AS e
FULL JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--6. Employees hired after
SELECT 
	FirstName,
	LastName,
	HireDate,
	d.[Name]
FROM
	Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE HireDate > '01.01.1999' AND [Name] IN ('Sales', 'Finance')
ORDER BY HireDate

--7. Employees with projects
SELECT TOP 5
	e.EmployeeID,
	FirstName,
	P.[Name] AS ProjectName
FROM
	Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--8. Employee 24
SELECT
	e.EmployeeID,
	FirstName,
	IIF(p.StartDate > '2005-01-01', NULL, p.Name) AS ProjectName
FROM
	Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID  = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--9. Employee manager
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	emp.FirstName AS ManagerName
FROM
	Employees AS e
JOIN Employees AS emp ON emp.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

--10. Employee summary
SELECT TOP 50
	e.EmployeeID,
	(e.FirstName + ' ' + e.LastName) AS EmployeeName,
	(emp.FirstName + ' ' + emp.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
FROM
	Employees AS e
JOIN Employees AS emp ON emp.EmployeeID = e.ManagerID
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID

--11. Min average salary
SELECT TOP 1 
	AVG(Salary) AS MinAverageSalary
FROM 
	Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary

USE Geography
--12. Highest peaks in Bulgaria
SELECT
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM
	Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13. Count mountain ranges
SELECT
	c.CountryCode,
	COUNT(m.MountainRange) AS MountainRanges
FROM
	Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryCode IN('BG', 'RU', 'US')
GROUP BY c.CountryCode

--14. Countries with rivers
SELECT TOP 5
	c.CountryName,
	r.RiverName
FROM
	Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15. Continets and currencies
WITH CCYContUsage_CTE (ContinentCode, CurrencyCode, CurrencyUsage) AS (
	SELECT 
		ContinentCode,
		CurrencyCode,
		COUNT(CountryCode) AS CurrencyUsage
	FROM 
		Countries 
	GROUP BY ContinentCode, CurrencyCode
	HAVING COUNT(CountryCode) > 1  
)
SELECT 
	ContMax.ContinentCode,
	ccy.CurrencyCode,
	ContMax.CurrencyUsage 
FROM
    (SELECT 
		ContinentCode,
		MAX(CurrencyUsage) AS CurrencyUsage
	FROM CCYContUsage_CTE 
	GROUP BY ContinentCode) AS ContMax
JOIN CCYContUsage_CTE AS ccy 
ON (ContMax.ContinentCode = ccy.ContinentCode AND ContMax.CurrencyUsage = ccy.CurrencyUsage)
ORDER BY ContMax.ContinentCode

--16. Countries without mountains
SELECT
	COUNT(*) AS CountryCode
FROM
	Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL

--17. Highest Peak and Longest River by Country
SELECT TOP 5
	CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.[Length]) AS LongestRiverLength
FROM
	Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Peaks AS p ON p.MountainId = mc.MountainId
JOIN CountriesRivers AS rc ON rc.CountryCode = c.CountryCode
JOIN Rivers AS r ON r.Id = rc.RiverId
GROUP BY c.CountryName
ORDER BY 
	HighestPeakElevation DESC,
	LongestRiverLength DESC,
	c.CountryName