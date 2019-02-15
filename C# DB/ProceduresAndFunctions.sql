USE SoftUni

--1. Get Employees Salary Above 35000
GO
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT
		FirstName,
		LastName
	FROM Employees
	WHERE Salary > 35000

GO
--2. Get Employees Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber @number DECIMAL(18, 4)
AS
	SELECT
		FirstName,
		LastName
	FROM Employees
	WHERE Salary >= @number
GO


--3. Towns starting with
CREATE PROCEDURE usp_GetTownsStartingWith @string VARCHAR(50)
AS
	SELECT
		[Name] AS Town
	FROM Towns
	WHERE SUBSTRING([Name], 1, LEN(@string)) = @string
	
GO
--4. Employees from town
CREATE PROC usp_GetEmployeesFromTown @TownName VARCHAR(50)
AS
	SELECT
		FirstName,
		LastName
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID	
	WHERE t.[Name] = @TownName

GO
USE SoftUni
--5. Salary level function
CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS VARCHAR(20)
AS
	BEGIN
		DECLARE @result VARCHAR(20)

		IF(@salary < 30000)
			SET @result = 'Low'; 
		ELSE IF (@salary <= 50000)
			SET @result = 'Average';
		ELSE
			SET @result = 'High';

		RETURN @result;
	END

GO
--6. Employees by salary level
CREATE PROC usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(20)
AS
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

GO
--7. Define function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(max), @word VARCHAR(max))
RETURNS BIT
AS
BEGIN
  DECLARE @isComprised BIT = 0;
  DECLARE @currentIndex INT = 1;
  DECLARE @currentChar CHAR;

  WHILE(@currentIndex <= LEN(@word))
  BEGIN

    SET @currentChar = SUBSTRING(@word, @currentIndex, 1);
    IF(CHARINDEX(@currentChar, @setOfLetters) = 0)
      RETURN @isComprised;
    SET @currentIndex += 1;

  END

  RETURN @isComprised + 1;

END

USE Bank
GO
--9. Find full name
CREATE PROC usp_GetHoldersFullName
AS
	SELECT 
		CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders

GO
--10. People with balance higher than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @sum MONEY
AS
BEGIN 
	SELECT FirstName AS [First Name], LastName AS [Last Name] FROM
	(
		SELECT FirstName, LastName, SUM(a.Balance) AS TotalBalance FROM AccountHolders AS ah
		JOIN Accounts AS a
		ON a.AccountHolderId = ah.Id
		GROUP BY ah.FirstName, ah.LastName
	) AS tb
	WHERE tb.TotalBalance > @sum
	ORDER BY tb.FirstName, tb.LastName
END

--11. Future value function
CREATE FUNCTION ufn_CalculateFutureValue (@sum MONEY, @yearlyInterestRate FLOAT, @years INT)
RETURNS MONEY
AS
	BEGIN
		RETURN @sum * POWER(1 + @yearlyInterestRate, @years);
	END

GO
--12. Calculating interest
CREATE PROC usp_CalculateFutureValueForAccount @accountId INT, @interestRate FLOAT
AS
	SELECT
		a.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountId

GO
--II. TRIGGERS AND TRANSACTIONS
USE Bank
--14. Create Table Logs
CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT,
	OldSum MONEY,
	NewSum MONEY
)
GO
CREATE TRIGGER tr_AccountBalanceChange ON Accounts FOR UPDATE
AS
BEGIN
  DECLARE @accountId int = (SELECT Id FROM inserted);
  DECLARE @oldBalance money = (SELECT Balance FROM deleted);
  DECLARE @newBalance money = (SELECT Balance FROM inserted);

  IF(@newBalance <> @oldBalance)
    INSERT INTO Logs VALUES (@accountId, @oldBalance, @newBalance);
END


--15. Create Table Emails
CREATE TRIGGER tr_LogsNotificationEmails ON Logs FOR INSERT
AS
BEGIN
  DECLARE @recipient int = (SELECT AccountId FROM inserted);
  DECLARE @oldBalance money = (SELECT OldSum FROM inserted);
  DECLARE @newBalance money = (SELECT NewSum FROM inserted);
  DECLARE @subject varchar(200) = CONCAT('Balance change for account: ', @recipient);
  DECLARE @body varchar(200) = CONCAT('On ', GETDATE(), ' your balance was changed from ', @oldBalance, ' to ', @newBalance, '.');  

  INSERT INTO NotificationEmails (Recipient, Subject, Body) 
  VALUES (@recipient, @subject, @body)
