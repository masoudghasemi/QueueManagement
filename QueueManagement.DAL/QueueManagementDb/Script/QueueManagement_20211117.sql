/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [QueueManagement]    Script Date: 11/17/2021 5:48:26 PM ******/
CREATE DATABASE [QueueManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QueueManagement', FILENAME = N'D:\M_Ghasemi\Databases\QueueManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QueueManagement_log', FILENAME = N'D:\M_Ghasemi\Databases\QueueManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QueueManagement] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QueueManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QueueManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QueueManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QueueManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QueueManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QueueManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [QueueManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QueueManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QueueManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QueueManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QueueManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QueueManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QueueManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QueueManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QueueManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QueueManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QueueManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QueueManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QueueManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QueueManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QueueManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QueueManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QueueManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QueueManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [QueueManagement] SET  MULTI_USER 
GO
ALTER DATABASE [QueueManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QueueManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QueueManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QueueManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QueueManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QueueManagement', N'ON'
GO
ALTER DATABASE [QueueManagement] SET QUERY_STORE = OFF
GO
USE [QueueManagement]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [QueueManagement]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 11/17/2021 5:48:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Identity] [nvarchar](400) NOT NULL,
	[QueueId] [int] NOT NULL,
	[ProducerId] [int] NOT NULL,
	[BodyJson] [nvarchar](max) NOT NULL,
	[BodyBinary] [varbinary](max) NOT NULL,
	[InsertedAt] [datetime] NOT NULL,
	[InsertedBy] [char](20) NULL,
	[RelatedMessageId] [bigint] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer]    Script Date: 11/17/2021 5:48:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameFa] [nvarchar](50) NULL,
	[NameEN] [nvarchar](50) NULL,
 CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Queue]    Script Date: 11/17/2021 5:48:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Queue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameFa] [nvarchar](50) NULL,
	[NameEN] [nvarchar](50) NULL,
	[Description] [nvarchar](400) NULL,
 CONSTRAINT [PK_Queue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Producer] ON 

INSERT [dbo].[Producer] ([Id], [NameFa], [NameEN]) VALUES (1, N'دادگستری', N'Dadgostari')
INSERT [dbo].[Producer] ([Id], [NameFa], [NameEN]) VALUES (2, N'سرآمد', N'Saramad')
SET IDENTITY_INSERT [dbo].[Producer] OFF
SET IDENTITY_INSERT [dbo].[Queue] ON 

INSERT [dbo].[Queue] ([Id], [NameFa], [NameEN], [Description]) VALUES (1, N'صف دستور', N'Rule', NULL)
INSERT [dbo].[Queue] ([Id], [NameFa], [NameEN], [Description]) VALUES (2, N'صف پاسخ دستور', N'RuleResponse', NULL)
SET IDENTITY_INSERT [dbo].[Queue] OFF
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Message1] FOREIGN KEY([RelatedMessageId])
REFERENCES [dbo].[Message] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Message1]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Producer] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producer] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Producer]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Queue] FOREIGN KEY([QueueId])
REFERENCES [dbo].[Queue] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Queue]
GO
USE [master]
GO
ALTER DATABASE [QueueManagement] SET  READ_WRITE 
GO
