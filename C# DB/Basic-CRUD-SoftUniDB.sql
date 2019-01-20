USE SoftUni

--2. Find Info about departments
SELECT * FROM Departments

--3.Find All departmants names
SELECT [Name] FROM Departments


--3. Find Salary of Each Employee
SELECT 
	FirstName,
	LastName,
	Salary 
FROM 
	Employees

--4. Find Fullname
SELECT 
	FirstName,
	MiddleName,
	LastName 
FROM 
	Employees

--5. Find email address
SELECT 
	FirstName + '.' + "LastName" + '@softuni.bg' AS [Full Email Address]
FROM
	Employees

--6. Find all different salaries
SELECT DISTINCT
	Salary
FROM 
	Employees

--7. Find all info about employee by job title
SELECT 
	*
FROM
	Employees
WHERE 
	JobTitle = 'Sales Representative'

--8. Find names of all employees by salary in range
SELECT
	FirstName,
	LastName,
	JobTitle
FROM
	Employees
WHERE Salary BETWEEN 20000 AND 30000

--9. Full names of employees
SELECT
	FirstName +
	' ' +
	MiddleName +
	' ' +
	LastName AS [Full Name]
FROM 
	Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--10. Employees without manager
SELECT
	FirstName,
	LastName
FROM 
	Employees
WHERE
	ManagerID IS NULL

--11. Salary more than 50 000
SELECT
	FirstName,
	LastName,
	Salary
FROM
	Employees
WHERE
	Salary > 50000
ORDER BY Salary DESC

--12. Best paid employees
SELECT TOP(5)
	FirstName,
	LastName
FROM
	Employees
ORDER BY Salary DESC

--13. Find all except marketing department
SELECT
	FirstName,
	LastName
FROM 
	Employees
WHERE
	DepartmentID <> 4

--14. Sort employees table
SELECT
	*
FROM
	Employees
ORDER BY 
	Salary DESC,
	FirstName ASC,
	LastName DESC,
	MiddleName ASC

GO
--15. Create view with employees salaries
CREATE VIEW V_EmployeesSalaries AS
SELECT
	FirstName,
	LastName,
	Salary
FROM
	Employees

GO
--16. Create view with job titles
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT
	FirstName + ' ' +
	ISNULL(MiddleName, '')
	+ ' ' + LastName AS [Full Name],
	JobTitle
FROM
	Employees
GO

--17. Distinct job titles
SELECT DISTINCT
	JobTitle
FROM
	Employees

--18. Find first 10 started projects
SELECT TOP(10)
	*
FROM
	Projects ORDER BY StartDate, [Name]

--19. Last 7 hired employees
SELECT TOP(7)
	FirstName,
	LastName,
	HireDate
FROM
	Employees ORDER BY HireDate DESC

--20. Increase salaries
UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentID IN (1, 2, 4, 11)

SELECT
	  Salary
FROM 
	Employees

