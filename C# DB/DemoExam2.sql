
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Price DECIMAL(15,2) NOT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id)
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone VARCHAR(12) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL
)

CREATE TABLE Orders(
	Id INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME NOT NULL,
	EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id)
)

CREATE TABLE OrderItems(
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(Id),
	ItemId INT NOT NULL FOREIGN KEY REFERENCES Items(Id),
	Quantity INT NOT NULL CHECK (Quantity > 0),
	PRIMARY KEY (OrderId, ItemId)
)
CREATE TABLE Shifts(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME NOT NULL,	
	CONSTRAINT PK_Shifts PRIMARY KEY (Id, EmployeeId),
	CONSTRAINT WorkTime CHECK (CheckOut > CheckIn)
)

--2. Insert
INSERT INTO Employees VALUES
	('Stoyan', 'Petrov', '888-785-8573', 500.25),
	('Stamat', 'Nikolov', '789-613-1122', 999995.25),
	('Evgeni', 'Petkov', '645-369-9517', 1234.51),
	('Krasimir', 'Vidolov', '321-471-9982', 50.25)

INSERT INTO Items VALUES
	('Tesla battery', 154.25, 8),
	('Chess', 30.25, 8),
	('Juice', 5.32, 1),
	('Glasses', 10, 8),
	('Bottle of water', 1, 1)

UPDATE Items
SET Price *= 1.27
WHERE CategoryId IN (1, 2, 3)

DELETE FROM OrderItems
WHERE OrderId = 48


--5. Richest people
SELECT
	Id,
	FirstName
FROM Employees
WHERE Salary > 6500
ORDER BY FirstName, Id

--6. COOL PHONE NUMBERS
SELECT 
	CONCAT(FirstName, ' ', LastName) AS [Full Name],
	Phone AS [Phone Number]
FROM Employees
WHERE SUBSTRING(Phone, 1, 1) = 3
ORDER BY FirstName ASC, [Phone Number] ASC

--7. Employees statistic
SELECT 
	FirstName,
	LastName,
	COUNT(o.EmployeeId) AS [Count]
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY o.EmployeeId, FirstName, LastName
ORDER BY [Count] DESC, FirstName

--8. Hard workers
SELECT
	FirstName,
	LastName,
	AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS WorkHours
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY FirstName, LastName, e.Id, s.EmployeeId
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
ORDER BY WorkHours DESC, EmployeeId ASC

--9. Most expensive order
SELECT TOP 1
	o.Id,
	SUM(i.Price * oi.Quantity) AS [TotalPrice]
FROM Orders As o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items As i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY TotalPrice DESC

SELECT TOP 10
	o.Id AS OrderId,
	MAX(i.Price) AS ExpensivePrice,
	MIN(i.Price) AS CheapPrice
FROM Orders As o
  JOIN OrderItems AS oi ON oi.OrderId = o.Id
  JOIN Items As i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY ExpensivePrice DESC, o.Id ASC

--11. Cashiers
SELECT DISTINCT
	e.Id,
	e.FirstName,
	e.LastName
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
ORDER BY e.Id

--12. Lazy Employees
SELECT DISTINCT
	e.Id,
	CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
ORDER BY e.Id ASC

--13. Sellers
SELECT TOP 10
	CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
	SUM(i.Price * oi.Quantity) AS [Total Price],
	SUM(oi.Quantity) AS [Items]
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
WHERE o.[DateTime] < '2018-06-15'
GROUP BY e.Id, e.FirstName, e.LastName
ORDER BY [Total Price] DESC, Items DESC

--14. Tough days
SELECT
	CONCAT(FirstName, ' ', LastName) AS [Full Name],
	CASE
	WHEN DATEPART(WEEKDAY, s.CheckIn) = 1
		THEN 'Sunday'
	WHEN DATEPART(WEEKDAY, s.CheckIn) = 2
		THEN 'Monday'	
	WHEN DATEPART(WEEKDAY, s.CheckIn) = 3
		THEN 'Tuesday'	
	WHEN DATEPART(WEEKDAY, s.CheckIn) = 4
		THEN 'Wednesday'
	WHEN DATEPART(WEEKDAY, s.CheckIn) = 5
		THEN 'Thursday'	
	WHEN DATEPART(WEEKDAY, s.CheckIn) = 6
		THEN 'Friday'
	WHEN DATEPART(WEEKDAY, s.CheckIn) = 7
		THEN 'Saturday'	
	END AS [Day of week]
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12 AND o.EmployeeId IS NULL
ORDER BY e.Id

