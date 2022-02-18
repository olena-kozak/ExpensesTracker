CREATE TABLE [dbo].[Messages] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [MessageType] NVARCHAR (MAX) NOT NULL,
    [DateTime]    DATETIME2 (7)  NOT NULL,
    [CardId]      INT            NOT NULL,
    [PlaceId]     INT            NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CardId]) REFERENCES [dbo].[Cards] ([Id]),
    FOREIGN KEY ([PlaceId]) REFERENCES [dbo].[Places] ([Id])
);

