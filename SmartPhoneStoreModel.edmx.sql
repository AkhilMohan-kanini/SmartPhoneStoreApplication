
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/12/2021 13:01:28
-- Generated from EDMX file: E:\MVC\SmartPhoneStoreApplication\SmartPhoneStoreModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SmartPhoneStoreDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Orders__Customer__182C9B23]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK__Orders__Customer__182C9B23];
GO
IF OBJECT_ID(N'[dbo].[FK__Orders__ProductI__1920BF5C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK__Orders__ProductI__1920BF5C];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdminLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminLogin];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdminLogins'
CREATE TABLE [dbo].[AdminLogins] (
    [AdminID] varchar(10)  NOT NULL,
    [AdminPassword] varchar(20)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [CustomerPassword] varchar(20)  NULL,
    [FirstName] varchar(30)  NULL,
    [LastName] varchar(30)  NULL,
    [MobileNumber] int  NULL,
    [EmailID] varchar(50)  NULL,
    [AddressLine1] varchar(80)  NULL,
    [AddressLine2] varchar(80)  NULL,
    [PinCode] int  NULL,
    [District] varchar(50)  NULL,
    [CustomerState] varchar(20)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [CustomerID] int  NULL,
    [ProductID] int  NULL,
    [Quantity] int  NULL,
    [OrderStatus] varchar(20)  NULL,
    [OrderedDate] datetime  NULL,
    [ExpectedDate] datetime  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [BrandName] varchar(20)  NULL,
    [ModelName] varchar(30)  NULL,
    [RAM] varchar(10)  NULL,
    [ROM] varchar(20)  NULL,
    [Display] varchar(50)  NULL,
    [Battery] varchar(20)  NULL,
    [PrimaryCamera] varchar(40)  NULL,
    [SecondaryCamera] varchar(40)  NULL,
    [Processor] varchar(50)  NULL,
    [Color] varchar(30)  NULL,
    [SimType] varchar(30)  NULL,
    [OsName] varchar(40)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AdminID] in table 'AdminLogins'
ALTER TABLE [dbo].[AdminLogins]
ADD CONSTRAINT [PK_AdminLogins]
    PRIMARY KEY CLUSTERED ([AdminID] ASC);
GO

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Orders__Customer__182C9B23]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Orders__Customer__182C9B23'
CREATE INDEX [IX_FK__Orders__Customer__182C9B23]
ON [dbo].[Orders]
    ([CustomerID]);
GO

-- Creating foreign key on [ProductID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Orders__ProductI__1920BF5C]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Orders__ProductI__1920BF5C'
CREATE INDEX [IX_FK__Orders__ProductI__1920BF5C]
ON [dbo].[Orders]
    ([ProductID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------