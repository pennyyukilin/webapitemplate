CREATE TABLE [dbo].[Sample] (
    [SampleID]       INT             IDENTITY (1, 1) NOT NULL,
    [SampleName]     VARCHAR (50)    NOT NULL,
    [SampleValue1]   VARCHAR (200)   NOT NULL,
    [SampleValue2]   NVARCHAR (1000) NOT NULL,
    [SampleValue3]   VARCHAR (200)   NOT NULL,
    [SampleOrder]    INT             NOT NULL,
    [SelectionID1]   INT             NOT NULL,
    [SelectionID2]   VARCHAR (50)    NOT NULL,
    [Checked]        BIT             NOT NULL,
    [Radio]          INT             NOT NULL,
    [UploadPath]     VARCHAR (500)   NULL,
    [CreateTime]     DATETIME        NOT NULL,
    [CreatedBy]      VARCHAR (50)    NOT NULL,
    [LastUpdateTime] DATETIME        NOT NULL,
    [LastUpdateBy]   VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Sample] PRIMARY KEY CLUSTERED ([SampleID] ASC),
    CONSTRAINT [FK_Sample_SampleSelection_SelectionID1] FOREIGN KEY ([SelectionID1]) REFERENCES [dbo].[SampleSelection] ([SelectionID])
);

