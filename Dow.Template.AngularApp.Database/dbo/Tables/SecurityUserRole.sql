CREATE TABLE [dbo].[SecurityUserRole]
(
	[SecurityUserRoleId] INT NOT NULL PRIMARY KEY IDENTITY,
	[SecurityUserId] INT NULL,
	[SecurityRoleId] INT NULL, 
    CONSTRAINT [FK_SecurityUserRole_ToSecurityUser] FOREIGN KEY ([SecurityUserId]) REFERENCES [SecurityUser]([SecurityUserId]), 
    CONSTRAINT [FK_SecurityUserRole_ToSecurityRole] FOREIGN KEY ([SecurityRoleId]) REFERENCES [SecurityRole]([SecurityRoleId])
)
