IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Statuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Statuses]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Categories]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 5/20/2019 12:50:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Statuses]') AND type in (N'U'))
DROP TABLE [dbo].[Statuses]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/20/2019 12:50:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/20/2019 12:50:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Database [uStore]    Script Date: 5/20/2019 12:50:14 PM ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'uStore')
DROP DATABASE [uStore]
GO
/****** Object:  Database [uStore]    Script Date: 5/20/2019 12:50:14 PM ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'uStore')
BEGIN
CREATE DATABASE [uStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'uStore', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\uStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'uStore_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\uStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
ALTER DATABASE [uStore] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [uStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [uStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [uStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [uStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [uStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [uStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [uStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [uStore] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [uStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [uStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [uStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [uStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [uStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [uStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [uStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [uStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [uStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [uStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [uStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [uStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [uStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [uStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [uStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [uStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [uStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [uStore] SET  MULTI_USER 
GO
ALTER DATABASE [uStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [uStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [uStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [uStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/20/2019 12:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](100) NOT NULL,
	[Notes] [varchar](500) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/20/2019 12:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](max) NULL,
	[Price] [money] NULL,
	[UnitsInStock] [smallint] NULL,
	[ProductImage] [varchar](75) NULL,
	[StatusId] [int] NOT NULL,
	[CategoryID] [int] NULL,
	[Notes] [varchar](500) NULL,
	[ReferenceURL] [varchar](1024) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 5/20/2019 12:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Statuses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Statuses](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](30) NOT NULL,
	[StatusOrder] [tinyint] NOT NULL,
	[Notes] [varchar](100) NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (1, N'Athletic Shoes', N'Turtle Power')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (2, N'Casual Shoes', NULL)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (3, N'Hiking Shoes', NULL)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (4, N'Sandals', N'adding in some notes')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusId], [CategoryID], [Notes], [ReferenceURL]) VALUES (1, N'Nike', N'Basketball Shoes', 79.9900, 30, N'Noimage.jpg', 4, 1, NULL, N'http://www.nike.com')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusId], [CategoryID], [Notes], [ReferenceURL]) VALUES (2, N'Toms', N'Casual Shoes', 49.9900, 20, N'Noimage.jpg', 4, 2, NULL, N'http://toms.com')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusId], [CategoryID], [Notes], [ReferenceURL]) VALUES (5, N'Merrell', N'Hiking Shoe', 119.0000, 30, N'NOimage.jpg', 4, 3, NULL, N'http://merrell.com')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusId], [CategoryID], [Notes], [ReferenceURL]) VALUES (6, N'Teva', N'Sandals', 19.9900, 0, N'noImage.jpg', 5, 4, NULL, N'http://teva.com')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusId], [CategoryID], [Notes], [ReferenceURL]) VALUES (7, N'Nike', N'Running Shoes', 89.9900, 20, N'noimage.jpg', 4, 1, NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusId], [CategoryID], [Notes], [ReferenceURL]) VALUES (8, N'Teenage Mutant Ninja Turtleszz', N'little green sewer ninjas', 24.7500, 20, N'na', 4, 1, N'Turtle Power', N'www.turtles.com')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusId], [CategoryID], [Notes], [ReferenceURL]) VALUES (9, N'Spaceballs', N'Movie', 9.9900, 19, N'na', 4, 1, N'insert movie notes here', N'www.movie.com')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusId], [CategoryID], [Notes], [ReferenceURL]) VALUES (11, N'Alolan Vulpix', N'white pokemon', 5.0000, 1000, N'noimage.jpg', 4, 1, N'Paizly like boogers in her salad.', N'www.paizlysboogerstastelikeranch.com')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([StatusID], [StatusName], [StatusOrder], [Notes]) VALUES (4, N'InStock', 1, N'Item available')
INSERT [dbo].[Statuses] ([StatusID], [StatusName], [StatusOrder], [Notes]) VALUES (5, N'OutOfStock', 2, N'Item unavailable')
INSERT [dbo].[Statuses] ([StatusID], [StatusName], [StatusOrder], [Notes]) VALUES (6, N'Backordered', 3, N'Item on back order')
INSERT [dbo].[Statuses] ([StatusID], [StatusName], [StatusOrder], [Notes]) VALUES (7, N'Discountinued', 4, N'Item discontinued')
SET IDENTITY_INSERT [dbo].[Statuses] OFF
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Statuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Statuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([StatusID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Statuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Statuses]
GO
ALTER DATABASE [uStore] SET  READ_WRITE 
GO
