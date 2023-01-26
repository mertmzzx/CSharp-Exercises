-- 1
CREATE DATABASE Minions

USE Minions

-- 2
CREATE TABLE Minions (
      Id INT PRIMARY KEY NOT NULL,
	  [Name] VARCHAR(100),
	  Age INT
)

CREATE TABLE Towns (
      Id INT PRIMARY KEY NOT NULL, 
      [Name] VARCHAR(100)
)

-- 3
ALTER TABLE Minions
    ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)


-- 4
INSERT INTO Towns (Id,[Name])
VALUES
    (1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')


INSERT INTO Minions
    (Id, [Name], Age, TownId) 
VALUES
    (1, 'Kevin',22, 1),
	(2, 'Bob',15, 3),
	(3, 'Steward', NULL, 2)

-- 5
TRUNCATE TABLE Minions

-- 6
DROP TABLE Minions
DROP TABLE Towns

-- 7 
CREATE TABLE People (
      Id INT PRIMARY KEY NOT NULL,
	  [Name] VARCHAR(200) NOT NULL,
	  ProfilePicture VARBINARY(MAX),
	  Height FLOAT,
	  [Weight] FLOAT,
	  Gender CHAR(1) NOT NULL,
	  Birthdate DATETIME2 NOT NULL,
	  Biography NVARCHAR(MAX)
)

INSERT INTO People
    (Id, [Name], ProfilePicture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
     (1, 'Ivan', null, 1.80, 73.2,'m', '03-21-2005', 'Alcoholic'),
	 (2, 'Gosho', null, 1.76, 85,'m', '06-14-2005', 'Alcoholic'),
	 (3, 'Minka', NULL, 1.70, 60.5,'f', '11-15-2002', 'Drug Dealer'),
	 (4, 'Pesho', NULL, 1.88, 73.2,'m', '05-23-1995', 'Drug Addict'),
	 (5, 'Kentof', NULL, 1.90, 80.5,'m', '12-03-2005', 'Driver')

-- 8
CREATE TABLE Users
(
    Id BIGINT PRIMARY KEY IDENTITY,
    Username VARCHAR(30) NOT NULL,
    [Password] VARCHAR(26) NOT NULL,
    ProfilePicture VARBINARY(MAX),
    LastLoginTime DATETIME2,
    IsDeleted BIT
);

INSERT INTO Users
   (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
   ('Gosho', 'parola1', null, '01-01-2023', 1),
   ('Pesho', 'parola2', null, '01-05-2023', 0),
   ('Ivan', 'parola3', null, '11-21-2022', 1),
   ('Dragan', 'parola4', null, '12-18-2022', 0),
   ('Kristiyan', 'parola5', null, '07-23-2022', 1)


-- 9 
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC070CA4D8CB
 
ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername 
PRIMARY KEY (Id, Username)

-- 10
ALTER TABLE Users
ADD CONSTRAINT CH_Password CHECK((LEN([Password]) >= 5))

-- 11
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime;

-- 12
ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CH_Username CHECK ((LEN(Username) >= 3))

-- 13
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName VARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors 
   (DirectorName, Notes)
VALUES
   ('Marco Skorseze', 'I didnt come up with anything yet.'),
   ('Elijah Martins', 'Idk'),
   ('Thomas Williams', 'Im lazy'),
   ('Santino Skorseze', 'Im smarter than Marco'),
   ('Michael Smith', 'afk')


CREATE TABLE Genres (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName VARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres 
   (GenreName, Notes)
VALUES
   ('Sci-fi', 'Star wars shit'),
   ('Action', 'Blood and shootings'),
   ('Crime', 'Mafioso shit'),
   ('Drama', 'For girls'),
   ('Fantasy', 'Idk')


CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories
    (CategoryName, Notes)
VALUES
    ('Category1', 'First Category'),
	('Category2', 'Second Category'),
	('Category3', 'Third Category'),
	('Category4', 'Fourth Category'),
	('Category5', 'Fifth Category')


CREATE TABLE Movies (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title VARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2,
	[Length] INT,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies 
    (Title, DirectorId, GenreId, CategoryId)
VALUES
    ('Gangsters Paradise', 1, 3, 3),
	('Outer Banks', 2, 4, 1),
	('Queens Gambit', 3, 2, 5),
	('Legend', 5, 5, 2),
	('GOT', 4, 2, 4)


-- 14
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(100) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT NOT NULL,
	WeekendRate INT
)

INSERT INTO Categories
   (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
   ('Category1', 8, 8, 10, 7),
   ('Category2', 5, 6, 3, 7),
   ('Category3', 7, 8, 9, 10)


CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(100) NOT NULL,
	Model VARCHAR(100) NOT NULL,
	CarYear INT,
	CategoryId INT,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(50) NOT NULL,
	Available VARCHAR(50) NOT NULL
)

INSERT INTO Cars
    (PlateNumber, Manufacturer, Model, Doors, Condition, Available)
VALUES
    ('VS85G5H', 'BMW', 'E60', 4, 'Factory New', 'Yes'),
	('G8K4L3B', 'Mercedes', 'S63', 4, 'Broken', 'No'),
	('LKM532K', 'Volkswagen', 'GOLF 7', 4, 'Factory New', 'Yes')


CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Title VARCHAR(100),
	Notes VARCHAR(MAX)
)

INSERT INTO Employees 
    (FirstName, LastName, Title, Notes)
VALUES
    ('Ivan', 'Ivanov', null, 'Tup na gadulka'),
	('Petar', 'Petkov', 'Random Title', 'Umen'),
	('Georgi', 'Georgiev', null, 'hepten prost')


CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenseNumber INT NOT NULL,
	FullName VARCHAR(150) NOT NULL,
	[Address] VARCHAR(100),
	City VARCHAR(100) NOT NULL,
	ZIPCode VARCHAR(6) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers 
    (DriverLicenseNumber, FullName, [Address], City, ZIPCode)
VALUES
    (12354, 'Vanko Vankov', null, 'Mastanli', 6700),
	(531254, 'Petko Petkov', null, 'Mumunlu', 4200),
	(2654432, 'Gogo Gogov', 'nqkude tam', 'Mastanli',6700) 


CREATE TABLE RentalOrders (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmpoyeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays INT,
	RateApplied INT,
	TaxRate INT NOT NULL,
	OrderStatus VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders
    (EmpoyeeId, CustomerId, CarId, KilometrageStart, KilometrageEnd, StartDate, EndDate, TaxRate, OrderStatus)
VALUES
    (2, 3, 4, 0, 240, '05-12-2022', '05-13-2022', 20, 'Accepted'),
	(1, 2, 3, 0, 180, '03-10-2022', '04-10-2022', 20, 'Shipping'),
	(4, 5, 2, 1, 260, '07-05-2022', '08-13-2022', 20, 'Delivered')
