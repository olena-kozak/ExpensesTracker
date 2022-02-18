CREATE TABLE [dbo].[Cards] (
    [Id]               INT    IDENTITY (1, 1) NOT NULL,
    [CardNumber]       BIGINT NULL,
    [BankingAccountId] INT    NULL,
    [CardOwnerId]      INT    NULL,
    [UserId]           INT    NULL,
    CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([BankingAccountId]) REFERENCES [dbo].[BankingAccounts] ([Id]),
    FOREIGN KEY ([CardOwnerId]) REFERENCES [dbo].[Owners] ([Id])
);

