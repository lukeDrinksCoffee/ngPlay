----------------------------------------------------------------------
--
-- Create Database
--
----------------------------------------------------------------------


USE [master]
GO

/****** Object:  Database [ngPlay]    Script Date: 11/04/2014 5:48:41 PM ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'ngPlay')
BEGIN
CREATE DATABASE [ngPlay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ngPlay', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ngPlay.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ngPlay_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ngPlay_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO

ALTER DATABASE [ngPlay] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ngPlay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ngPlay] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ngPlay] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ngPlay] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ngPlay] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ngPlay] SET ARITHABORT OFF 
GO

ALTER DATABASE [ngPlay] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ngPlay] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [ngPlay] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ngPlay] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ngPlay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ngPlay] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ngPlay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ngPlay] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ngPlay] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ngPlay] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ngPlay] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ngPlay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ngPlay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ngPlay] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ngPlay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ngPlay] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ngPlay] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ngPlay] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ngPlay] SET RECOVERY FULL 
GO

ALTER DATABASE [ngPlay] SET  MULTI_USER 
GO

ALTER DATABASE [ngPlay] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ngPlay] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ngPlay] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ngPlay] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [ngPlay] SET  READ_WRITE 
GO


----------------------------------------------------------------------
--
-- Create Tables
--
----------------------------------------------------------------------

USE [ngPlay]
GO

/****** Object:  Table [dbo].[AppLog]    Script Date: 11/04/2014 5:54:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AppLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AppLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Detail] [nvarchar](200) NOT NULL
) ON [PRIMARY]
END
GO



CREATE TABLE [dbo].[User] (
    [UserID]                                  INT            IDENTITY (1000, 1) NOT NULL,
    [UserName]                                NVARCHAR (50)  NOT NULL,
    [DisplayName]                             NVARCHAR (50)  NULL,
    [Email]                                   NVARCHAR (100) NOT NULL,
    [EmailHash]                               AS             (lower(CONVERT([varchar](32),hashbytes('MD5',CONVERT([varchar],lower(rtrim(ltrim([Email]))),(0))),(2)))) PERSISTED,
    [PasswordHash]                            VARBINARY (24) NULL,
    [PasswordSalt]                            VARBINARY (24) NULL,
    [PasswordQuestion]                        NVARCHAR (256) NULL,
    [PasswordAnswer]                          NVARCHAR (128) NULL,
    [IsApproved]                              BIT            NOT NULL,
    [IsLockedOut]                             BIT            NOT NULL,
    [CreatedDate]                             DATETIME       NOT NULL,
    [LastLoginDate]                           DATETIME       NOT NULL,
    [LastActivityDate]                        DATETIME       NOT NULL,
    [LastPasswordChangedDate]                 DATETIME       NULL,
    [LastLockoutDate]                         DATETIME       NULL,
    [FailedPasswordAttemptCount]              INT            NOT NULL,
    [FailedPasswordAttemptWindowStart]        DATETIME       NULL,
    [FailedPasswordAnswerAttemptCount]        INT            NOT NULL,
    [FailedPasswordAnswerAttemptWindowsStart] DATETIME       NULL,
    [Comment]                                 NVARCHAR (256) NULL
);
