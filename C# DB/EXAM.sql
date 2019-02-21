CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25) NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK (Age > 5 AND Age < 100),
	[Address] NVARCHAR(50),
	Phone NVARCHAR(10)
)

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL CHECK (Lessons > 0)
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES  Subjects(Id),
	Grade DECIMAL(15, 2) NOT NULL CHECK (Grade >= 2 AND Grade <= 6)
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams(
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	ExamId INT NOT NULL FOREIGN KEY REFERENCES Exams(Id),
	Grade DECIMAL(15, 2) NOT NULL CHECK (Grade >= 2 AND Grade <= 6),
	PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone NVARCHAR(10),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers(
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers(Id),
	PRIMARY KEY (StudentId, TeacherId)
)

--2. INSERT
INSERT INTO Teachers VALUES
	('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
	('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
	('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
	('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects VALUES
	('Geometry', 12),
	('Health', 10),
	('Drama', 7),
	('Sports', 9)

--3. Update
UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1, 2) AND Grade >= 5.50

--4. Delete
SELECT 
	Id
FROM Teachers
WHERE Phone LIKE '%72%'

DELETE FROM StudentsTeachers
WHERE TeacherId IN ( SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers 
WHERE Phone LIKE '%72%'

--III. Querying
--5. Teen Students
SELECT 
	FirstName,
	LastName,
	Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName ASC, LastName ASC

--6. Cool addresses
SELECT
	CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name],
	Address
FROM Students
WHERE [Address] LIKE '%road%'
ORDER BY FirstName, LastName, [Address]

--7. 42 PHONES
SELECT 
	FirstName,
	[Address],
	Phone
FROM Students
WHERE MiddleName IS NOT NULL AND Phone LIKE '42%'
ORDER BY FirstName

--8. Students Teachers
SELECT
	s.FirstName,
	s.LastName,
	COUNT(st.TeacherId) AS TeachersCount
FROM Students AS s
JOIN StudentsTeachers AS st ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

--9. Students with subjects
SELECT
	d.FullName,
	d.Subjects,
	COUNT(st.StudentId) AS [Students]
FROM (
	SELECT 
		t.Id,
		CONCAT(t.FirstName, ' ', t.LastName) AS [FullName],
		sb.[Name] + '-' + CAST(sb.Lessons AS nvarchar) AS Subjects
	FROM Teachers AS t
	JOIN Subjects AS sb ON sb.Id = t.SubjectId
	) AS d
JOIN StudentsTeachers AS st ON st.TeacherId = d.Id
JOIN Students AS s ON s.Id = st.StudentId
GROUP BY d.FullName, d.Subjects 
ORDER BY Students DESC, d.FullName, d.Subjects

--10. Students to Go
SELECT 
	CONCAT(s.FirstName, ' ', s.LastName) AS [FullName]
FROM Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY FullName 

--11. Busiest teachers
SELECT TOP 10
	t.FirstName,
	t.LastName,
	COUNT(st.StudentId) AS StudentsCount
FROM Teachers AS t
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName
ORDER BY StudentsCount DESC, FirstName, LastName

--12. Top students
SELECT TOP 10
	s.FirstName,
	s.LastName,
	CAST(AVG(se.Grade) AS DECIMAL(15,2)) AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName, se.StudentId
ORDER BY Grade DESC, s.FirstName, s.LastName

--13. Second highest grade
SELECT
	d.FirstName,
	d.LastName,
	CAST(d.Grade AS decimal(15,2)) AS Grade
FROM (
	SELECT
		s.FirstName AS FirstName,
		s.LastName AS LastName,
		sb.Name AS SubjName,
		ssb.Grade as Grade,
		ROW_NUMBER() OVER (PARTITION BY s.Id ORDER BY ssb.Grade DESC) as GradeRank
		
	FROM Students AS s
	JOIN StudentsSubjects AS ssb ON ssb.StudentId = s.Id
	JOIN Subjects AS sb ON sb.Id = ssb.SubjectId
	) AS d
WHERE d.GradeRank = 2
ORDER BY d.FirstName ASC, d.LastName

--14. Not so in the studying
SELECT
	s.FirstName + ' ' +
	IIF( s.MiddleName IS NULL, '', s.MiddleName + ' ') +
	LastName AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ssb ON ssb.StudentId = s.Id
WHERE ssb.SubjectId IS NULL
ORDER BY [Full Name]

--15. Top student per teacher
SELECT
	*
FROM Teachers AS t
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
JOIN Students AS s ON s.Id = st.StudentId
JOIN StudentsSubjects AS ssb ON ssb.StudentId = s.Id
JOIN Subjects AS sb ON sb.Id = ssb.SubjectId


SELECT
	d.tFirstName + ' ' + d.tLastName AS [Teacher Full Name],
	d.SubjName,
	d.FirstName + ' ' + d.LastName AS [Student Full Name],
	MAX(d.[Grade])
FROM (
	SELECT			
		--t.FirstName AS tFirstName,
		--t.LastName AS tLastName,
		s.FirstName AS FirstName,
		s.LastName AS LastName,
		sb.[Name] AS SubjName,
		ssb.Grade as Grade,
		ROW_NUMBER() OVER (PARTITION BY s.Id ORDER BY AVG(ssb.Grade) DESC) AS BestGrade		
	FROM Students AS s
	JOIN StudentsSubjects AS ssb ON ssb.StudentId = s.Id
	JOIN Subjects AS sb ON sb.Id= ssb.SubjectId
	JOIN StudentsTeachers AS st ON st.StudentId = s.Id
	JOIN Teachers AS t ON t.Id = st.TeacherId
	) AS d

WHERE BestGrade = 1

--16. Average grade per subject
SELECT
	sb.[Name],
	AVG(ssb.Grade) AS AverageGrade,
FROM Subjects AS sb
JOIN StudentsSubjects AS ssb ON ssb.SubjectId = sb.Id
GROUP BY sb.Id, sb.[Name]
ORDER BY sb.Id

--17. Exams information
SELECT 
	Id,
	DATEPART(QUARTER, [Date])
FROM Exams
GROUP BY Id, DATEPART(QUARTER, [Date])

GO

--18. Exam Grades
CREATE FUNCTION udf_ExamGradesToUpdate(
	@studentId INT,
	@grade DECIMAL(15,2)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	IF((@grade + 0.5) > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @student NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)
	IF(@student IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END

	DECLARE @gradesCount INT = (
	SELECT 
		COUNT(ssb.Id)
	FROM Students AS s
	JOIN StudentsSubjects AS ssb ON ssb.StudentId = s.Id
	WHERE ssb.Grade > @grade AND ssb.Grade <= (@grade + 0.5) AND ssb.StudentId = @studentId
	)

	RETURN 'You have to update ' + CAST(@gradesCount AS varchar) + ' grades for the student ' + CAST(@student AS varchar)

END
GO

--19. Exclude from school
CREATE PROC usp_ExcludeFromSchool @studentId INT
AS
BEGIN
	DECLARE @student NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	IF (@student IS NULL)
	BEGIN
		;THROW 51000, 'This school has no student with the provided id!', 1
	END

	DELETE FROM StudentsSubjects
	WHERE StudentId = @studentId

	DELETE FROM StudentsExams
	WHERE StudentId = @studentId
	
	DELETE FROM StudentsTeachers
	WHERE StudentId = @studentId

	DELETE FROM Students
	WHERE Id = @studentId
END
GO
--20.
CREATE TRIGGER t_DeleteStudents
    ON Students AFTER DELETE
    AS
    BEGIN
	  INSERT INTO ExcludedStudents (StudentId, StudentName)
	  SELECT d.Id, d.FirstName + ' ' + d.LastName
	    FROM deleted AS d
    END