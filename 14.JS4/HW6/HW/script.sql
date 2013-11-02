USE [master]
GO
/****** Object:  Database [ForumDb]    Script Date: 1.9.2013 г. 19:41:47 ч. ******/
CREATE DATABASE [ForumDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ForumDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ForumDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ForumDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ForumDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ForumDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ForumDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ForumDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ForumDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ForumDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ForumDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ForumDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ForumDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ForumDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ForumDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ForumDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ForumDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ForumDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ForumDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ForumDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ForumDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ForumDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ForumDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ForumDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ForumDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ForumDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ForumDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ForumDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ForumDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ForumDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ForumDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ForumDb] SET  MULTI_USER 
GO
ALTER DATABASE [ForumDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ForumDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ForumDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ForumDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ForumDb]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 1.9.2013 г. 19:41:48 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[Content] [text] NOT NULL,
	[CommentDate] [date] NOT NULL,
	[PostId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts]    Script Date: 1.9.2013 г. 19:41:48 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[Content] [text] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[PostDate] [date] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostsTags]    Script Date: 1.9.2013 г. 19:41:48 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostsTags](
	[PostId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_PostsTags] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 1.9.2013 г. 19:41:48 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 1.9.2013 г. 19:41:48 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[AuthCode] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[SessionKey] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (1, N'A comment to the third post', CAST(0xFB350B00 AS Date), 3, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (2, N'A second comment to the third post', CAST(0xE5350B00 AS Date), 3, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (3, N'Test', CAST(0x00000000 AS Date), 3, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (4, N'New Test Comment', CAST(0x00000000 AS Date), 3, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (5, N'New new test comment', CAST(0x00000000 AS Date), 3, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (6, N'New comment', CAST(0x00000000 AS Date), 1, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (7, N'Some comment', CAST(0x00000000 AS Date), 2, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (8, N'A comment', CAST(0x00000000 AS Date), 2, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (9, N'A comment', CAST(0x00000000 AS Date), 2, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (10, N'A comment', CAST(0x00000000 AS Date), 2, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (11, N'A comment', CAST(0x00000000 AS Date), 2, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (12, N'A comment', CAST(0x00000000 AS Date), 2, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (13, N'A comment', CAST(0x00000000 AS Date), 2, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (14, N'A new comment', CAST(0x00000000 AS Date), 2, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (15, N'Test', CAST(0x00000000 AS Date), 2, 1)
INSERT [dbo].[Comments] ([CommentId], [Content], [CommentDate], [PostId], [UserId]) VALUES (16, N'Test comment', CAST(0x00000000 AS Date), 2, 1)
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([PostId], [Content], [Title], [PostDate], [UserId]) VALUES (1, N'Some kind of text', N'First Post', CAST(0x86370B00 AS Date), 1)
INSERT [dbo].[Posts] ([PostId], [Content], [Title], [PostDate], [UserId]) VALUES (2, N'Another text', N'Second Post', CAST(0x82370B00 AS Date), 1)
INSERT [dbo].[Posts] ([PostId], [Content], [Title], [PostDate], [UserId]) VALUES (3, N'The text of the third post', N'Third Post', CAST(0x86370B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[Posts] OFF
INSERT [dbo].[PostsTags] ([PostId], [TagId]) VALUES (3, 1)
INSERT [dbo].[PostsTags] ([PostId], [TagId]) VALUES (3, 2)
INSERT [dbo].[PostsTags] ([PostId], [TagId]) VALUES (3, 3)
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (1, N'third')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (2, N'post')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (3, N'3')
SET IDENTITY_INSERT [dbo].[Tags] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Username], [AuthCode], [DisplayName], [SessionKey]) VALUES (1, N'user10', N'e90976da83b7342dd709123332a69d0baeff016b', N'User10', N'1WQhscujhkjjNNQIJGRrIkwBYDULvBdrLvElXQVqAArfemKrJf')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([PostId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users]
GO
ALTER TABLE [dbo].[PostsTags]  WITH CHECK ADD  CONSTRAINT [FK_PostsTags_Posts] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([PostId])
GO
ALTER TABLE [dbo].[PostsTags] CHECK CONSTRAINT [FK_PostsTags_Posts]
GO
ALTER TABLE [dbo].[PostsTags]  WITH CHECK ADD  CONSTRAINT [FK_PostsTags_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[PostsTags] CHECK CONSTRAINT [FK_PostsTags_Tags]
GO
USE [master]
GO
ALTER DATABASE [ForumDb] SET  READ_WRITE 
GO
