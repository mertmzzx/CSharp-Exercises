CREATE DATABASE TableRelations

USE TableRelations

CREATE TABLE Passports (
    PassportID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	PassportNumber VARCHAR(8) UNIQUE NOT NULL
)

CREATE TABLE People (
    PersonID INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
)

INSERT INTO Passports (PassportNumber)
VALUES
     ('N34FG21B'),
	 ('K65LO4R7'),
	 ('ZE657QP2')

INSERT INTO People (FirstName, Salary, PassportID)
VALUES
     ('Roberto', 43300.00, 102),
	 ('Tom', 56100.00, 103),
	 ('Yana', 60200.00, 101)

DROP TABLE People
DROP TABLE Passports

-- 2
CREATE TABLE Manufacturers (
    ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATETIME2
)

INSERT INTO Manufacturers 
    ([Name], EstablishedOn)
VALUES
    ('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

CREATE TABLE Models (
    ModelID INT PRIMARY KEY IDENTITY(100,1),
	[Name] VARCHAR(100) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO Models
    ([Name], ManufacturerID)
VALUES
    ('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

DROP TABLE Models
DROP TABLE Manufacturers

-- 3
CREATE TABLE Exams (
    ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams (
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students
    ([Name])
VALUES
    ('Mila'),
	('Toni'),
	('Ron')

INSERT INTO Exams 
    ([Name])
VALUES
    ('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO StudentsExams
    (StudentID, ExamID)
VALUES
    (1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

DROP TABLE StudentsExams
DROP TABLE Exams
DROP TABLE Students

-- 4

CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
    ([Name], ManagerID)
VALUES
    ('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

SELECT * FROM Teachers

DROP TABLE Teachers

-- 5
CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Cities (
    CItyID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Birthday DATETIME2, -- DATE
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes (
    ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items (
    ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems (
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
	PRIMARY KEY ([OrderID], [ItemID])
)

-- 6

USE TableRelations

CREATE TABLE Subjects (
    SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50) NOT NULL
)

CREATE TABLE Majors (
    MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda (
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATETIME2 NOT NULL,
	PaymentAmount FLOAT NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

DROP TABLE Payments, Agenda, Students, Majors, Subjects
