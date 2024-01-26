CREATE OR ALTER PROC stock.uspInsertShipment(
	@supplierID AS INT,
	@employeeID AS INT,
	@date AS Date
)
AS
BEGIN
	INSERT INTO 
		stock.Shipment 
	OUTPUT inserted.ShipmentID 
	VALUES
	(
		@supplierID,
		@employeeId, 
		@date
	);
END


CREATE OR ALTER PROC stock.uspInsertShipmentDetails(
	@ShipmentID AS INT,
	@productID AS INT, 
	@quantity AS INT,
	@UnitPrice AS FLOAT
)
AS
BEGIN
	INSERT INTO	stock.ShipmentDetails
	VALUES
	(
		@ShipmentID, 
		@productID, 
		@quantity, 
		@UnitPrice
	);
END

select * from stock.Shipment
select * from stock.ShipmentDetails d where d.ShipmentID = 4