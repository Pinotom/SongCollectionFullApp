
USE AlbumDB;
GO

CREATE PROCEDURE spGetAllArtists
AS
SELECT ArtistID, Performer
FROM tblArtist
GO

CREATE PROCEDURE spGetAllSongs
AS
SELECT SongID, Title, ArtistID, Price
FROM tblSongCollection
GO

CREATE PROCEDURE spGetSong @SongID int
AS
SELECT Title, ArtistID, Price
FROM tblSongCollection 
WHERE SongID = @SongID
GO

CREATE PROCEDURE spAddSong @ArtistID int, @Title Varchar(70), @Price int, @NewID int OUTPUT
AS
INSERT INTO tblSongCollection (Title, ArtistID, Price)
VALUES (@Title, @ArtistID, @Price)
SET @NewID = SCOPE_IDENTITY()
GO

CREATE PROCEDURE spDeleteSong @SongID int
AS
DELETE FROM tblSongCollection
WHERE SongID = @SongID
GO

CREATE PROCEDURE spUpdateSong @SongID int, @Title varchar(70), @ArtistID int, @Price int
AS
UPDATE tblSongCollection
SET Title = @Title, ArtistID = @ArtistID, Price = @Price
WHERE SongID = @SongID
GO

CREATE PROCEDURE spSearchByPerformer @ArtistID int, @Zoekterm varchar(200)
AS
SELECT SongID, Title, ArtistID, Price
FROM tblSongCollection 
WHERE ArtistID = @ArtistID AND Title LIKE '%' + @Zoekterm + '%'
GO

CREATE PROCEDURE spOverview
AS
SELECT A.Performer, S.Title, S.Price
FROM tblSongCollection S
JOIN tblArtist A
ON A.ArtistID = S.ArtistID
GO

CREATE PROCEDURE spGetPreference @UserID varchar(10)
AS
SELECT UserID, Performer, Title
FROM tblPreferences
WHERE UserID = @UserID
GO

CREATE PROCEDURE spSavePreference @UserID varchar(10), @Performer int, @Title int
AS
UPDATE tblPreferences
SET Performer = @Performer, Title = @Title
WHERE UserID = @UserID
GO

CREATE PROCEDURE spGetUsers
AS
SELECT UserID, Performer, Title
FROM tblPreferences
GO
