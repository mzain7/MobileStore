CREATE TABLE employeeHistory
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
		EMail VARCHAR(40) NOT NULL CHECK (EMail LIKE '%_@__%.__%'),
		[TimeStamp] DATETIME DEFAULT GETDATE(),
		[Action] VARCHAR(10) NOT NULL
	);


CREATE TRIGGER trg_employeeUpdate
ON staff.Employees
FOR UPDATE
AS
BEGIN
	INSERT INTO employeeHistory
	(
	FirstName, LastName, 
			CNIC, Title, 
			Salary, DOB, 
			HireDate, [Address], 
			City, Contact,
			EMail,[TimeStamp] ,[Action])
	SELECT 
	I.FirstName, I.LastName, 
			I.CNIC, I.Title, 
			I.Salary, I.DOB, 
			I.HireDate, I.[Address], 
			I.City, I.Contact,
			I.EMail,GETDATE(),'UPDATE' FROM INSERTED I 

END;


select * from employeeHistory