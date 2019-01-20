--1. Create Database
CREATE DATABASE Minions
USE Minions

--2. Create Tables
CREATE TABLE Minions(
Id INT PRIMARY KEY,
[Name] NVARCHAR(20) NOT NULL,
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] NVARCHAR(20) NOT NULL
)

--3. Alter Minions table
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--4. Insert Records in tables
INSERT INTO Towns(Id, [Name])
VALUES (1,'Sofia'),
		(2,'Plovdiv'),
		(3, 'Varna')


INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES (1, 'Kevin', 22, 1),
		(2, 'Bob', 15, 3),
		(3, 'Steward', NULL, 2)

--6.Drop all tables
DROP TABLE Towns
DROP TABLE Minions

--7.Create Table People
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY NOT NULL CHECK (Id < 2147483647),
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY CHECK (DATALENGTH(Picture)<900*1024),
	Height DECIMAL(10,2),
	[Weight] DECIMAL(10,2),
	Gender CHAR(1) NOT NULL CHECK (Gender = 'm' OR Gender = 'f'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX) 
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
		('Ivelin', NULL, 1.80, 77, 'm', '07-04-1998', NULL),	
		('Minka', NULL, 1.56, 50, 'f', '12-05-1988', NULL),	
		('Pesho', NULL, 1.65, 65, 'm', '11-11-1968', NULL),	
		('Ivan', NULL, 1.93, 101, 'm', '05-04-1978', NULL),	
		('Kolio', NULL, 1.92, 120, 'm', '12-12-1992', NULL)

--8. Creat Table Users
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY NOT NULL CHECK (Id < 2147483647),
	Username VARCHAR(30) NOT NULL UNIQUE,
	Password VARCHAR(26) NOT NULL, 
	ProfilePicture VARBINARY CHECK (DATALENGTH(ProfilePicture)<900*1024),
	LastLoginTime DATE,
	IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Ivelin', 'aswwwerwerwdfghjk', NULL, CONVERT(datetime,'11-01-2018',103), 'true'),
('Gosho', 'qwerrewrerwretyu', NULL, CONVERT(datetime,'11-02-2018',103), 'true'),
('Ivan', 'zxcvbnmrewrerwer', NULL, CONVERT(datetime,'11-03-2018',103), 'true'),
('Mitko', 'qazwsxedcrfveee', NULL, CONVERT(datetime,'11-04-2018',103), 'true'),
('Valio', 'tgbyhnujmiklop', NULL, CONVERT(datetime,'11-05-2018',103), 'true')

--9. Change PK
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id, UserName)

--10. Add Check for password
ALTER TABLE Users
ADD CONSTRAINT PasswordMinLenght
CHECK (LEN([Password]) > 5)

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
('goshko', '1234', NULL, CONVERT(datetime,'11-01-2018',103), 'true')

--11. Set default values
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

--12. Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT uc_Username UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT uc_UsernameLength
CHECK (LEN(Username) >= 3)

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
('iv', '1234567', NULL, CONVERT(datetime,'21-02-2018',103), 'true')

--13. Movies Database

CREATE DATABASE Movies

Use Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
)

CREATE TABLE GENRES(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(40) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id), 
	CopyrightYear DATE,
	[Length] BIGINT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	Rating INT,
	Notes NVARCHAR(MAX)
)


INSERT INTO Directors (DirectorName, Notes) VALUES
('Director 1', 'The best of all'),
('Director 2', 'top director'),
('Director 3', 'good director'),
('Director 4', 'bad director'),
('Director 5', 'not for this job')

INSERT INTO Genres(GenreName, Notes) VALUES
('comedy', 'haha'),
('thriller', 'sob'),
('drama', 'not a single emotion'),
('action', 'presure'),
('documentary', 'thinking')

INSERT INTO Categories(CategoryName, Notes) VALUES
('smart', 'thinking'),
('stupid', 'staying'),
('nice', 'smiling'),
('good', 'happy'),
('bad', 'angry')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, Rating, Notes) VALUES
('Undercover', 1, '1990', '103', 1, 6, 'Get out'),
('The Mask', 2, '1992', '103', 2, 7, 'Lets go'),
('FastnFurious', 3, '1994', '103', 3, 8, 'Move on'),
('The Predator', 4, '1996', '103', 4, 9, 'Get low'),
('Genesis', 5, '1998', '103', 5, 10, 'Get up')

