CREATE TABLE [dbo].[SampleSelection] (
    [SelectionID]    INT          IDENTITY (1, 1) NOT NULL,
    [SelectionName]  VARCHAR (50) NOT NULL,
    [SelectionValue] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SampleSelection] PRIMARY KEY CLUSTERED ([SelectionID] ASC)
);

