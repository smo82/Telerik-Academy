-- TASK04
-- Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT *
FROM Departments
-----------------------------------------------------------------
-- TASK05
-- Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT Name
FROM Departments
-----------------------------------------------------------------
-- TASK06
-- Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT FirstName, LastName, Salary
FROM Employees
-----------------------------------------------------------------
-- TASK07
-- Write a SQL to find the full name of each employee.

SELECT FirstName + ' ' + LastName as FullName
FROM Employees
-----------------------------------------------------------------
-- TASK08
-- Write a SQL query to find the email addresses of each employee (by his first and last name). 
-- Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
-- The produced column should be named "Full Email Addresses".

SELECT Concat(FirstName, '.', LastName, '@telerik.com') as Email
FROM Employees
-----------------------------------------------------------------
-- TASK09
-- Write a SQL query to find all different employee salaries.

SELECT DISTINCT Salary
FROM Employees
-----------------------------------------------------------------
-- TASK10
-- Write a SQL query to find all information about the employees whose job title is “Sales Representative“.

SELECT *
FROM Employees 
WHERE JobTitle = 'Sales Representative'
-----------------------------------------------------------------
-- TASK11
-- Write a SQL query to find the names of all employees whose first name starts with "SA".

SELECT FirstName + ' ' + LastName as FullName
FROM Employees 
WHERE FirstName like 'SA%'
-----------------------------------------------------------------
-- TASK12
-- Write a SQL query to find the names of all employees whose last name contains "ei".

SELECT FirstName + ' ' + LastName as FullName
FROM Employees 
WHERE LastName like '%ei%'
-----------------------------------------------------------------
-- TASK13
-- Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

SELECT Salary
FROM Employees 
-- WHERE Salary >= 20000 AND Salary <= 30000
WHERE Salary BETWEEN 20000 AND 30000
-----------------------------------------------------------------
-- TASK14
-- Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

SELECT FirstName + ' ' + LastName as FullName, Salary
FROM Employees 
-- WHERE Salary = 12500 OR Salary = 14000 OR Salary = 23600 OR Salary = 25000
WHERE Salary IN (12500, 14000, 23600, 25000)
-----------------------------------------------------------------
-- TASK15
-- Write a SQL query to find all employees that do not have manager.

SELECT FirstName + ' ' + LastName as FullName, ManagerID
FROM Employees 
WHERE ManagerID is Null
-----------------------------------------------------------------
-- TASK16
-- Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

SELECT FirstName + ' ' + LastName as FullName, Salary
FROM Employees 
WHERE Salary > 50000
ORDER BY Salary
-----------------------------------------------------------------
-- TASK17
-- Write a SQL query to find the top 5 best paid employees.

SELECT TOP 5 FirstName + ' ' + LastName as FullName, Salary
FROM Employees 
ORDER BY Salary DESC
-----------------------------------------------------------------
-- TASK18
-- Write a SQL query to find all employees along with their address. Use inner join with ON clause.

SELECT e.FirstName + ' ' + e.LastName as FullName, a.AddressText
FROM Employees e JOIN Addresses a
	ON e.AddressID = a.AddressID
-----------------------------------------------------------------
-- TASK19
-- Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

SELECT e.FirstName + ' ' + e.LastName as FullName, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID
-----------------------------------------------------------------
-- TASK20
-- Write a SQL query to find all employees along with their manager.

SELECT e.FirstName + ' ' + e.LastName as EmployeeFullName, m.FirstName + ' ' + m.LastName as ManagerFullName
FROM Employees e, Employees m
WHERE e.ManagerID = m.EmployeeID

-- Second way
SELECT e.FirstName + ' ' + e.LastName as EmployeeFullName, m.FirstName + ' ' + m.LastName as ManagerFullName
FROM Employees e JOIN Employees m
	ON e.ManagerID = m.EmployeeID
-----------------------------------------------------------------
-- TASK21
-- Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

SELECT e.FirstName + ' ' + e.LastName as EmployeeFullName, m.FirstName + ' ' + m.LastName as ManagerFullName, a.AddressText as EmployeeAddress
FROM Employees e JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
		ON e.AddressID = a.AddressID
-----------------------------------------------------------------
-- TASK22
-- Write a SQL query to find all departments and all town names as a single list. Use UNION.

SELECT d.Name
FROM Departments d

UNION

SELECT t.Name
FROM Towns t

-----------------------------------------------------------------
-- TASK23
-- Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.

SELECT e.FirstName + ' ' + e.LastName as EmployeeFullName, m.FirstName + ' ' + m.LastName as ManagerFullName
FROM Employees m RIGHT JOIN Employees e
	ON e.ManagerID = m.EmployeeID

-----------------------------------------------------------------
-- TASK24
-- Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2000.

SELECT e.FirstName + ' ' + e.LastName as EmployeeFullName, d.Name, e.HireDate
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name in ('Sales', 'Finance') AND (e.HireDate BETWEEN '1995-1-1' AND '2002-12-31')
-- WHERE d.Name in ('Sales', 'Finance') AND (e.HireDate BETWEEN '1995-1-1' AND '2000-12-31')
-- NO RESULTS between 1995 and 2000

-----------------------------------------------------------------
-- Task25
-- Write a SQL query to display the average employee salary by department and job title.

