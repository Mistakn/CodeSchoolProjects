-- SELECT Shippers.CompanyName, COUNT(OrderID) as OrdersSent
-- FROM Orders
-- INNER JOIN Shippers ON Shippers.ShipperID = Orders.ShipVia
-- GROUP BY Shippers.CompanyName
-- HAVING
-- ORDER BY


-- SELECT Country, COUNT(CustomerID) as NumberOfClients
-- FROM Customers
-- GROUP BY Country
-- HAVING COUNT(CustomerID) BETWEEN 5 AND 11
-- ORDER BY NumberOfClients DESC


-- SELECT Employees.LastName, COUNT(Orders.OrderID) as CountOrders
-- FROM Employees
-- INNER JOIN Orders ON Orders.EmployeeID = Employees.EmployeeID
-- WHERE (Employees.LastName LIKE 'Davolio'
-- OR Employees.LastName LIKE 'Fuller')
-- GROUP BY Employees.LastName
-- HAVING COUNT(Orders.OrderID) > 25


-- SELECT ContactName
-- FROM Suppliers
-- WHERE EXISTS (SELECT ProductName FROM Products WHERE Products.SupplierID = Suppliers.supplierID AND UnitPrice < 20); 

-- The following SQL statement lists the ProductName if it finds ANY records in the OrderDetails table has Quantity equal to 10 (this will return TRUE because the Quantity column has some values of 10):
-- SELECT ProductName
-- FROM Products
-- WHERE ProductID = ANY
--   (SELECT ProductID
--   FROM [Order Details]
--   WHERE Quantity = 10);    


-- SELECT ProductName
-- FROM Products
-- WHERE ProductID = ALL
--   (SELECT ProductID
--   FROM [Order Details]
--   WHERE Quantity = 10); 


-- SELECT OrderID, Quantity,
-- CASE
--     WHEN Quantity > 30 THEN 'The quantity is greater than 30'
--     WHEN Quantity = 30 THEN 'The quantity is 30'
--     ELSE 'The quantity is under 30'
-- END AS QuantityText
-- FROM [Order Details]; 


-- SELECT ContactName, City, Country
-- FROM Customers
-- ORDER BY
-- (CASE
--     WHEN City IS NULL THEN Country
--     ELSE City
-- END); 

-- SELECT CONCAT('SQL', ' is', ' fun!');

-- print CONCAT('SQL', ' is', ' fun!');
-- SELECT CONCAT_WS('+', 'SQL', 'is', 'fun!'); 

-- SELECT LEFT('SQL Tutorial', 3) AS ExtractString;

-- SELECT SUBSTRING('SQL Tutorial', 1, 3) AS ExtractString;

-- SELECT TRANSLATE('Monday', 'Monday', 'Sunday')

-- SELECT DATEADD(year, 1, '2017/08/25') AS DateAdd;

-- SELECT DATEDIFF(year, '2017/08/25', '2011/08/25') AS DateDiff;
-- SELECT DATEDIFF(month, '2017/08/25', '2011/08/25') AS DateDiff;
-- SELECT DATEDIFF(hour, '2017/08/25 07:00', '2017/08/25 12:45') AS DateDiff;

-- SELECT DATENAME(year, '2017/08/25') AS DatePartString;
-- SELECT DATENAME(month, '2017/08/25') AS DatePartString;
-- SELECT DATENAME(hour, '2017/08/25 08:36') AS DatePartString;
-- SELECT DATENAME(minute, '2017/08/25 08:36') AS DatePartString;

-- SELECT DATEPART(yy, '2017/08/25') AS DatePartInt;
-- SELECT DATEPART(minute, '2017/08/25 08:36') AS DatePartInt;

-- SELECT DAY('2017/08/25') AS DayOfMonth;
-- SELECT DAY('2017/08/13 09:08') AS DayOfMonth;

-- SELECT SERVERPROPERTY('collation') AS ServerCollation;

-- SELECT * FROM Products 
-- where ProductName = 'chang'

-- SELECT * FROM Products 
-- WHERE ProductName COLLATE SQL_Latin1_General_CP1_CS_AS ='chang'

