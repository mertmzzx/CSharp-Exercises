CREATE DATABASE NationalTouristSitesOfBulgaria

GO

USE NationalTouristSitesOfBulgaria

GO

-- DDL
CREATE TABLE Categories (
     Id INT PRIMARY KEY IDENTITY,
	 [Name] VARCHAR(50) NOT NULL
	 )

CREATE TABLE Locations (
     Id INT PRIMARY KEY IDENTITY,
	 [Name] VARCHAR(50) NOT NULL,
	 Municipality VARCHAR(50),
	 Province VARCHAR(50)
	 )

CREATE TABLE Sites (
    Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Establishment VARCHAR(15)
	)

CREATE TABLE Tourists (
    Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT CHECK(Age >= 0 AND Age <= 120) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Reward VARCHAR(20)
	)

CREATE TABLE SitesTourists (
     TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	 SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL,
	 PRIMARY KEY(TouristId, SiteId)
	 )

CREATE TABLE BonusPrizes (
     Id INT PRIMARY KEY IDENTITY,
	 [Name] VARCHAR(50) NOT NULL
	 )

CREATE TABLE TouristsBonusPrizes (
     TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	 BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL,
	 PRIMARY KEY(TouristId, BonusPrizeId)
	 )

-- DML
-- Insert

INSERT INTO Tourists (Name, Age, PhoneNumber, Nationality, Reward)
VALUES
     ('Borislava Kazakova',	52,	'+359896354244','Bulgaria', NULL),
	 ('Peter Bosh',	48,	'+447911844141', 'UK',	NULL),
     ('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
     ('Svilen Dobrev',	49,	'+359986584786', 'Bulgaria','Silver badge'),
     ('Kremena Popova',	38,	'+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites (Name, LocationId, CategoryId, Establishment)
VALUES
     ('Ustra fortress',	90,	7, 'X'),
     ('Karlanovo Pyramids',	65,	7,	NULL),
     ('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
     ('Sinite Kamani Natural Park',	17,	1, NULL),
     ('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

-- Update
UPDATE Sites 
SET Establishment = '(not defined)'
WHERE Establishment IS NULL

-- Delete
DELETE
FROM TouristsBonusPrizes
WHERE BonusPrizeId = 5

DELETE
FROM BonusPrizes
WHERE Name = 'Sleeping bag'

-- Querying
-- 5
SELECT Name, Age, PhoneNumber, Nationality
FROM Tourists
ORDER BY Nationality, Age DESC, Name

-- 6
SELECT s.Name, l.Name, s.Establishment, c.Name
FROM Sites AS s
    JOIN Categories AS c 
    ON s.CategoryId = c.Id
	JOIN Locations AS l
	ON s.LocationId = l.Id
ORDER BY c.Name DESC, l.Name, s.Name

-- 7
SELECT l.Province, l.Municipality, l.Name, COUNT(s.Id)
FROM Sites AS s
    JOIN Locations AS l
	ON s.LocationId = l.Id
WHERE l.Province = 'Sofia'
GROUP BY l.Province, l.Municipality, l.Name
ORDER BY COUNT(s.Id) DESC, l.Name

-- 8
SELECT s.Name AS Site, l.Name AS Location, l.Municipality, l.Province, s.Establishment
FROM Sites AS s
    JOIN Locations AS l
	ON s.LocationId = l.Id
WHERE SUBSTRING(s.Name,1,1) NOT IN('B', 'M', 'D') 
      AND Establishment LIKE '%%BC'
ORDER BY s.Name

-- 9
SELECT t.Name, t.Age, t.PhoneNumber, t.Nationality, 
       CASE
	       WHEN b.Name IS NULL THEN '(no bonus prize)'
		   ELSE b.Name
	   END AS Reward
FROM Tourists AS t
    LEFT JOIN TouristsBonusPrizes AS tbp
	ON tbp.TouristId = t.Id
	LEFT JOIN BonusPrizes AS b
	ON tbp.BonusPrizeId = b.Id
ORDER BY t.Name

-- 10
SELECT DISTINCT SUBSTRING(t.Name, CHARINDEX(' ', t.Name), LEN(t.Name)) AS LastName,
       t.Nationality,
	   t.Age,
	   t.PhoneNumber
FROM SitesTourists AS st
    JOIN Tourists AS T
	ON st.TouristId = t.Id
	JOIN Sites AS s
	ON st.SiteId = s.Id
	JOIN Categories AS c
	ON s.CategoryId = c.Id
WHERE c.Name = 'History and archaeology'
ORDER BY LastName

-- Programmability
-- 11
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(50))
RETURNS INT
AS
BEGIN
     DECLARE @touristCount INT;
	 SET @touristCount = (
	                      SELECT COUNT(*)
						  FROM SitesTourists AS st
						      JOIN Tourists AS t
							  ON st.TouristId = t.Id
							  JOIN Sites AS s
							  ON st.SiteId = s.Id
						  WHERE s.Name = @Site
						  );
     
	 RETURN @touristCount;
END 

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')

-- 12
CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
     DECLARE @siteCount INT;
	 SET @siteCount = (
	                    SELECT COUNT(*)
	                    FROM Tourists AS t
	                       JOIN SitesTourists AS st
	                    	ON t.Id = st.TouristId
	                    	JOIN Sites AS s
	                    	ON st.SiteId = s.Id
	                    WHERE t.Name = @TouristName
	                  )

     IF (@siteCount >= 100)
	   UPDATE Tourists
	   SET Reward = 'Gold badge'
	 ELSE IF (@siteCount >= 50)
	   UPDATE Tourists
	   SET Reward = 'Silver badge'
	 ELSE IF (@siteCount >= 25)
	   UPDATE Tourists
	   SET Reward = 'Bronze badge'

	   SELECT Name, Reward
	   FROM Tourists
	   WHERE Name = @TouristName
END

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
EXEC usp_AnnualRewardLottery 'Teodor Petrov'