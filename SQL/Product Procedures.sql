CREATE OR ALTER PROC stock.uspDeleteProduct(
	@ProductID AS INT)
AS
BEGIN
	DELETE 
	FROM 
		stock.Products 
	WHERE 
	ProductID = @ProductID;
END;

CREATE OR ALTER PROC stock.uspAddProduct(
	@Quantity AS INT,
	@Price AS MONEY, 
	@Brand AS VARCHAR(30), 
	@Model AS VARCHAR(30), 
	@OS AS VARCHAR(25), 
	@RAM AS VARCHAR(20), 
	@Storage AS VARCHAR(20), 
	@Camera AS VARCHAR(20), 
	@BatteryCapacity VARCHAR(20),
    @Display AS VARCHAR(20), 
	@Processor AS VARCHAR(20), 
	@Used AS BIT, 
	@Description AS VARCHAR(100)
)
AS 
BEGIN
	INSERT INTO stock.Products(
	Quantity, Price, Brand, 
	Model, OS, RAM, Storage,
	Camera, BatteryCapacity, 
	Display, Processor, 
	Used, [Description]
	)
	VALUES 
	(
		@Quantity, @Price, @Brand,
		@Model, @OS, @RAM, @Storage,
		@Camera, @BatteryCapacity,
        @Display, @Processor,
		@Used,  @Description
	);
END;

CREATE OR ALTER PROC stock.uspSearchProduct(
	@MaxPrice AS MONEY = NULL,
	@Brand AS VARCHAR(30) = '%', 
	@Model AS VARCHAR(30) = '%', 
	@OS AS VARCHAR(25) = '%', 
	@RAM AS VARCHAR(20) = '%', 
	@Storage AS VARCHAR(20) = '%', 
	@Camera AS VARCHAR(20) = '%', 
	@BatteryCapacity VARCHAR(20) = '%',
    @Display AS VARCHAR(20) = '%', 
	@Processor AS VARCHAR(20) = '%', 
	@Used AS BIT = NULL, 
	@Description AS VARCHAR(100) = '%'
)
AS
BEGIN
	SELECT 
		* 
	FROM 
		stock.Products 
	WHERE
		(@MaxPrice IS NULL OR Price <= @MaxPrice) AND
		Brand LIKE @Brand AND 
		Model LIKE @Model AND
		OS LIKE @OS AND
		RAM LIKE @RAM AND 
		Storage LIKE @Storage AND 
		Camera LIKE @Camera AND 
		BatteryCapacity LIKE @BatteryCapacity AND
		Display LIKE @Display AND 
		Processor LIKE @Processor AND
		(@Used IS NULL OR @Used = @Used) AND 
		[Description] LIKE @Description
	ORDER BY
		Price;
END;

CREATE OR ALTER PROC stock.uspUpdateProduct(
	@ProductID AS INT,
	@Brand AS VARCHAR(30),
	@Model AS VARCHAR(30),
	@Quantity AS INT,
	@Price AS MONEY,
	@OS AS VARCHAR(25), 
	@RAM AS VARCHAR(20), 
	@Storage AS VARCHAR(20), 
	@Camera AS VARCHAR(20), 
	@BatteryCapacity VARCHAR(20),
    @Display AS VARCHAR(20), 
	@Processor AS VARCHAR(20), 
	@Used AS BIT, 
	@Description AS VARCHAR(100)
)
AS
BEGIN
	UPDATE stock.Products
	SET 
		Brand = @Brand,
		Model = @Model,
		Quantity = @Quantity,
		Price = @Price,
		OS = @OS,
		RAM = @RAM,
		Storage = @Storage,
		Camera = @Camera,
		BatteryCapacity = @BatteryCapacity,
		Display = @Display,
		Processor = @Processor,
		Used = @Used,
		[Description] = @Description
	WHERE 
		ProductID = @ProductID;
END;

CREATE OR ALTER PROC stock.uspGetProductId(
	@Brand AS VARCHAR(30),
	@Model AS VARCHAR(30)
)
AS
BEGIN
	SELECT 
		ProductID
	FROM 
		stock.Products 
	WHERE 
		Brand=@Model AND Model= @Model
END

SELECT * FROM stock.products_info ORDER BY Price;

EXEC stock.uspSearchProduct 400.00;