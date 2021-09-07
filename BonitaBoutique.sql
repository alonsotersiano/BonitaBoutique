  IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BonitaBoutique')
BEGIN
  CREATE DATABASE BonitaBoutique;
END;
GO

  IF EXISTS (SELECT * FROM sys.databases WHERE name = 'BonitaBoutique')
BEGIN
  USE BonitaBoutique;
  CREATE TABLE [dbo].[ItemTbl] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50)   NOT NULL,
    [Category] VARCHAR (50)   NOT NULL,
    [Type]     VARCHAR (50)   NOT NULL,
    [Price]    DECIMAL (8, 2) NOT NULL,
    [Quantity] INT            NOT NULL,
    [Barcode]  VARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
	CREATE TABLE [dbo].[CustomerTbl] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (50) NOT NULL,
    [Email] VARCHAR (50) NULL,
    [Phone] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
	CREATE TABLE [dbo].[BillTbl] (
    [BId]         INT            IDENTITY (1, 1) NOT NULL,
    [CustId]      INT            NOT NULL,
    [CustName]    VARCHAR (50)   NOT NULL,
    [ProdId]      INT            NOT NULL,
    [ProdName]    VARCHAR (50)   NOT NULL,
    [ProdBarcode] VARCHAR (50)   NOT NULL,
    [Quantity]    INT            NOT NULL,
    [Amount]      DECIMAL (6, 2) NOT NULL,
    [Date]        DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([BId] ASC)
);
END;
GO