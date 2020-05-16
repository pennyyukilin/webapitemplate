CREATE TABLE [dbo].[Product]
(
	[ProductID] INT NOT NULL PRIMARY KEY, 
    [ProductName] NVARCHAR(50) NOT NULL, 
    [Category] NVARCHAR(50) NOT NULL, 
    [UnitsInStock] INT NULL, 
    [UnitsOnOrder] INT NULL, 
    [RecorderLevel] INT NULL
)
