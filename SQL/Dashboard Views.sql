CREATE OR ALTER VIEW sales.best_selling_products(
	Brand,
	Model,
	Quantity
)
AS
	SELECT TOP 5
		Brand,
		Model,
		SUM (od.Quantity)
	FROM
		stock.Products p
	INNER JOIN
		sales.OrderDetails od
	ON p.ProductID = od.ProductID
	GROUP BY
		Brand, Model
	ORDER BY
		SUM(od.Quantity);

CREATE OR ALTER VIEW stock.LowStockProducts
AS
	SELECT 
		Brand, 
		Model, 
		Quantity
	FROM 
		stock.Products
	WHERE
		Quantity <= 5;

CREATE INDEX ix_product_quantity
ON stock.Products(Quantity)
INCLUDE (Brand, Model);