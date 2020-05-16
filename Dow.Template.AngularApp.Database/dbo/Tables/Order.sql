CREATE TABLE [dbo].[Order]
(
	[OrderID] INT NOT NULL PRIMARY KEY, 
    [OrderDate] DATETIME NOT NULL, 
    [ContactName] NVARCHAR(50) NOT NULL, 
    [Customer] NVARCHAR(50) NOT NULL, 
    [Employee] NVARCHAR(50) NOT NULL, 
    [ShipName] NVARCHAR(50) NOT NULL, 
    [ShipCountry] NVARCHAR(50) NOT NULL, 
    [ShipCity] NVARCHAR(50) NOT NULL, 
    [ShipAddress] NVARCHAR(50) NOT NULL, 
    [ShipPostCode] NVARCHAR(50) NOT NULL, 
    [ShipVia] NVARCHAR(50) NOT NULL
)
