CREATE TABLE [dbo].[Customers](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Nit] [varchar] (50),
	[Name] [varchar](50), 
	[Address] [varchar](100),
	[Telephone] [varchar](50),
	[CityId] [int],
	[StateId] [int],
	[CountryId] [int],
	[CreditLimit] [int],
	[AvalaibleCredit] [int],
	[VisitsPercentage] [decimal](18,2), 
	[SellerId] [int]
)
GO

CREATE TABLE [dbo].[Sellers](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL
)
GO

CREATE TABLE [dbo].[Countries](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) 
)
GO

CREATE TABLE [dbo].[States](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) , 
	[IdCountry] [int] 
)
GO

CREATE TABLE [dbo].[Cities](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) ,
	[IdState] [int] 
)
GO

ALTER TABLE [States] ADD FOREIGN KEY ([IdCountry]) REFERENCES [Countries] ([Id])
GO

ALTER TABLE [Cities] ADD FOREIGN KEY ([IdState]) REFERENCES [States] ([Id])
GO

ALTER TABLE [Customers] ADD FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id])
GO

ALTER TABLE [Customers] ADD FOREIGN KEY ([StateId]) REFERENCES [States] ([Id])
GO

ALTER TABLE [Customers] ADD FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id])
GO

ALTER TABLE [Customers] ADD FOREIGN KEY ([SellerId]) REFERENCES [Sellers] ([Id])
GO