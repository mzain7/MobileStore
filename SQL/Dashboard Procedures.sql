-- Need to specify default values
CREATE OR ALTER PROC sales.uspOrderCountWithinDates(
	@fromDate AS DATE,
	@toDate AS DATE
)
AS
BEGIN
	SELECT 
		COUNT(OrderID) 
	FROM 
		sales.[Orders] 
	WHERE 
		OrderDate BETWEEN  
		@fromDate AND @toDate;
END;

-- Need to specify default values
CREATE OR ALTER PROC stock.uspGetProductAnalysis(
	@fromDate AS DATE,
	@toDate AS DATE
)
AS
BEGIN
	SELECT TOP 5 
		Brand, 
		Model,
		SUM(od.Quantity) AS Quantity 
	FROM 
		stock.Products p 
	INNER JOIN 
		sales.OrderDetails od 
	ON p.ProductID = od.ProductID 
	WHERE
		od.OrderID 
	IN 
		(
			SELECT 
				OrderID 
			FROM 
				sales.Orders o
			WHERE 
				o.OrderDate 
			BETWEEN @fromDate AND @toDate 
		) 
	GROUP BY
		od.ProductID, Brand, Model 
	ORDER BY Quantity desc;
END

CREATE OR ALTER PROC sales.uspGetOrderAnalysis(
	@fromDate AS DATE,
	@toDate AS DATE
)
AS
BEGIN
	SELECT
		o.Orderdate, 
		sum((p.price-p.price*(od.discount/100))*od.quantity)
	FROM 
		sales.Orders o 
	INNER JOIN 
		sales.OrderDetails od 
	ON o.OrderID = od.OrderID 
	INNER JOIN 
		stock.Products p 
	ON od.ProductID = p.ProductID 
	WHERE 
		o.OrderDate 
			BETWEEN @fromDate AND @toDate 
	GROUP BY
		o.OrderDate;
END;


CREATE OR ALTER PROC sales.uspGetProfit(
	@fromDate AS DATE,
	@toDate AS DATE
)
AS
BEGIN
	select isNull(sum(temp.price), 0) from(
    select ((p.price-p.price*(od.discount/100) - 
	ISNULL((SELECT TOP 1 SD.UnitPrice FROM stock.ShipmentDetails SD WHERE SD.ProductID = P.ProductID),p.price *0.7))*od.quantity) as price
	from
	sales.Orders o inner join sales.OrderDetails od on o.OrderID = od.OrderID
    inner join stock.Products p on od.ProductID = p.ProductID where o.OrderDate between @fromDate and @toDate)temp
END;

delete from sales.orders
delete from sales.orderDetails
