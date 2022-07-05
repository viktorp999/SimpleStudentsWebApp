CREATE TABLE [dbo].[StudentTB] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [First_Name] VARCHAR (MAX) NULL,
    [Last_Name]  VARCHAR (MAX) NULL,
    [University] VARCHAR (MAX) NULL,
    [Faculity]   VARCHAR (MAX) NULL,
    [Grade]      INT           NULL,
    [Study_Type] VARCHAR (MAX) NULL,
    [Kvota]      VARCHAR (MAX) NULL,
    CONSTRAINT [PK_StudentTB] PRIMARY KEY CLUSTERED ([ID] ASC)
);

