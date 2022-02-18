CREATE TABLE [dbo].[Person] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Surname]     NVARCHAR (MAX) NOT NULL,
    [PhoneNumber] VARCHAR (50)   NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([Id] ASC)
);

