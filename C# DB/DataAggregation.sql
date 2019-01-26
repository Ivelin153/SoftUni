--1. Count all records
SELECT
	COUNT(*)
FROM 
	WizzardDeposits

--2. Longest magic wand
SELECT TOP (1)
	MagicWandSize AS LongestMagicWand
FROM
	WizzardDeposits
ORDER BY MagicWandSize DESC

--3. Longest magic wand per group
SELECT
	DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand
FROM
	WizzardDeposits
GROUP BY DepositGroup

--4. Smallest deposit group per wand size]
SELECT TOP(2)
	DepositGroup
FROM
	(SELECT
		DepositGroup,
		AVG(MagicWandSize) AS LongestMagicWand		
	FROM
		WizzardDeposits
	GROUP BY DepositGroup) AS ws
ORDER BY LongestMagicWand

--5. Deposit sums
SELECT
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM
	WizzardDeposits
GROUP BY DepositGroup

--6. Deposits sum for Ollivanders
SELECT
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM
	WizzardDeposits
WHERE 
	MagicWandCreator = 'Ollivander family'
GROUP BY 
	DepositGroup

--7. Deposits filter
SELECT
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM
	WizzardDeposits
WHERE 
	MagicWandCreator = 'Ollivander family'
GROUP BY 
	DepositGroup
HAVING 
	SUM(DepositAmount) < 150000
ORDER BY 
	TotalSum DESC

--8. Deposit charge
SELECT
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS MinDepositCharge
FROM 
	WizzardDeposits
GROUP BY 
	DepositGroup,
	MagicWandCreator
ORDER BY 
	MagicWandCreator,
	DepositGroup

--9. Age groups
SELECT 
	ag.AgeGroup,
	COUNT(*)  AS WizzardCount
FROM
	(SELECT 
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN Age >= 61 THEN '[61+]'
		END AS AgeGroup
	FROM WizzardDeposits) AS ag
GROUP BY ag.AgeGroup

--10. First letter
SELECT 
	SUBSTRING(FirstName,1,1) AS FirstLetter
FROM 
	WizzardDeposits
	
WHERE 
	DepositGroup = 'Troll Chest'
GROUP BY 
	SUBSTRING(FirstName,1,1)

--11. Average interest
SELECT
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM 
	WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY 
	DepositGroup,
	IsDepositExpired
ORDER BY 
	DepositGroup DESC,
	IsDepositExpired
GO
 
USE SoftUni
--13. Department total salaries
SELECT
	DepartmentID,
	SUM(Salary) AS TotalSalary
FROM
	Employees
GROUP BY
	DepartmentID
ORDER BY
	DepartmentID

--14. Employees minimum salary
SELECT
	DepartmentID,
	MIN(Salary) AS MinimumSalary
FROM
	Employees
WHERE 
	DepartmentID IN (2, 5, 7) 
	AND HireDate > '01/01/2000'
GROUP BY
	DepartmentID

--15. Employees average salaies
SELECT *
INTO NewEmployees
FROM
	Employees
WHERE Salary > 30000

DELETE FROM 
	NewEmployees
WHERE
	ManagerID = 42

UPDATE
	NewEmployees
SET 
	Salary += 5000
WHERE
	DepartmentID = 1

SELECT
	DepartmentID,
	AVG(Salary) AS AverageSalary
FROM
	NewEmployees
GROUP BY
	DepartmentID

--16. Employees maximum salaries
SELECT 
	DepartmentID,
	MAX(Salary) AS MaxSalary
FROM
	Employees
GROUP BY
	DepartmentID
HAVING 
	MAX(Salary) NOT BETWEEN 30000 AND 70000

--17. Employees count salaries
SELECT 
	COUNT(Salary) AS [Count]
FROM
	Employees
WHERE
	ManagerID IS NULL

--18. 3rd highest salary
SELECT 
	Salaries.DepartmentID,
	Salaries.Salary
FROM
	(SELECT
		DepartmentID,
		MAX(Salary) AS Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
	FROM 
		Employees
	GROUP BY DepartmentID, Salary) AS Salaries
WHERE [Rank] = 3

--19. Salary challange
SELECT TOP(10) 
	FirstName,
	LastName,
	DepartmentID 
FROM 
	Employees AS emp1
WHERE 
	Salary > 
	(SELECT 
		AVG(Salary) 
	FROM 
		Employees AS emp2
	WHERE 
		emp1.DepartmentID = emp2.DepartmentID
GROUP BY 
	DepartmentID)
ORDER BY 
	DepartmentID