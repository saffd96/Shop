
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/14/2021 23:29:24
-- Generated from EDMX file: D:\Проекты C#\Shop\Shop\Shop\ShopDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ShopDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OrderBuyer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderBuyer];
GO
IF OBJECT_ID(N'[dbo].[FK_ShoppingCartBuyer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShoppingCarts] DROP CONSTRAINT [FK_ShoppingCartBuyer];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderItemProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItems] DROP CONSTRAINT [FK_OrderItemProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderItemOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItems] DROP CONSTRAINT [FK_OrderItemOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_ShoppingCartItemShoppingCart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShoppingCartItems] DROP CONSTRAINT [FK_ShoppingCartItemShoppingCart];
GO
IF OBJECT_ID(N'[dbo].[FK_ShoppingCartItemProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShoppingCartItems] DROP CONSTRAINT [FK_ShoppingCartItemProduct];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Shops]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shops];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[OrderItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderItems];
GO
IF OBJECT_ID(N'[dbo].[ShoppingCarts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShoppingCarts];
GO
IF OBJECT_ID(N'[dbo].[Managers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Managers];
GO
IF OBJECT_ID(N'[dbo].[Buyers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Buyers];
GO
IF OBJECT_ID(N'[dbo].[ShoppingCartItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShoppingCartItems];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Shops'
CREATE TABLE [dbo].[Shops] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(32)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Amount] int  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Shop_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] uniqueidentifier  NOT NULL,
    [BuyerId] uniqueidentifier  NOT NULL,
    [DateOfOrder] datetime  NOT NULL,
    [Buyer_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'OrderItems'
CREATE TABLE [dbo].[OrderItems] (
    [Id] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL,
    [Count] int  NOT NULL,
    [OrderId] uniqueidentifier  NOT NULL,
    [Product_Id] uniqueidentifier  NOT NULL,
    [Order_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ShoppingCarts'
CREATE TABLE [dbo].[ShoppingCarts] (
    [Id] uniqueidentifier  NOT NULL,
    [Capasity] int  NOT NULL,
    [Buyer_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Managers'
CREATE TABLE [dbo].[Managers] (
    [Id] uniqueidentifier  NOT NULL,
    [Role] nvarchar(16)  NOT NULL,
    [Login] nvarchar(16)  NOT NULL,
    [PasswordHash] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Buyers'
CREATE TABLE [dbo].[Buyers] (
    [Id] uniqueidentifier  NOT NULL,
    [Role] nvarchar(16)  NOT NULL,
    [Login] nvarchar(16)  NOT NULL,
    [PasswordHash] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [DateOfRegister] datetime  NOT NULL,
    [ShoppingCartId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ShoppingCartItems'
CREATE TABLE [dbo].[ShoppingCartItems] (
    [Id] uniqueidentifier  NOT NULL,
    [ShoppingCartId] uniqueidentifier  NOT NULL,
    [ProductID] uniqueidentifier  NOT NULL,
    [Count] int  NOT NULL,
    [ShoppingCart_Id] uniqueidentifier  NOT NULL,
    [Product_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Shops'
ALTER TABLE [dbo].[Shops]
ADD CONSTRAINT [PK_Shops]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [PK_OrderItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShoppingCarts'
ALTER TABLE [dbo].[ShoppingCarts]
ADD CONSTRAINT [PK_ShoppingCarts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Managers'
ALTER TABLE [dbo].[Managers]
ADD CONSTRAINT [PK_Managers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Buyers'
ALTER TABLE [dbo].[Buyers]
ADD CONSTRAINT [PK_Buyers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShoppingCartItems'
ALTER TABLE [dbo].[ShoppingCartItems]
ADD CONSTRAINT [PK_ShoppingCartItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Buyer_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderBuyer]
    FOREIGN KEY ([Buyer_Id])
    REFERENCES [dbo].[Buyers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderBuyer'
CREATE INDEX [IX_FK_OrderBuyer]
ON [dbo].[Orders]
    ([Buyer_Id]);
GO

-- Creating foreign key on [Buyer_Id] in table 'ShoppingCarts'
ALTER TABLE [dbo].[ShoppingCarts]
ADD CONSTRAINT [FK_ShoppingCartBuyer]
    FOREIGN KEY ([Buyer_Id])
    REFERENCES [dbo].[Buyers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShoppingCartBuyer'
CREATE INDEX [IX_FK_ShoppingCartBuyer]
ON [dbo].[ShoppingCarts]
    ([Buyer_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_OrderItemProduct]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItemProduct'
CREATE INDEX [IX_FK_OrderItemProduct]
ON [dbo].[OrderItems]
    ([Product_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_OrderItemOrder]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItemOrder'
CREATE INDEX [IX_FK_OrderItemOrder]
ON [dbo].[OrderItems]
    ([Order_Id]);
GO

-- Creating foreign key on [ShoppingCart_Id] in table 'ShoppingCartItems'
ALTER TABLE [dbo].[ShoppingCartItems]
ADD CONSTRAINT [FK_ShoppingCartItemShoppingCart]
    FOREIGN KEY ([ShoppingCart_Id])
    REFERENCES [dbo].[ShoppingCarts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShoppingCartItemShoppingCart'
CREATE INDEX [IX_FK_ShoppingCartItemShoppingCart]
ON [dbo].[ShoppingCartItems]
    ([ShoppingCart_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'ShoppingCartItems'
ALTER TABLE [dbo].[ShoppingCartItems]
ADD CONSTRAINT [FK_ShoppingCartItemProduct]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShoppingCartItemProduct'
CREATE INDEX [IX_FK_ShoppingCartItemProduct]
ON [dbo].[ShoppingCartItems]
    ([Product_Id]);
GO

-- Creating foreign key on [Shop_Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ShopProduct]
    FOREIGN KEY ([Shop_Id])
    REFERENCES [dbo].[Shops]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopProduct'
CREATE INDEX [IX_FK_ShopProduct]
ON [dbo].[Products]
    ([Shop_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------