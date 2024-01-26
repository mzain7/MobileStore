CREATE TRIGGER trg_DecreaseQuantity
ON sales.OrderDetails
AFTER INSERT
AS
BEGIN
	DECLARE @iQuantity INT,@iProductID INT


	SELECT @iQuantity = i.Quantity from inserted I
	SELECT @iProductID = i.ProductID from inserted i

    UPDATE stock.Products 
    SET Quantity = Quantity - @iQuantity
    WHERE ProductID = @iProductID;
END;



CREATE TRIGGER trg_IncreaseQuantity
ON stock.ShipmentDetails
AFTER INSERT
AS
BEGIN
    DECLARE @iQuantity INT,@iProductID INT


	SELECT @iQuantity = i.Quantity from inserted I
	SELECT @iProductID = i.ProductID from inserted i

    UPDATE stock.Products 
    SET Quantity = Quantity + @iQuantity
    WHERE ProductID = @iProductID;
END;

