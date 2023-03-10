USE [HotelAtr]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 8/26/2018 2:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeId] [int] NOT NULL,
	[Square] [decimal](18, 0) NULL,
	[MaxPersons] [int] NULL,
	[IsFreeWifi] [bit] NOT NULL,
	[IsPrivateBalcony] [bit] NOT NULL,
	[IsFullAC] [bit] NOT NULL,
	[Floor] [int] NOT NULL,
	[HasTV] [bit] NOT NULL,
	[IsBeachView] [bit] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 8/26/2018 2:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[RoomTypeDescription] [nvarchar](1000) NULL,
	[Price] [int] NULL,
	[Imagepath] [nvarchar](1000) NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 8/26/2018 2:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](50) NOT NULL,
	[ServiceDescription] [nvarchar](500) NOT NULL,
	[ServiceIconPath] [nvarchar](500) NOT NULL,
	[ServiceImagePath] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SliderAreas]    Script Date: 8/26/2018 2:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SliderAreas](
	[SliderAreaId] [int] IDENTITY(1,1) NOT NULL,
	[Header] [nvarchar](100) NULL,
	[Description] [nvarchar](250) NULL,
	[Url] [nvarchar](500) NULL,
	[PathImg] [nvarchar](500) NULL,
 CONSTRAINT [PK_SliderAreas] PRIMARY KEY CLUSTERED 
(
	[SliderAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomType] ([RoomTypeId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
