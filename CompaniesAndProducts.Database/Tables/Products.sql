CREATE TABLE [dbo].[Products] (
    [ProductKey]  INT            IDENTITY (1, 1) NOT NULL,
    [CompanyKey]  INT            NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (500) NULL,
    [Comission]   NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED ([ProductKey] ASC),
    CONSTRAINT [FK_dbo.Products_dbo.Companies_CompanyKey] FOREIGN KEY ([CompanyKey]) REFERENCES [dbo].[Companies] ([CompanyKey]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyKey]
    ON [dbo].[Products]([CompanyKey] ASC);

