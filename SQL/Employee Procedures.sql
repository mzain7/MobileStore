CREATE OR ALTER PROCEDURE staff.uspAddEmployee(
	@firstname AS VARCHAR(10),
	@lastname AS VARCHAR(15),
	@cnic AS VARCHAR(13),
	@title AS VARCHAR(20),
	@salary AS VARCHAR(20),
	@dob AS DATE,
	@hiredate AS DATE,
	@address AS VARCHAR(20),
	@city AS VARCHAR(10),
	@contact AS VARCHAR(13),
	@email AS VARCHAR(25)
)
AS
BEGIN
	INSERT INTO 
		staff.Employees (
			FirstName, LastName, 
			CNIC, Title, 
			Salary, DOB, 
			HireDate, [Address], 
			City, Contact,
			EMail
		)
    VALUES (
		@firstname, @lastname, 
		@cnic, @title, 
		@salary, @DOB, 
		@hiredate, @Address, 
		@City, @Contact, 
		@Email
	);
END

CREATE OR ALTER PROCEDURE staff.uspDeleteEmployee(@employeeid AS INT)
AS
BEGIN
	DELETE 
	FROM 
		staff.Employees 
	WHERE 
		EmployeeID = @employeeid;
END

CREATE OR ALTER PROCEDURE staff.uspSearchEmployee(
	@employeeid AS VARCHAR(10) = '%',
	@firstname AS VARCHAR(10) = NULL,
	@lastname AS VARCHAR(15) = NULL,
	@cnic AS VARCHAR(13) = NULL,
	@title AS VARCHAR(20) = NULL,
	@salary AS VARCHAR(20) = NULL,
	@address AS VARCHAR(20) = NULL,
	@city AS VARCHAR(10) = NULL,
	@contact AS VARCHAR(13) = NULL,
	@email AS VARCHAR(25) = NULL
)
AS 
BEGIN
	SELECT 
			* 
	FROM 
		staff.Employees 
	WHERE 
		CAST(EmployeeID as varchar(10)) LIKE @employeeid AND 
		(@firstname IS NULL OR FirstName LIKE @firstname) AND 
		(@lastname IS NULL OR LastName LIKE @lastname) AND 
		(@cnic IS NULL OR CNIC LIKE @cnic) AND 
		(@title IS NULL OR Title LIKE @title) AND
		(@salary IS NULL OR Salary LIKE @salary) AND 
		(@address IS NULL OR [Address] LIKE @address) AND 
		(@city IS NULL OR City LIKE @city) AND 
		(@contact IS NULL OR Contact LIKE @contact) AND 
		(@email IS NULL OR EMail LIKE @email)
	ORDER BY
		EmployeeID;
END;

CREATE OR ALTER PROC staff.uspUpdateEmployee(
	@employeeid AS INT,
	@firstname AS VARCHAR(10),
	@lastname AS VARCHAR(15),
	@cnic AS VARCHAR(13),
	@title AS VARCHAR(20),
	@salary AS VARCHAR(20),
	@dob AS DATE,
	@hiredate AS DATE,
	@address AS VARCHAR(20),
	@city AS VARCHAR(10),
	@contact AS VARCHAR(13),
	@email AS VARCHAR(25)
)
AS
BEGIN
	UPDATE 
		Employees
	SET
		FirstName = @firstname,
		LastName = @lastname,
		CNIC = @cnic,
		Title = @title,
		Salary = @salary,
		DOB = @dob,
		HireDate = @hiredate,
		[Address] = @address,
		City = @city,
		Contact = @contact,
		EMail = @email
	WHERE 
		EmployeeID = @employeeid;
END;


EXEC staff.uspSearchEmployee
	@firstname = 'Jane';

EXEC staff.uspAddEmployee 
	'John', 'Doe', 
	'1234567890123', 'Manager',
	5000.00, '1990-01-01', 
	'2010-05-15', '123 Main St', 
	'New York', '1234567890', 'john@example.com';

SELECT * FROM staff.Employees;