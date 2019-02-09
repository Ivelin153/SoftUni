CREATE DATABASE Demo
USE Demo

--1. One to one relationship
CREATE TABLE Passports (
	PassportID INT PRIMARY KEY IDENTITY(101, 1),
	PassportNumber VARCHAR(20)
)

CREATE TABLE Persons (
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20),
	Salary DECIMAL,
	PassportID INT UNIQUE
)

INSERT INTO Passports VALUES ('N34FG21B')
INSERT INTO Passports VALUES ('K65LO4R7')
INSERT INTO Passports VALUES ('ZE657QP2')

INSERT INTO 
	Persons
VALUES 
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)

ALTER TABLE Persons 
ADD CONSTRAINT
	FK_Person_Passport FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

--2. One to many relationship

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(20),
	ManufacturerID INT
)

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10),
	EstablishedOn DATE
)

INSERT INTO Manufacturers VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')


INSERT INTO Models VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('NOVA', 3)

ALTER TABLE Models
ADD CONSTRAINT
	FK_Models_Manufacturers FOREIGN KEY (ManufacturerID) 
	REFERENCES Manufacturers(ManufacturerID)


--3. Many to many relationship
CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20)
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(20)
)


CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,
	CONSTRAINT PK_Students_Exams PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_Student_ID 
		FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Examt_ID
		FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO 
	Students
VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO
	Exams
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO
	StudentsExams
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)


--4. Self referencing
CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(20),
	ManagerID INT
)

ALTER TABLE Teachers
ADD CONSTRAINT
	FK_Manager_ID FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)

INSERT INTO 
	Teachers
VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

--5. Online Store DB
CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE Cities(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	Birthday DATE,
	CityID INT,
	CONSTRAINT FK_Customers_City
	FOREIGN KEY (CityID)
	REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT
)

ALTER TABLE ORDERS
ADD CONSTRAINT FK_CustomerID_Customers
FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	ItemTypeID INT,
	CONSTRAINT FK_Items_ItemType
	FOREIGN KEY (ItemTypeID)
	REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID INT,
	ItemID INT,
	CONSTRAINT PK_Order_Item PRIMARY KEY (OrderID, ItemID),

	CONSTRAINT FK_OrdersID_Order
	FOREIGN KEY (OrderID)
	REFERENCES Orders(OrderID),

	CONSTRAINT FK_ItemsID_Item
	FOREIGN KEY (ItemID)
	REFERENCES Items(ItemID)
)

--6. University DB
CREATE DATABASE University
USE University

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(20)
)

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20)
)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(20),
	StudentName VARCHAR(20),
	MajorID INT,
	CONSTRAINT FK_MajorID_Majors
	FOREIGN KEY(MajorID)
	REFERENCES Majors(MajorID),
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE,
	PaymentAmount DECIMAL,
	StudentID INT,
	CONSTRAINT FK_StudentID_Payments
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID)
)

CREATE TABLE Agenda(
	StudentID INT,
	SubjectID INT,
	CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID),

	CONSTRAINT FK_StudentID_Students
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),

	CONSTRAINT FK_SubjectID_Subjects
	FOREIGN KEY (SubjectID)
	REFERENCES Subjects(SubjectID)
)

--9. Peaks in Rila
USE [Geography]

SELECT 
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM
	Mountains AS m
JOIN 
	Peaks AS p ON p.MountainId = m.Id
	AND MountainRange = 'Rila'
ORDER BY 
	p.Elevation DESC
