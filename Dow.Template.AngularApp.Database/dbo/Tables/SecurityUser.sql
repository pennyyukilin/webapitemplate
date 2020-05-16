CREATE TABLE [dbo].[SecurityUser] (
    [SecurityUserId]    INT           NOT NULL IDENTITY,
	[UserId] VARCHAR(10) NOT NULL,
    [UserName]  NVARCHAR (100) NULL,
    [Email] NVARCHAR (100) NULL,
	[CreatedOn] DATETIME NULL,
	[CreatedBy] VARCHAR(10) NULL,
	[LastUpdatedOn] DATETIME NULL,
	[LastUpdatedBy] VARCHAR(10) NULL,
	[TenantCode] VARCHAR(10) NULL,
	[IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_User] PRIMARY KEY ([SecurityUserId])
);