--14. Car Rental DB

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50),
	DailyRate DECIMAL(5, 2) NOT NULL,
	WeeklyRate DECIMAL(5, 2) NOT NULL,
	MonthlyRate DECIMAL(5, 2) NOT NULL,
	WeekendRate DECIMAL(5, 2) NOT NULL
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Cabrio', 8.54, 4.65, 6.44, 3.23),
('Hatch-back', 8.54, 5.65, 5.44, 7.23),
('Sedan', 8.54, 7.32, 7.44, 5.23)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber VARCHAR(8),
	Manufacturer VARCHAR(30),
	Model VARCHAR(30),
	CarYear DATE,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors REAL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(100),
	Available BIT
)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available) VALUES
('X 1111 C', 'Audi', 'a3', '11-11-2006', 1, 2, 'USED', 1),
('X 2222 K', 'Audi', 'a6', '11-12-2010', 2, 4, 'USED', 1),
('C 3434 C', 'Audi', 'A8', '11-11-2017', 3, 4, 'USED', 1)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(30),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName) VALUES
('Ivelin', 'Todorov'),
('Georgi', 'Ivanov'),
('Mitko', 'Dimitrov')

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber NVARCHAR(15) NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	Address NVARCHAR(500),
	City NVARCHAR(50),
	ZIPCode NVARCHAR(10),
	Notes NVARCHAR(200)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
('B2', 'Shisho Bakshisho','Studentski grad', 'Sofia', '1000', 'Gotin'),
('B2', 'Petar Petrov','Mladost', 'Sofia', '1112', 'Pechen'),
('B2', 'Dimitar Dimitrov','Mladost', 'Sofia', '1113', 'Smotan')

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE,
	EndDate DATE,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied INT,
	TaxRate DECIMAL(5, 2),
	OrderStatus NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, StartDate, EndDate) VALUES
(3, 2, '11-11-1990', '11-11-1990'),
(1, 1, '11-11-1990', '11-11-1990'),
(2, 3, '11-11-1990', '11-11-1990')

--15.Hotel Database
CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(100),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName) VALUES
('Ivelin', 'Todorov'),
('Georgi', 'Ivanov'),
('Mitko', 'Dimitrov')

CREATE TABLE Customers (
	AccountNumber INT UNIQUE IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber INT,
	EmergencyName NVARCHAR(100),
	EmergencyNumber INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (FirstName, LastName) VALUES
('Georgi', 'Ivanov'),
('Mitko', 'Dimitrov'),
('Petko', 'Petkov')

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus) VALUES
('Free'),
('Cleaning'),
('Busy')

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType) VALUES
('1 people'),
('2 people'),
('3 people')

CREATE TABLE BedTypes (
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes (BedType) VALUES
('One Person'),
('Two Person'),
('Three Person')

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(6,2),
	RoomStatus NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (Rate) VALUES
(2.50),
(7.50),
(10.00)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT,
	PaymentDate DATE,
	AccountNumber INT,
	FirstDateOccipied DATE,
	LastDateOccupied DATE,
	TotalDays AS DATEDIFF(DAY, FirstDateOccipied, LastDateOccupied),
	AmountCharged DECIMAL(10, 2),
	TaxRate DECIMAL(6, 2),
	TaxAmount DECIMAL(6, 2),
	PaymentTotal DECIMAL(12, 2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged) VALUES
(1, GETDATE(), 100.50),
(2, GETDATE(), 200.50),
(3, GETDATE(), 300.50)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT,
	DateOccipied DATE,
	AccountNumber INT,
	RoomNumber INT,
	RateApplied DECIMAL(6, 2),
	PhoneCharge DECIMAL(10, 2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, RateApplied, Notes) VALUES
(1, 8.00, 'okay'),
(2, 9.00, 'perfect'),
(3, 5.00, 'not god')

--16. SoftUni DB

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL
)

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText NVARCHAR(50) NOT NULL,
	TownId INT CONSTRAINT FK_Addresses_Town FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30)
)

CREATE TABLE Employees (	
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	MiddleName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT CONSTRAINT FK_Employees_Department FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT CONSTRAINT FK_Employees_Addresses FOREIGN KEY REFERENCES Addresses(Id)
)

--17. Backup DB
BACKUP DATABASE [SoftUni] 
	TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\SoftUni.bak' 
	WITH NOFORMAT, NOINIT,  
	NAME = N'SoftUni-Full Database Backup', 
	SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO

--18. Basic Insert
INSERT INTO Towns ([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments (Name) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')
	
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, CONVERT(datetime,'2013/01/02', 103), 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, CONVERT(datetime,'2004/02/03', 103), 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, CONVERT(datetime,'2016/28/08', 103), 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, CONVERT(datetime,'2007/09/12', 103), 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, CONVERT(datetime,'2016/28/08', 103), 599.88)

--19.Basic Select
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--20. Select and Order
SELECT * FROM Towns ORDER BY [Name]

SELECT * FROM Departments ORDER BY [Name]

SELECT * FROM Employees ORDER BY Salary DESC

--21. Select and order some field
SELECT [Name] FROM Towns ORDER BY [Name]

SELECT [Name] FROM Departments ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

--22. Increase Employees Salary
UPDATE Employees
SET Salary *= 1.1

SELECT Salary From Employees

--23. Decrease Tax Rate
USE Hotel

UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments

--24. Delete all records
DELETE FROM Occupancies
SELECT * FROM Occupancies