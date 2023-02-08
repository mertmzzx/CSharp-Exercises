CREATE DATABASE Zoo

GO

USE Zoo

GO

-- DDL

CREATE TABLE Owners 
     (
         Id INT PRIMARY KEY IDENTITY,
	     [Name] VARCHAR(50) NOT NULL,
	     PhoneNumber VARCHAR(15) NOT NULL,
	     [Address] VARCHAR(50)
	 )

CREATE TABLE AnimalTypes 
     (
         Id INT PRIMARY KEY IDENTITY,
	     AnimalType VARCHAR(30) NOT NULL
     )

CREATE TABLE Cages 
     (
         Id INT PRIMARY KEY IDENTITY,
	     AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
	 )

CREATE TABLE Animals 
     (
         Id INT PRIMARY KEY IDENTITY,
	     [Name] VARCHAR(30) NOT NULL,
	     BirthDate DATE NOT NULL,
	     OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	     AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
	 )

CREATE TABLE AnimalsCages 
     (
         CageID INT FOREIGN KEY REFERENCES Cages(Id),
	     AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	     PRIMARY KEY(CageID, AnimalId)
	 )

CREATE TABLE VolunteersDepartments 
     (
         Id INT PRIMARY KEY IDENTITY,
	     DepartmentName VARCHAR(30) NOT NULL
	 )

CREATE TABLE Volunteers 
     (
         Id INT PRIMARY KEY IDENTITY,
	     [Name] VARCHAR(50) NOT NULL,
	     PhoneNumber VARCHAR(15) NOT NULL,
	     [Address] VARCHAR(50),
	     AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	     DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
	 )


-- Insert
INSERT INTO Animals
            (Name, BirthDate, OwnerId, AnimalTypeId)
     VALUES 
            ('Giraffe', '2018-09-21', 21, 1),
            ('Harpy Eagle', '2015-04-17', 15, 3),
            ('Hamadryas Baboon', '2017-11-02', NULL, 1),
            ('Tuatara', '2021-06-30', 2, 4)
           
INSERT INTO Volunteers
            (Name, PhoneNumber, Address, AnimalId, DepartmentId)
     VALUES
            ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
            ('Dimitur Stoev', '0877564223', NULL, 42, 4),
            ('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
            ('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
            ('Boryana Mileva', '0888112233', NULL, 31, 5)

-- Update
UPDATE Animals 
   SET OwnerId = (
                 SELECT Id 
                 FROM Owners AS o
                 WHERE o.Name = 'Kaloqn Stoqnov'
				 )
   WHERE OwnerId IS NULL

SELECT *
FROM Animals AS a
WHERE a.OwnerId IS NULL

-- Delete
DELETE
FROM Volunteers
WHERE DepartmentId = (
                      SELECT Id
					  FROM VolunteersDepartments AS vd
					  WHERE vd.DepartmentName = 'Education program assistant'
					  )

DELETE
FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

-- Querying
-- 5
SELECT Name,PhoneNumber, Address, AnimalId, DepartmentId 
FROM Volunteers
ORDER BY Name, AnimalId, DepartmentId

-- 6
SELECT a.Name, 
       ats.AnimalType,
       FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals AS a
       INNER JOIN AnimalTypes AS ats ON a.AnimalTypeId = ats.Id
ORDER BY a.Name 

-- 7
SELECT TOP(5)
     o.Name,
	 COUNT(a.Id) AS CountOfAnimals
FROM Owners AS o
   LEFT JOIN Animals AS a ON o.Id = a.OwnerId
GROUP BY o.Name
ORDER BY CountOfAnimals DESC, o.Name

-- 8
SELECT CONCAT(o.Name, '-',a.Name) AS OwnersAnimals,
       o.PhoneNumber,
	   ac.CageID
FROM Owners AS o
   INNER JOIN Animals AS a ON o.Id = a.OwnerId
   INNER JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
   INNER JOIN AnimalsCages AS ac ON a.Id = ac.AnimalId
WHERE at.AnimalType = 'Mammals'
ORDER BY o.Name, a.Name DESC

-- 9
SELECT Name, PhoneNumber, LTRIM(REPLACE(REPLACE(Address, 'Sofia', ''), ',', ''))
FROM Volunteers
WHERE DepartmentId = (
                        SELECT Id
						FROM VolunteersDepartments
						WHERE DepartmentName = 'Education program assistant'
						)
						AND Address LIKE('%Sofia%')
ORDER BY Name

-- 10
SELECT a.Name, YEAR(a.BirthDate) AS BirthYear, at.AnimalType
FROM Animals AS a
    INNER JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
WHERE OwnerId IS NULL 
      AND at.AnimalType <> 'Birds' 
      AND DATEDIFF(YEAR, a.BirthDate, '01/01/2022') < 5 
ORDER BY a.Name

-- Programmability
-- 11
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
     DECLARE @departmeintId INT;
	 SET @departmeintId = (
	                       SELECT Id
						   FROM VolunteersDepartments
						   WHERE DepartmentName = @VolunteersDepartment
						  );

     DECLARE @VolunteersCount INT;
	 SET @VolunteersCount = (
	                         SELECT COUNT(*)
							 FROM Volunteers
							 WHERE DepartmentId = @departmeintId
							);
     RETURN @VolunteersCount;
END

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

-- 12
CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
     AS
  BEGIN
            SELECT a.Name,
                   ISNULL(o.Name, 'For Adoption')
 	          AS OwnersName
            FROM Animals AS a
                LEFT JOIN Owners 
				AS o 
				ON a.OwnerId = o.Id
			WHERE a.Name = @AnimalName
  END        
  
EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'