END

GO
--16. Deposit money
CREATE PROC usp_DepositMoney @accountId INT, @depositAmount DECIMAL(15,4)
AS
BEGIN
  BEGIN TRANSACTION
  UPDATE Accounts
  SET Balance += @depositAmount
  WHERE (Id = @accountId)

  IF (@@ROWCOUNT <> 1) 
    BEGIN
      ROLLBACK;
      RAISERROR ('Invalid account!', 16, 1);
      RETURN;
    END

  COMMIT;

END

--17. Withdraw money
CREATE PROC usp_WithdrawMoney @accountId INT, @withdrawAmount DECIMAL(15,4)
AS
BEGIN
  BEGIN TRANSACTION
  UPDATE Accounts
  SET Balance -= @withdrawAmount
  WHERE (Id = @accountId)

  IF (@@ROWCOUNT <> 1) 
    BEGIN
      ROLLBACK;
      RAISERROR ('Invalid account!', 16, 1);
      RETURN;
    END

  COMMIT;

END

--18. Money transfers
CREATE PROCEDURE usp_TransferMoney (@senderId int, @receiverId int, @transferAmount money)
AS
BEGIN 

  DECLARE @senderBalanceBefore money = (SELECT Balance FROM Accounts WHERE Id = @senderId);

  IF(@senderBalanceBefore IS NULL)
  BEGIN
    RAISERROR('Invalid sender account!', 16, 1);
    RETURN;

  END   

  DECLARE @receiverBalanceBefore money = (SELECT Balance FROM Accounts WHERE Id = @receiverId);  

  IF(@receiverBalanceBefore IS NULL)
  BEGIN
    RAISERROR('Invalid receiver account!', 16, 1);
    RETURN;
  END   

  IF(@senderId = @receiverId)
  BEGIN
    RAISERROR('Sender and receiver accounts must be different!', 16, 1);
    RETURN;
  END  

  IF(@transferAmount <= 0)
  BEGIN
    RAISERROR ('Transfer amount must be positive!', 16, 1); 
    RETURN;

  END 

  BEGIN TRANSACTION
  EXEC usp_WithdrawMoney @senderId, @transferAmount;
  EXEC usp_DepositMoney @receiverId, @transferAmount;

  DECLARE @senderBalanceAfter money = (SELECT Balance FROM Accounts WHERE Id = @senderId);
  DECLARE @receiverBalanceAfter money = (SELECT Balance FROM Accounts WHERE Id = @receiverId);  

  IF((@senderBalanceAfter <> @senderBalanceBefore - @transferAmount) OR 
     (@receiverBalanceAfter <> @receiverBalanceBefore + @transferAmount))
    BEGIN
      ROLLBACK;
      RAISERROR('Invalid account balances!', 16, 1);
      RETURN;
    END

  COMMIT;

END

GO
--21. Employees with three projects
CREATE PROCEDURE usp_AssignProject (@employeeID int, @projectID int)
AS
BEGIN

  DECLARE @maxEmployeeProjectsCount int = 3;
  DECLARE @employeeProjectsCount int;

  BEGIN TRAN
  INSERT INTO EmployeesProjects (EmployeeID, ProjectID) 
  VALUES (@employeeID, @projectID)

  SET @employeeProjectsCount = (
    SELECT COUNT(*)
    FROM EmployeesProjects
    WHERE EmployeeID = @employeeID

  )

  IF(@employeeProjectsCount > @maxEmployeeProjectsCount)

    BEGIN
      RAISERROR('The employee has too many projects!', 16, 1);
      ROLLBACK;
    END

  ELSE COMMIT

END

GO
--22. Delete employees
CREATE TRIGGER tr_DeleteEmployees
  ON Employees
  AFTER DELETE
AS
  BEGIN
    INSERT INTO Deleted_Employees
      SELECT FirstName,LastName,MiddleName,JobTitle,DepartmentID,Salary
      FROM deleted
  END