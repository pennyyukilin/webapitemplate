CREATE TABLE [dbo].[OrderProduct]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [OrderID] INT NOT NULL, 
    [ProductID] INT NOT NULL, 
    [UnitPrice] FLOAT NULL, 
    [Quantity] INT NULL, 
    [Discount] FLOAT NULL, 
    [Total] FLOAT NULL
)
