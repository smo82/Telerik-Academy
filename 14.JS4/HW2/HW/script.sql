USE [master]
GO
/****** Object:  Database [StudentsDb]    Script Date: 24.8.2013 г. 20:23:40 ч. ******/
CREATE DATABASE [StudentsDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentsDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StudentsDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudentsDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StudentsDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudentsDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentsDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentsDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentsDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentsDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentsDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentsDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentsDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StudentsDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentsDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentsDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentsDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentsDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentsDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentsDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentsDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentsDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentsDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentsDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentsDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentsDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentsDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentsDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentsDb] SET  MULTI_USER 
GO
ALTER DATABASE [StudentsDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentsDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentsDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentsDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StudentsDb]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 24.8.2013 г. 20:23:40 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[MarkId] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Score] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_Marks] PRIMARY KEY CLUSTERED 
(
	[MarkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 24.8.2013 г. 20:23:40 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Grade] [int] NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Marks] ON 

INSERT [dbo].[Marks] ([MarkId], [Subject], [Score], [StudentId]) VALUES (1, N'JS', 6, 1)
INSERT [dbo].[Marks] ([MarkId], [Subject], [Score], [StudentId]) VALUES (2, N'CSS', 4, 1)
INSERT [dbo].[Marks] ([MarkId], [Subject], [Score], [StudentId]) VALUES (3, N'C#', 6, 2)
INSERT [dbo].[Marks] ([MarkId], [Subject], [Score], [StudentId]) VALUES (4, N'DataBases', 5, 2)
INSERT [dbo].[Marks] ([MarkId], [Subject], [Score], [StudentId]) VALUES (5, N'C#', 6, 3)
INSERT [dbo].[Marks] ([MarkId], [Subject], [Score], [StudentId]) VALUES (6, N'JS', 4, 4)
INSERT [dbo].[Marks] ([MarkId], [Subject], [Score], [StudentId]) VALUES (7, N'C#', 4, 4)
INSERT [dbo].[Marks] ([MarkId], [Subject], [Score], [StudentId]) VALUES (8, N'WebServices', 6, 5)
INSERT [dbo].[Marks] ([MarkId], [Subject], [Score], [StudentId]) VALUES (9, N'C#', 6, 5)
SET IDENTITY_INSERT [dbo].[Marks] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Grade], [Age]) VALUES (1, N'Doncho', N'Minkov', 1, 7)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Grade], [Age]) VALUES (2, N'Svetlin', N'Nakov', 2, 8)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Grade], [Age]) VALUES (3, N'Niki', N'Kostov', 3, 9)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Grade], [Age]) VALUES (4, N'Ivaylo', N'Kenov', 4, 10)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Grade], [Age]) VALUES (5, N'Joro', N'Georgiev', 5, 11)
SET IDENTITY_INSERT [dbo].[Students] OFF
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Students]
GO
USE [master]
GO
ALTER DATABASE [StudentsDb] SET  READ_WRITE 
GO
