CREATE DATABASE Airport

-- DDL
CREATE TABLE Passengers (
     Id INT PRIMARY KEY IDENTITY,
	 FullName VARCHAR(100) UNIQUE NOT NULL,
	 Email VARCHAR(50) UNIQUE NOT NULL
	 )

CREATE TABLE Pilots (
     Id INT PRIMARY KEY IDENTITY,
	 FirstName VARCHAR(30) UNIQUE NOT NULL,
	 LastName VARCHAR(30) UNIQUE NOT NULL,
	 Age TINYINT CHECK(Age >= 21 AND Age <= 62) NOT NULL,
	 Rating FLOAT CHECK(Rating >= 0.0 AND Rating <= 10.0)
	 )

CREATE TABLE AircraftTypes (
     Id INT PRIMARY KEY IDENTITY,
	 TypeName VARCHAR(30) UNIQUE NOT NULL
	 )

CREATE TABLE Aircraft (
     Id INT PRIMARY KEY IDENTITY,
	 Manufacturer VARCHAR(25) NOT NULL,
	 Model VARCHAR(30) NOT NULL,
	 [Year] INT NOT NULL,
	 FlightHours INT,
	 Condition CHAR NOT NULL,
	 TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
	 )

CREATE TABLE PilotsAircraft (
     AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	 PilotId INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL,
	 PRIMARY KEY(AircraftId,PilotId)
	 )

CREATE TABLE Airports (
     Id INT PRIMARY KEY IDENTITY,
	 AirportName VARCHAR(70) UNIQUE NOT NULL,
	 Country VARCHAR(100) UNIQUE NOT NULL
	 )

CREATE TABLE FlightDestinations (
     Id INT PRIMARY KEY IDENTITY,
	 AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	 [Start] DATETIME NOT NULL,
	 AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	 PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	 TicketPrice DECIMAL(18,2) DEFAULT 15 NOT NULL
	 )

-- DML
-- Insert
INSERT INTO Passengers(FullName, Email)
       SELECT CONCAT(FirstName, ' ',  LastName) AS FullName, 
              CONCAT(FirstName, LastName, '@gmail.com') AS Email
       FROM Pilots
       WHERE Id BETWEEN 5 AND 15

-- Update
UPDATE Aircraft
SET Condition = 'A'
WHERE (Condition IN('B','C')) 
      AND ((FlightHours IS NULL) OR (FlightHours BETWEEN 0 AND 100)) 
	  AND ([Year] >= 2013)

-- Delete
DELETE FROM Passengers
WHERE LEN(FullName) <= 10

-- Querying
-- 5
SELECT Manufacturer, Model, FlightHours, Condition 
FROM Aircraft
ORDER BY FlightHours DESC

-- 6
SELECT p.FirstName, p.LastName, a.Manufacturer, a.Model, a.FlightHours
FROM Pilots AS p
    LEFT JOIN PilotsAircraft AS pa ON p.Id = pa.PilotId
	LEFT JOIN Aircraft AS a ON pa.AircraftId = a.Id
WHERE a.FlightHours BETWEEN 0 AND 304 AND a.FlightHours IS NOT NULL
ORDER BY a.FlightHours DESC, p.FirstName

-- 7
SELECT TOP(20)
      fd.Id, fd.Start, p.FullName, a.AirportName, fd.TicketPrice 
FROM FlightDestinations AS fd
    LEFT JOIN Airports AS a ON fd.AirportId = a.Id
	LEFT JOIN Passengers AS p ON fd.PassengerId = p.Id
WHERE DAY(Start) % 2 = 0
ORDER BY fd.TicketPrice DESC, a.AirportName

-- 8
SELECT 
     a.Id AS AircraftId,
	 a.Manufacturer,
	 a.FlightHours,
	 COUNT(a.Id) AS FlightsDestinationsCount,
	 ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a
    INNER JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
GROUP BY a.Id, a.Manufacturer, a.FlightHours
HAVING COUNT(a.Id) >= 2
ORDER BY FlightsDestinationsCount DESC, a.Id

-- 9
SELECT p.FullName, COUNT(fd.Id) AS CountOfAircraft, SUM(fd.TicketPrice) AS TotalPayed
FROM Passengers AS p
    JOIN FlightDestinations AS fd ON fd.PassengerId = p.Id
GROUP BY p.FullName
HAVING SUBSTRING(p.FullName, 2, 1) = 'a' AND COUNT(fd.Id) > 1
ORDER BY p.FullName

-- 10
SELECT ap.AirportName, fd.Start, fd.TicketPrice, p.FullName, a.Manufacturer, a.Model
FROM FlightDestinations AS fd
    JOIN Airports AS ap ON fd.AirportId = ap.Id
    JOIN Aircraft AS a ON fd.AircraftId = a.Id
	JOIN Passengers AS p ON fd.PassengerId = p.Id
WHERE DATEPART(HOUR, fd.Start) >= 6 AND DATEPART(HOUR, fd.Start) <= 20
      AND fd.TicketPrice > 2500
ORDER BY a.Model

-- Programmability
-- 11
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
       DECLARE @flightsCount INT;
           SET @flightsCount = (
                                SELECT 
                                	 COUNT(p.Id) AS FlightsDestinationsCount
                                     FROM Passengers AS p
                                         INNER JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
								     WHERE p.Email = @email
                                GROUP BY p.Id
                               );
	   RETURN ISNULL(@flightsCount,0)                        
END

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

-- 12
CREATE PROC usp_SearchByAirportName(@AirportName VARCHAR(70))
     AS
  BEGIN
       SELECT ap.AirportName,
	          p.FullName,
			  CASE 
			      WHEN fd.TicketPrice < 400 THEN 'Low'
				  WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Meidum'
				  ELSE 'High'
			  END AS LevelOfTicketPrice,
			  a.Manufacturer,
			  a.Condition,
			  at.TypeName
	   FROM Airports AS ap
	       JOIN FlightDestinations AS fd ON ap.Id = fd.AirportId
		   JOIN Aircraft AS a ON a.Id = fd.AircraftId
		   JOIN AircraftTypes AS [at] ON a.TypeId = at.Id
		   JOIN Passengers AS p ON fd.PassengerId = p.Id
		   WHERE ap.AirportName = @AirportName
	   ORDER BY a.Manufacturer, p.FullName
  END

  EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'