--15. Top order per employee
SELECT
	emp.FirstName + ' ' + emp.LastName AS FullName,
	DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours,
	e.TotalPrice AS TotalPrice 
FROM 
(
	SELECT
		o.EmployeeId,
		SUM(oi.Quantity * i.Price) AS TotalPrice,
		o.[DateTime],
	ROW_NUMBER() OVER (PARTITION BY o.EmployeeId ORDER BY o.EmployeeId, SUM(i.Price * oi.Quantity) DESC ) AS Rank
    FROM Orders AS o
    JOIN OrderItems AS oi ON oi.OrderId = o.Id
    JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.EmployeeId, o.Id, o.[DateTime]
) AS e 
JOIN Employees AS emp ON emp.Id = e.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = e.EmployeeId
WHERE e.[Rank] = 1 AND e.DateTime BETWEEN s.CheckIn AND s.CheckOut
ORDER BY FullName, WorkHours DESC, TotalPrice DESC

--16. Average profit per day
SELECT 
	DATEPART(DAY, o.[DateTime]) AS [DayOfMonth],
	CAST(AVG(i.Price * oi.Quantity) AS decimal(15,2)) AS TotalProfit
FROM ORDERS AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.[DateTime])
ORDER BY DayOfMonth ASC

--17. Top products
SELECT
	i.[Name] AS [Item],
	c.[Name] AS [Category],
	SUM(oi.Quantity) AS [Count],
	SUM(i.Price * oi.Quantity) AS TotalPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
RIGHT JOIN Items AS i ON i.Id = oi.ItemId
JOIN Categories AS c ON c.Id = i.CategoryId
GROUP BY i.Name, c.Name
ORDER BY TotalPrice DESC, [Count] DESC

--18. Promotion days
CREATE FUNCTION udf_GetPromotedProducts(
	@currentDate DATETIME,
	@startDate DATETIME,
	@endDate DATETIME,
	@discount INT,
	@firstItemId INT,
	@secondItemId INT,
	@thirdItemId INT
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @firstItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @firstItemId)
	DECLARE @secondItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @secondItemId)
	DECLARE @thirdItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @thirdItemId)

	IF(@firstItemPrice IS NULL OR @secondItemPrice IS NULL OR @thirdItemPrice IS NULL)
	BEGIN
		RETURN 'One of the items does not exists!'
	END

	IF (@currentDate <= @startDate OR @currentDate >= @endDate)
	BEGIN
		RETURN 'The current date is not within the promotion dates!'
	END

	DECLARE @newFirstItemPrice DECIMAL(15,2) = @firstItemPrice - (@firstItemPrice * @discount / 100)
	DECLARE @newSecondItemPrice DECIMAL(15,2) = @secondItemPrice - (@secondItemPrice * @discount / 100)
	DECLARE @newThirdItemPrice DECIMAL(15,2) = @thirdItemPrice - (@thirdItemPrice * @discount / 100)

	DECLARE @firstItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @firstItemId)
	DECLARE @secondItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @secondItemId)
	DECLARE @thirdItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @thirdItemId)

	RETURN @firstItemName + ' price: ' + CAST(ROUND(@newFirstItemPrice,2) as varchar) + ' <-> ' +
		   @secondItemName + ' price: ' + CAST(ROUND(@newSecondItemPrice,2) as varchar)+ ' <-> ' +
		   @thirdItemName + ' price: ' + CAST(ROUND(@newThirdItemPrice,2) as varchar)
END

--19
CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
AS
BEGIN
	DECLARE @order INT = (SELECT Id FROM Orders WHERE Id = @OrderId)

	IF (@order IS NULL)
	BEGIN
		;THROW 51000, 'The order does not exist!', 1
	END

	DECLARE @OrderDate DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)
	DECLARE @DateDiff INT = (SELECT DATEDIFF(DAY, @OrderDate, @CancelDate))

	IF (@DateDiff > 3)
	BEGIN
		;THROW 51000, 'You cannot cancel the order!', 2
	END

	DELETE FROM OrderItems
	WHERE OrderId = @OrderId

	DELETE FROM Orders
	WHERE Id = @OrderId
END



--20 Cancel order
CREATE TABLE DeletedOrders
(
	OrderId INT,
	ItemId INT,
	ItemQuantity INT
)

GO
CREATE TRIGGER t_DeleteOrders
    ON OrderItems AFTER DELETE
    AS
    BEGIN
	  INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity)
	  SELECT d.OrderId, d.ItemId, d.Quantity
	    FROM deleted AS d
    END