-- DECLARE @Today DATETIME;  
-- SET @Today = '12/5/2007';  
  
-- SET LANGUAGE Italian;  
-- SELECT DATENAME(month, @Today) AS 'Month Name';  
  
-- SET LANGUAGE us_english;  
-- SELECT DATENAME(month, @Today) AS 'Month Name' ;  
-- GO

-- SELECT ISDATE('2017-08-25');
-- SELECT ISDATE('Hello world!');

-- SELECT 'Hello world!' as Date, 
-- CASE
--     WHEN ISDATE('Hello world!') = 1 THEN 'Valid date'
--     ELSE 'Invalid date'
-- END AS DateIsValid

-- DECLARE @Today DATETIME;  
-- SET @Today = GETDATE(); 

-- SELECT
-- CASE
--     WHEN ISDATE(@Today) = 0 THEN 'No es una fecha correcta'
--     ELSE 
--     CASE
--         WHEN DATEPART(DD, @Today) = 4 THEN 'Es el mismo dia'
--         ELSE 'No es el dia que queriamos'
--     END
-- END as Result

-- SELECT MONTH('2017/08/25') AS Month;

-- SELECT CAST(25.65 AS int); 
-- SELECT CAST(25.65 AS varchar); 
-- SELECT CAST('2017-08-25' AS datetime); 

-- SELECT CONVERT(int, 25.65); 
-- SELECT CONVERT(varchar, 25.65); 
-- SELECT CONVERT(datetime, '2017-08-25'); 
-- SELECT CONVERT(varchar, '2017-08-25', 101); 

-- SELECT IIF(500<1000, 'YES', 'NO'); 
-- SELECT IIF(500<1000, 5, 10); 

-- SELECT OrderID, Quantity, IIF(Quantity>10, 'MORE', 'LESS')
-- FROM [Order Details]; 

-- SELECT ISNULL(NULL, 'W3Schools.com'); 
-- SELECT ISNULL('Hello', 'W3Schools.com'); 

-- SELECT ISNUMERIC(4567); 
-- SELECT ISNUMERIC('4567'); 
-- SELECT ISNUMERIC('Hello world!');   
-- SELECT ISNUMERIC(20*3); 
-- SELECT ISNUMERIC('2017-08-25'); 

-- SELECT NULLIF(25, 25);
-- SELECT NULLIF('Hello', 'world');

-- CREATE PROCEDURE SelectAllCustomers
-- AS
-- SELECT * FROM Customers
-- GO;

-- EXEC SelectAllCustomers;


-- Select o.OrderID, c.ContactName, od.UnitPrice * od.Quantity as [Total Order]
-- from Orders o
-- inner join Customers c on o.CustomerID = c.CustomerID
-- inner join [Order Details] od on o.OrderID = od.OrderID
-- where o.OrderID = 10281
-- group by o.OrderId, od.UnitPrice,od.Quantity, c.ContactName

-- Select o.OrderID, c.ContactName, SUM(od.UnitPrice * od.Quantity) as [Total Order]
-- from Orders o
-- inner join Customers c on o.CustomerID = c.CustomerID
-- inner join [Order Details] od on o.OrderID = od.OrderID
-- group by o.OrderID, c.ContactName

-- Retornar Ciudad, CompanyName, ContactName y una Columna llamada RelationShip Tanto de la tabla Customers como de la tabla Suppliers en un solo resultado, en la columna de Relationship debe de decir 'Customers' cuando este haciendo referencia a esa tabla y 'Suppliers' cuando esta haciendo referencia esa

-- SELECT City, CompanyName, ContactName, 'Customers' AS [Relationship]
-- FROM Customers
-- UNION SELECT City, CompanyName, ContactName, 'Suppliers'
-- FROM Suppliers
-- ORDER BY City, CompanyName;

SELECT c.CategoryName, p.ProductName, p.QuantityPerUnit, p.UnitsInStock, p.Discontinued
FROM Categories c
INNER JOIN Products p on p.CategoryID = c.CategoryID
WHERE p.Discontinued = 0