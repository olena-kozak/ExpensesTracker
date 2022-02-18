CREATE TABLE [dbo].[Places] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [OTPSmartName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED ([Id] ASC)
);

