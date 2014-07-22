CREATE TABLE [dbo].[Reservations] (
    [Id]       INT                NOT NULL,
    [Date]     DATETIMEOFFSET (7) NOT NULL,
    [Name]     NVARCHAR (50)      NOT NULL,
    [Email]    NVARCHAR (50)      NOT NULL,
    [Quantity] INT                NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

