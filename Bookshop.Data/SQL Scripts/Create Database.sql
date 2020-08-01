/* MAKE SURE YOU CHANGE THE FILENAME PATHS */

USE [NameOfYourDatabase]
GO
/****** Object:  Database [BookShopAPI]    Script Date: 01/08/2020 12:04:59 ******/
CREATE DATABASE [BookShopAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookShopAPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BookShopAPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookShopAPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BookShopAPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BookShopAPI] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookShopAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookShopAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookShopAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookShopAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookShopAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookShopAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookShopAPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookShopAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookShopAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookShopAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookShopAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookShopAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookShopAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookShopAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookShopAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookShopAPI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookShopAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookShopAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookShopAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookShopAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookShopAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookShopAPI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookShopAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookShopAPI] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookShopAPI] SET  MULTI_USER 
GO
ALTER DATABASE [BookShopAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookShopAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookShopAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookShopAPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookShopAPI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookShopAPI] SET QUERY_STORE = OFF
GO
USE [BookShopAPI]
GO
/****** Object:  User [APIUser]    Script Date: 01/08/2020 12:04:59 ******/
CREATE USER [APIUser] FOR LOGIN [APIUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [APIUser]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Subtitle] [varchar](255) NULL,
	[PublishYear] [int] NULL,
	[Price] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthor](
	[BookAuthorID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookAuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookEvent]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookEvent](
	[BookEventID] [int] IDENTITY(1,1) NOT NULL,
	[BookEventName] [nvarchar](255) NOT NULL,
	[BookEventDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.BookEvent] PRIMARY KEY CLUSTERED 
(
	[BookEventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookGenre]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookGenre](
	[BookGenreID] [int] IDENTITY(1,1) NOT NULL,
	[GenreID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookGenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NOT NULL,
	[Address2] [varchar](255) NULL,
	[TownCityID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Branch] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchSoldStock]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchSoldStock](
	[BranchSoldStockID] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
	[StockSold] [int] NOT NULL,
	[StockTotalPrice] [decimal](18, 2) NULL,
	[SoldDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.BranchSoldStock] PRIMARY KEY CLUSTERED 
(
	[BranchSoldStockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchStock]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchStock](
	[BranchStockID] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
	[StockAmount] [int] NOT NULL,
 CONSTRAINT [PK_dbo.BranchStock] PRIMARY KEY CLUSTERED 
(
	[BranchStockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NOT NULL,
	[Address2] [varchar](255) NULL,
	[TownCityID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
	[EmailAddress] [varchar](255) NOT NULL,
	[CustomerAccountNumber] [varchar](255) NOT NULL,
	[GiftCardNumber] [int] NULL,
 CONSTRAINT [PK_dbo.Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gift]    Script Date: 01/08/2020 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gift](
	[GiftID] [int] IDENTITY(1,1) NOT NULL,
	[GiftName] [nvarchar](255) NOT NULL,
	[GiftPrice] [decimal](18, 0) NULL,
 CONSTRAINT [PK_dbo.Gift] PRIMARY KEY CLUSTERED 
(
	[GiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (1, N'Stephen', N'King')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (2, N'Harper', N'Lee')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (3, N'Markus', N'Zusak')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (4, N'George', N'Orwell')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (5, N'John', N'Green')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (6, N'Chuck', N'Wendig')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (7, N'Andrew', N'Lincoln Davies')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (8, N'Jim', N'Butcher')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (9, N'Joe', N'Haldeman')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (10, N'Muriel', N'Spark')
GO
INSERT [dbo].[Author] ([AuthorID], [Firstname], [LastName]) VALUES (11, N'Michael', N'Crichton')
GO
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (1, N'Misery', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (2, N'Pet Semetary', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (3, N'IT', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (4, N'Salems''Lot', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (5, N'To Kill A Mockingbird', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (6, N'The Book Thief', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (7, N'Animal Farm', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (8, N'The Fault In Our Stars', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (9, N'Blackbirds', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (10, N'The Loney', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (11, N'Devil''s Day', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (12, N'Blue Blazes', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (13, N'Stormfront', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (14, N'The Forever War', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (15, N'The Prime of Miss Jean Brodie', NULL, NULL, CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Book] ([BookID], [Title], [Subtitle], [PublishYear], [Price]) VALUES (18, N'Pirates Latitudes', N'', 2001, CAST(12.99 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[BookAuthor] ON 
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (2, 2, 1)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (3, 3, 1)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (4, 4, 1)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (5, 5, 2)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (6, 6, 3)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (7, 7, 4)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (8, 8, 5)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (9, 9, 6)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (10, 10, 7)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (11, 11, 7)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (12, 12, 6)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (13, 13, 8)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (14, 14, 9)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (15, 15, 10)
GO
INSERT [dbo].[BookAuthor] ([BookAuthorID], [BookID], [AuthorID]) VALUES (18, 18, 11)
GO
SET IDENTITY_INSERT [dbo].[BookAuthor] OFF
GO
SET IDENTITY_INSERT [dbo].[BookGenre] ON 
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (2, 4, 1)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (3, 1, 2)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (4, 4, 2)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (5, 1, 3)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (6, 1, 4)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (7, 7, 5)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (8, 9, 5)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (9, 10, 5)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (10, 7, 6)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (11, 11, 6)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (12, 7, 7)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (13, 5, 7)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (14, 7, 8)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (15, 12, 8)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (16, 7, 9)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (17, 12, 9)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (18, 1, 9)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (19, 7, 10)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (20, 1, 10)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (21, 13, 10)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (22, 7, 11)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (23, 1, 11)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (24, 7, 12)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (25, 1, 12)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (26, 7, 13)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (27, 1, 13)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (28, 5, 13)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (29, 7, 14)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (30, 2, 14)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (31, 7, 15)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (32, 14, 18)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (33, 4, 18)
GO
INSERT [dbo].[BookGenre] ([BookGenreID], [GenreID], [BookID]) VALUES (34, 15, 18)
GO
SET IDENTITY_INSERT [dbo].[BookGenre] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (1, N'horror')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (2, N'sci-fi')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (3, N'western')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (4, N'Crime')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (5, N'fantasy')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (6, N'nonfiction')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (7, N'fiction')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (8, N'business')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (9, N'drama')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (10, N'racism')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (11, N'war')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (12, N'young adult')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (13, N'mystery')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (14, N'Adventure')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (15, N'Pirates')
GO
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ((0)) FOR [GiftCardNumber]
GO
USE [master]
GO
ALTER DATABASE [BookShopAPI] SET  READ_WRITE 
GO
