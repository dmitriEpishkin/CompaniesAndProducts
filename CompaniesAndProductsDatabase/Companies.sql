CREATE TABLE [dbo].[Companies]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NOT NULL, 
    [Description] NCHAR(300) NULL, 
    [Site] NCHAR(50) NULL
)