SELECT d.Name [Department], e.JobTitle [Job Title], AVG(Salary) [Avarage Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-----------------------------------------------------------------
-- Task26
-- Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

SELECT MIN(CONCAT(e.FirstName, ' ', e.LastName)) FullName, d.Name [Department], e.JobTitle [Job Title], MIN(Salary) [Min Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-----------------------------------------------------------------
-- Task27
-- Write a SQL query to display the town where maximal number of employees work.

SELECT EmployeesCount.Town, EmployeesCount.[Count Employees] FROM
 (SELECT t.Name [Town], Count(*) [Count Employees]
	FROM Employees e                         
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
	GROUP BY t.Name, t.TownID) AS EmployeesCount	
WHERE EmployeesCount.[Count Employees] = (SELECT MAX(EmployeesCount.[Count Employees]) FROM 
	(SELECT t.Name [Town], Count(*) [Count Employees]
		FROM Employees e                         
		JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
		JOIN Addresses a
		ON e.AddressID = a.AddressID
		JOIN Towns t
		ON a.TownID = t.TownID
		GROUP BY t.Name, t.TownID) AS EmployeesCount)

-----------------------------------------------------------------
-- Task28
-- Write a SQL query to display the number of managers from each town.

SELECT t.Name [Town], Count(*) [Count Employees]
	FROM Employees e                         
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
	WHERE e.ManagerID is not null
	GROUP BY t.Name, t.TownID

-----------------------------------------------------------------
-- Task29
-- Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, Task, hours, comments). 
-- Don't forget to define  identity, primary key and appropriate foreign key. 
-- Issue few SQL statements to insert, update and delete of some data in the table.
-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
-- For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours (
  WorkHoursId int IDENTITY,
  EmployeeId int,
  WorkDate date, 
  Task nvarchar(100),
  NumberHours int,
  Comment text,
  CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHoursId), 
  CONSTRAINT FK_WorkHours_Users FOREIGN KEY(EmployeeId)
  REFERENCES Employees(EmployeeID),
  CONSTRAINT Min_NumberHours CHECK (DATALENGTH(NumberHours) >= 0),
  CONSTRAINT Max_NumberHours CHECK (DATALENGTH(NumberHours) <= 24)
)

GO

Insert WorkHours (EmployeeId, WorkDate, Task, NumberHours, Comment)
Values (1, GETDATE(), 'Task1', 8, 'Some comment1')

Insert WorkHours (EmployeeId, WorkDate, Task, NumberHours, Comment)
Values (1, GETDATE(), 'Task2', 8, 'Some comment2')

Insert WorkHours (EmployeeId, WorkDate, Task, NumberHours, Comment)
Values (1, GETDATE(), 'Task3', 8, 'Some comment3')

Insert WorkHours (EmployeeId, WorkDate, Task, NumberHours, Comment)
Values (1, GETDATE(), 'Task4', 8, 'Some comment4')

UPDATE WorkHours
SET Comment = 'SOME COMMENT3'
WHERE Task = 'Task3'

UPDATE WorkHours
SET Comment = 'SOME COMMENT4'
WHERE Task = 'Task4'

DELETE FROM WorkHours
WHERE Task = 'Task3'

-----------------------------------------------------------------
-- Task30
--  Start a database transaction, delete all employees from the 'Sales'
-- department along with all dependent records from the other tables. At the
-- end rollback the transaction.

BEGIN TRAN
	ALTER TABLE EmployeesProjects
	ADD CONSTRAINT FK_CASCADE_1 FOREIGN KEY (EmployeeID)
	REFERENCES Employees (EmployeeID)
	ON DELETE CASCADE;

    -- to run this, modify ManagerId to accept null
	ALTER TABLE Departments
	ADD CONSTRAINT FK_CASCADE_2 FOREIGN KEY (ManagerId)
	REFERENCES Employees (EmployeeID)
	ON DELETE SET NULL;

	DELETE FROM Employees 
	WHERE DepartmentId IN (SELECT DepartmentId FROM Departments WHERE Name = 'Sales')

	-- no need to explicitly drop the constraints

	ROLLBACK TRAN
GO

-----------------------------------------------------------------
-- Task31
-- Start a database transaction and drop the table EmployeesProjects. Now
-- how you could restore back the lost table data?

-- snapshots - not supported in Express Edition

BEGIN TRAN
	CREATE DATABASE TelerikAcademy_snapshot1900 
	ON (NAME = TelerikAcademy_Data, FILENAME = 'TelerikAcademy_snapshot1900.ss')
	AS SNAPSHOT OF TelerikAcademy;

	DROP TABLE EmployeesProjects
	-- ROLLBACK TRAN
GO

BEGIN TRAN
	-- kick users
	ALTER DATABASE TelerikAcademy
	SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

	-- restore database
	USE master;
	RESTORE DATABASE TeleikAcademy FROM DATABASE_SNAPSHOT = 'TelerikAcademy_snapshot1900';
GO

-----------------------------------------------------------------
-- Task32 
-- Find how to use temporary tables in SQL Server. Using temporary tables
-- backup all records from EmployeesProjects and restore them back after
-- dropping and re-creating the table.

BEGIN TRAN
	SELECT * INTO #TempEmployeesProjects 
	FROM EmployeesProjects;

	DROP TABLE EmployeesProjects;

	SELECT * INTO EmployeesProjects
	FROM #TempEmployeesProjects;

	DROP TABLE #TempEmployeesProjects
GO