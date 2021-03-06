USE [AlbumDB]
GO
/****** Object:  Table [dbo].[tblArtist]    Script Date: 18-Apr-18 9:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArtist](
	[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	[Performer] [varchar](70) NOT NULL,
 CONSTRAINT [PK_tblArtist] PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSongCollection]    Script Date: 18-Apr-18 9:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSongCollection](
	[SongID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](70) NOT NULL,
	[ArtistID] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_tblSongCollection] PRIMARY KEY CLUSTERED 
(
	[SongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserPreferences]    Script Date: 18-Apr-18 9:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserPreferences](
	[UserID] [varchar](10) NOT NULL,
	[Performer] [int] NULL,
	[Title] [int] NULL,
 CONSTRAINT [PK_tblUserPreferences] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblSongCollection]  WITH CHECK ADD  CONSTRAINT [FK_tblSongCollection_tblArtist] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[tblArtist] ([ArtistID])
GO
ALTER TABLE [dbo].[tblSongCollection] CHECK CONSTRAINT [FK_tblSongCollection_tblArtist]
GO
