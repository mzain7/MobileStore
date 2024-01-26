CREATE OR ALTER PROC sales.uspGetModel(
	@brand AS VARCHAR(30) = NULL
)
AS 
BEGIN
	SELECT
		Model
	FROM
		stock.Products
	WHERE
		(@brand IS NULL OR brand=@brand);
END;


CREATE OR ALTER PROC sales.uspAddCustomer(
	@FirstName AS VARCHAR(20), 
	@LastName AS VARCHAR(20), 
	@CNIC AS VARCHAR(13), 
	@Address AS VARCHAR(30),
	@City AS VARCHAR(30), 
	@Contact AS VARCHAR(13), 
	@Email  AS VARCHAR(30)
)
AS
BEGIN
	INSERT INTO 
		sales.Customers
	(
		FirstName,LastName, CNIC, 
		[Address], City, 
		Contact, EMail
	) 
	OUTPUT inserted.customerID 
	VALUES 
	(
		@FirstName,@LastName, @CNIC, 
		@Address, @City,
		@Contact, @Email
	);
END

CREATE OR ALTER PROC sales.uspInsertOrder(
	@customerID AS INT,
	@employeeID AS INT,
	@date AS Date
)
AS
BEGIN
	INSERT INTO 
		sales.Orders 
	OUTPUT inserted.orderid 
	VALUES
	(
		@customerID,
		@employeeId, 
		@date
	);
END

CREATE OR ALTER PROC sales.uspGetProductId(
	@brand AS VARCHAR(30) = NULL,
	@model AS VARCHAR(30) = NULL
)
AS
BEGIN
	SELECT	
		productID 
	FROM
		stock.Products 
	WHERE 
		(@brand IS NULL OR brand=@brand) AND 
		(@model IS NULL OR model=@model);
END;

CREATE OR ALTER PROC sales.uspInsertOrderDetails(
	@orderID AS INT,
	@productID AS INT, 
	@quantity AS INT,
	@discount AS FLOAT
)
AS
BEGIN
	INSERT INTO	sales.OrderDetails
	VALUES
	(
		@orderID, 
		@productID, 
		@quantity, 
		@discount
	);
END

CREATE OR ALTER PROC sales.uspDecrementQuantity(
	@quantity AS INT,
	@ProductID AS INT
)
AS
BEGIN
	UPDATE 
		stock.Products 
	SET 
		Quantity = Quantity - @quantity 
	WHERE 
		ProductID = @ProductID;
END

CREATE OR ALTER PROC sales.uspGetQtyNPrice(
	@brand AS VARCHAR(30) = NULL,
	@model AS VARCHAR(30) = NULL
)
AS
BEGIN
	SELECT 
		price, 
		quantity 
	FROM 
		stock.Products 
	WHERE
		(@brand IS NULL OR brand=@brand) AND 
		(@model IS NULL OR model=@model);
END