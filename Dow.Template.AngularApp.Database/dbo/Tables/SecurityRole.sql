CREATE TABLE [dbo].[SecurityRole]
(
	[SecurityRoleId] INT NOT NULL PRIMARY KEY IDENTITY,
	[SecurityRoleName] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200) NULL,
	[IsActive] BIT NOT NULL DEFAULT  1
)
