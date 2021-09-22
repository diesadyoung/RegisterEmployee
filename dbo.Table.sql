CREATE TABLE [dbo].[Table] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Surname]     VARCHAR (MAX) NULL,
    [Name]        VARCHAR (MAX) NULL,
    [Patronymic]  VARCHAR (MAX) NULL,
    [Date]        DATETIME      NULL,
    [CompanyName] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

