CREATE DATABASE MobileStore

IF NOT EXISTS (
    SELECT * FROM sys.tables t 
    JOIN sys.schemas s ON (t.schema_id = s.schema_id) 
    WHERE s.name = 'sales' AND t.name = 'Customers') 	
    CREATE TABLE sales.Customers 
	(
		CustomerID INT IDENTITY(100,1) PRIMARY KEY,
		FirstName VARCHAR(20) NOT NULL,
		LastName VARCHAR(25),
		CNIC VARCHAR(13) UNIQUE,
		[Address] VARCHAR(30),
		City VARCHAR(30),
		Contact VARCHAR(13) NOT NULL,
		EMail VARCHAR(30) CHECK (EMail LIKE '%_@__%.__%')
	);
	--select * from customers
	--select * from OrderDetails where OrderID = 87
	--select * from Orders where CustomerID = 123
	--select * from Products where ProductID = 18


IF NOT EXISTS (
    SELECT * FROM sys.tables t 
    JOIN sys.schemas s ON (t.schema_id = s.schema_id) 
    WHERE s.name = 'staff' AND t.name = 'Employees') 	
    CREATE TABLE staff.Employees 
	(
		EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
		FirstName VARCHAR(20) NOT NULL,
		LastName VARCHAR(25) NOT NULL,
		CNIC VARCHAR(13) UNIQUE not null,
		Title VARCHAR(40) NOT NULL,
		Salary MONEY NOT NULL CHECK (Salary > 0),
		DOB DATE NOT NULL CHECK (DOB <= GETDATE()),
		HireDate DATE NOT NULL CHECK (HireDate <= GETDATE()),
		[Address] VARCHAR(30) ,
		City VARCHAR(40) ,
		Contact VARCHAR(13) NOT NULL,
		EMail VARCHAR(40) NOT NULL CHECK (EMail LIKE '%_@__%.__%')
	);


IF NOT EXISTS (
    SELECT * FROM sys.tables t 
    JOIN sys.schemas s ON (t.schema_id = s.schema_id) 
    WHERE s.name = 'stock' AND t.name = 'Suppliers') 	
    CREATE TABLE stock.Suppliers 
	(
		SupplierID INT IDENTITY(1,1) PRIMARY KEY,
		CompanyName VARCHAR(40) NOT NULL,
		[Address] VARCHAR(30),
		City VARCHAR(30),
		Country VARCHAR(40),
		Contact VARCHAR(13) NOT NULL,
		EMail VARCHAR(40) CHECK (EMail LIKE '%_@__%.__%')
	);

IF NOT EXISTS (
    SELECT * FROM sys.tables t 
    JOIN sys.schemas s ON (t.schema_id = s.schema_id) 
    WHERE s.name = 'sales' AND t.name = 'Orders') 	
    CREATE TABLE sales.Orders 
	(
		OrderID INT IDENTITY(1,1) PRIMARY KEY,
		CustomerID INT FOREIGN KEY REFERENCES sales.Customers(CustomerID),
		EmployeeID INT FOREIGN KEY REFERENCES staff.Employees(EmployeeID),
		OrderDate DATE DEFAULT GETDATE() CHECK (OrderDate <= GETDATE()),
	);


IF NOT EXISTS (
    SELECT * 
	FROM 
		sys.tables t 
    JOIN 
		sys.schemas s 
	ON (t.schema_id = s.schema_id) 
    WHERE 
		s.name = 'stock' AND 
		t.name = 'Shipment'
		) 	
    CREATE TABLE stock.Shipment 
	(
		ShipmentID INT IDENTITY(1,1) PRIMARY KEY,
		SupplierID INT FOREIGN KEY REFERENCES stock.Suppliers(SupplierID),
		EmployeeID INT FOREIGN KEY REFERENCES staff.Employees(EmployeeID),
		OrderDate DATE DEFAULT GETDATE() CHECK (OrderDate <= GETDATE())
	);

IF NOT EXISTS (
    SELECT * 
	FROM 
		sys.tables t 
    JOIN 
		sys.schemas s 
	ON (t.schema_id = s.schema_id) 
    WHERE 
		s.name = 'stock' AND 
		t.name = 'Products'
	) 	
    CREATE TABLE stock.Products 
	(
		ProductID INT IDENTITY(1,1),
		Brand VARCHAR(30) NOT NULL,
		Model VARCHAR(30) NOT NULL,
		Quantity INT NOT NULL CHECK (Quantity >= 0),
		Price MONEY NOT NULL CHECK (Price > 0),
		OS VARCHAR(25),
		RAM VARCHAR(20),
		Storage VARCHAR(20),
		Camera VARCHAR(20),
		BatteryCapacity VARCHAR(20),
		Display VARCHAR(20),
		Processor VARCHAR(40),
		Used BIT,
		[Description] VARCHAR(100),
		PRIMARY KEY(ProductId),
		UNIQUE(brand, model)
	);

		alter table stock.products
		alter column Processor varchar(40)

IF NOT EXISTS (
    SELECT * 
	FROM 
		sys.tables t 
    JOIN 
		sys.schemas s 
	ON (t.schema_id = s.schema_id) 
    WHERE 
		s.name = 'sales' AND 
		t.name = 'OrderDetails'
	) 	
    CREATE TABLE sales.OrderDetails 
	(
		OrderID	INT FOREIGN KEY REFERENCES sales.Orders(OrderID),
		ProductID INT FOREIGN KEY REFERENCES stock.Products(productid),
		Quantity INT NOT NULL CHECK (Quantity >= 0),
		Discount FLOAT CHECK (Discount >= 0 AND Discount <= 1),
		PRIMARY KEY(ProductID, OrderID)
	);

IF NOT EXISTS (
    SELECT * 
	FROM	
		sys.tables t 
    JOIN 
		sys.schemas s 
	ON (t.schema_id = s.schema_id) 
    WHERE 
		s.name = 'stock' AND 
		t.name = 'ShipmentDetails'
	) 	
    CREATE TABLE stock.ShipmentDetails
	(
		ShipmentID INT FOREIGN KEY REFERENCES stock.Shipment(ShipmentID),
		ProductID INT FOREIGN KEY REFERENCES stock.Products(ProductID),
		Quantity INT NOT NULL,
		UnitPrice INT,
		PRIMARY KEY(ProductID, ShipmentID)
	);


/*
select brand, model, sum(od.Quantity) as total from products p inner join OrderDetails od on p.ProductID = od.ProductID
--where od.OrderID in (select OrderID from Orders o where o.OrderDate between and )
group by od.ProductID, Brand, Model
order by total desc

select (select Brand from Products pro where temp.ProductID = pro.ProductID) as brand,
(select Model from Products pro where temp.ProductID = pro.ProductID) as model, temp.total
from
(select od.productId, sum(od.quantity) as total from OrderDetails od
--where od.OrderID in (select OrderID from Orders o where o.OrderDate between and )
group by od.ProductID)temp
order by total desc


select o.orderdate, sum(p.price*od.quantity) from Orders o inner join OrderDetails od on o.OrderID = od.OrderID inner join Products p on od.ProductID = p.ProductID
where o.OrderDate between @ and @
group by o.OrderDate
*/

