CREATE TABLE [dbo].[BankingAccounts] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [AvailibleSum] DECIMAL (18, 2) NOT NULL,
    [KredLimits]   DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_BankingAccounts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

