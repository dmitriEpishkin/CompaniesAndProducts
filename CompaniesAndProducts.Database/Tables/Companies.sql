CREATE TABLE [dbo].[Companies] (
    [CompanyKey]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (500) NULL,
    [Site]        NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_dbo.Companies] PRIMARY KEY CLUSTERED ([CompanyKey] ASC)
);

