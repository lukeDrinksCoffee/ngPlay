----------------------------------------------------------------------
--
-- Create Database
--
----------------------------------------------------------------------

USE [master]

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'ngPlay')
BEGIN
	DROP DATABASE [ngPlay]
END
GO

CREATE DATABASE [ngPlay]
GO

USE [ngPlay]

GO
/****** Object:  Table [dbo].[AppLog]    Script Date: 27/04/2014 8:26:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AppLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AppLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Detail] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_AppLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Note]    Script Date: 27/04/2014 8:26:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Note]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Note](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/04/2014 8:26:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1000,1) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__User__EmailConfi__108B795B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [EmailConfirmed]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__User__PhoneNumbe__117F9D94]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [PhoneNumberConfirmed]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__User__TwoFactorE__1273C1CD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [TwoFactorEnabled]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__User__LockoutEna__1367E606]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [LockoutEnabled]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__User__AccessFail__145C0A3F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [AccessFailedCount]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Note_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Note]'))
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Note_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Note]'))
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_User]
GO
