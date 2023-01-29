-- 1
SELECT TOP(5)
     e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e 
    JOIN Departments as d ON e.DepartmentID = d.DepartmentID 
	JOIN Addresses as a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

-- 2
SELECT TOP(50) 
     e.FirstName, e.LastName, t.Name AS Town, a.AddressText 
FROM Employees as e
    JOIN Addresses as a ON e.AddressID = a.AddressID
	JOIN Towns as t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

-- 3
SELECT 
     e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
FROM Employees as e
    JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

-- 4
SELECT TOP(5)
     e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName
FROM Employees as e
    JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- 5
SELECT TOP(3)
     e.EmployeeID, e.FirstName
FROM Employees AS e
    LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY EmployeeID

-- 6
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName
FROM Employees AS e
    JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '01/01/1999' AND d.Name IN('Sales','Finance')
ORDER BY HireDate

-- 7
SELECT TOP(5) 
     e.EmployeeID, e.FirstName, p.Name AS ProjectName
FROM Employees AS e
    INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002/08/13' AND p.EndDate IS NULL
ORDER BY EmployeeID

-- 8
SELECT
     e.EmployeeID, e.FirstName,
	 CASE 
	     WHEN DATEPART(YEAR, p.StartDate) > '2004' THEN NULL
		 ELSE p.Name
     END AS ProjectName
FROM Employees as e
    JOIN EmployeesProjects as ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

-- 9 
SELECT
     e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName AS ManagerName
FROM Employees AS e
    JOIN Employees AS em ON e.ManagerID = em.EmployeeID
WHERE e.ManagerID IN(3,7)
ORDER BY EmployeeID

-- 10
SELECT TOP(50)
     e.EmployeeID,
	 CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	 CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	 d.Name AS DepartmentName
FROM Employees AS e
    JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID 
ORDER BY EmployeeID

-- 11
SELECT
     MIN(a.AverageSalary) AS MinAverageSalary
	 FROM
	 (
	  SELECT e.DepartmentID,
	         AVG(e.Salary) AS AverageSalary
	  FROM Employees AS e
	  GROUP BY e.DepartmentID
	 ) AS a

-- 12
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
    JOIN Mountains AS m ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- 13
SELECT
     c.CountryCode, COUNT(mc.CountryCode) AS MountainRanges
FROM Countries AS c
    JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE c.CountryName IN('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode

-- 14
SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
    INNER JOIN Continents AS con ON c.ContinentCode = con.ContinentCode
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE con.ContinentName = 'Africa'
ORDER BY c.CountryName

-- 15
SELECT ContinentCode,
       CurrencyCode,
	   CurrencyUsage
FROM (
       SELECT *,
              DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC)
	          AS CurrencyRank
       FROM (
              SELECT ContinentCode,
	                 CurrencyCode,
		       	     COUNT(*) AS CurrencyUsage
	          FROM Countries
	          GROUP BY ContinentCode, CurrencyCode
	          HAVING COUNT(*) > 1
	         ) AS CurrencyUsageSubquery
     ) AS CurrencyRankingSubquery
WHERE CurrencyRank = 1
ORDER BY ContinentCode

-- 16
SELECT COUNT(c.CountryCode) AS CountryCode
FROM Countries AS c
    LEFT OUTER JOIN MountainsCountries AS m ON c.CountryCode = m.CountryCode
WHERE m.MountainId IS NULL

-- 17
SELECT TOP(5) 
       c.CountryName,
       MAX(p.Elevation) AS HighestPeakElevation,
	   MAX(r.Length) AS LongestRiverLenght
FROM Countries AS c
    LEFT JOIN CountriesRivers AS cr 
	          ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r 
	          ON r.Id = cr.RiverId
	LEFT JOIN MountainsCountries AS mc 
	          ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m 
	          ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p 
	          ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLenght DESC, c.CountryName