CREATE TABLE [dbo].[Owners] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [HasLimitPerMonth] BIT NOT NULL,
    [PersonId]         INT NULL,
    [LimitId]          INT NULL,
    CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_PersonOwner] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

