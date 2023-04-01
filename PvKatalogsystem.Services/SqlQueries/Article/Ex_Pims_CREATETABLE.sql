USE [ExterneArtikeldaten]
GO
/****** Object:  Table [dbo].[Pims_VerwandteArtikel]    Script Date: 10/19/2012 16:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pims_VerwandteArtikel](
	[ArtikelId] [int] NULL,
	[UnterartikelId] [int] NULL,
	[Typ] [char](1) NULL,
	[SameKTypeOnly] [bit] NULL,
	[Amount] [decimal](19, 5) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pims_ArticlesId_PassengerCarsId]    Script Date: 10/19/2012 16:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pims_ArticlesId_PassengerCarsId](
	[ArticlesId] [int] NOT NULL,
	[PassengerCarsId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pims_ArticlesId_EnginesId]    Script Date: 10/19/2012 16:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pims_ArticlesId_EnginesId](
	[ArticlesId] [int] NOT NULL,
	[EnginesId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pims_ArticlesId_CommercialVehiclesId]    Script Date: 10/19/2012 16:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pims_ArticlesId_CommercialVehiclesId](
	[ArticlesId] [int] NOT NULL,
	[CommercialVehiclesId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pims_ArticlesId_AxlesId]    Script Date: 10/19/2012 16:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pims_ArticlesId_AxlesId](
	[ArticlesId] [int] NOT NULL,
	[AxlesId] [int] NOT NULL
) ON [PRIMARY]
GO