Create Database SmartPhoneStoreDB

CREATE TABLE AdminLogin(AdminID VARCHAR(10) PRIMARY KEY , AdminPassword  VARCHAR(20) NOT NULL)

CREATE TABLE Customers(CustomerID INT PRIMARY KEY IDENTITY(1,1), CustomerPassword VARCHAR(20), FirstName VARCHAR(30), LastName VARCHAR(30),
MobileNumber VARCHAR(MAX) UNIQUE , EmailID VARCHAR(50) UNIQUE, AddressLine1 VARCHAR(80), AddressLine2 VARCHAR(80), PinCode INT , District VARCHAR(50) , CustomerState VARCHAR(20))


CREATE TABLE Products(ProductID INT PRIMARY KEY IDENTITY(1,1), BrandName VARCHAR(20), ModelName VARCHAR(30),RAM VARCHAR(10), ROM VARCHAR(20),
Display VARCHAR(50),Battery VARCHAR(20), PrimaryCamera VARCHAR(40) , SecondaryCamera VARCHAR(40), Processor VARCHAR(50), Color VARCHAR(30), SimType VARCHAR(30), 
OsName VARCHAR(40))

ALTER TABLE Products ADD  ImagePath VARCHAR(MAX)  


Alter TABLE Products ADD Price	INT 

CREATE TABLE Orders(OrderID INT PRIMARY KEY IDENTITY(1,1) , CustomerID INT FOREIGN KEY REFERENCES CUSTOMERS(CustomerID) , ProductID INT
FOREIGN KEY REFERENCES PRODUCTS(ProductID) , Quantity INT , OrderStatus VARCHAR(20), OrderedDate DATETIME , ExpectedDate DATETIME)

Alter TABLE Orders ADD OrderPrice	INT


CREATE TABLE Cart(CartID INT PRIMARY KEY IDENTITY(1,1), CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID), ProductID INT
FOREIGN KEY REFERENCES Products(ProductID), CartStatus VARCHAR(20) NOT NULL)

CREATE TABLE Images(ImageID INT PRIMARY KEY IDENTITY(1,1) , ImageName VARCHAR(250) , ImagePath VARCHAR(MAX), ProductID INT 
FOREIGN KEY REFERENCES Products(ProductID))

INSERT INTO AdminLogin values('admin' , 'admin')

	SELECT * FROM Products
	SELECT * FROM Customers
	SELECT * FROM Orders
	SELECT * FROM AdminLogin
	SELECT * FROM Cart

	truncate table Orders

	