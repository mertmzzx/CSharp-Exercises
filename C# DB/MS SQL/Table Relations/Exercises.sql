-- 1
SELECT FirstName, LastName 
FROM Employees
WHERE LEFT(FirstName, 2) = 'Sa'   

-- 2
SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('ei', LastName, 1) > 0

-- 3
SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3,10)

-- 4
SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('engineer', JobTitle) = 0

SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- 5
SELECT [Name]
FROM Towns
WHERE LEN([Name]) IN(5,6)
ORDER BY [Name]

-- 6
SELECT *
FROM Towns
WHERE LEFT([Name],1) IN('M', 'K', 'B', 'E')
ORDER BY [Name]

-- 7
SELECT *
FROM Towns
WHERE LEFT([Name],1) NOT IN('R', 'B', 'D')
ORDER BY [Name]

-- 8
CREATE VIEW [V_EmployeesHiredAfter2000]
       AS
    SELECT FirstName,LastName
          FROM Employees
         WHERE YEAR(HireDate) > 2000

-- 9 
SELECT FirstName,LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 10
SELECT EmployeeID,
       FirstName, 
       LastName, 
       Salary,
       DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) 
	   AS Rank
FROM Employees
    WHERE Salary BETWEEN 10000 AND 50000
         ORDER BY Salary DESC

-- 11
SELECT *
FROM (
          SELECT EmployeeID,
             FirstName, 
             LastName, 
             Salary,
             DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) 
      	   AS [Rank]
           FROM Employees
           WHERE Salary BETWEEN 10000 AND 50000
      ) AS RankingSubquery
WHERE [Rank] = 2
ORDER BY Salary DESC

GO

USE Geography

GO

-- 12
SELECT CountryName, IsoCode
  FROM Countries
  WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY IsoCode

-- 13

SELECT p.PeakName,
       r.RiverName,
	   LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) - 1), r.RiverName)) AS Mix
FROM Peaks AS p,
     Rivers AS r
WHERE RIGHT(LOWER(p.PeakName), 1) = LEFT(LOWER(r.RiverName), 1)
ORDER BY Mix

-- 14 
USE Diablo

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS StartDate
FROM Games
WHERE YEAR([Start]) IN(2011,2012)
ORDER BY [StartDate], [Name]

-- 15
SELECT Username,
       SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) -  CHARINDEX('@', Email)) AS EmailProvider
FROM Users
ORDER BY EmailProvider, Username

-- 16
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE('___.1%.%.___')
ORDER BY Username

-- 17
SELECT [Name] AS Game,
       CASE
	      WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		  WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		  ELSE 'Evening'
	   END AS [Part of the Day],
	   CASE 
	      WHEN Duration <= 3 THEN 'Extra Short'
		  WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		  WHEN Duration > 6 THEN 'Long'
		  ELSE 'Extra Long'
	   END AS Duration
FROM Games
ORDER BY [Name], Duration

-- 18
SELECT ProductName,
       OrderDate, 
	   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders