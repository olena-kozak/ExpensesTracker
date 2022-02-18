CREATE TABLE [dbo].[Users] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [PersonId] INT NULL,
    [LimitId]  INT NULL,
    [HasLimit] BIT NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Users__PersonId] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_PersonUser] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

