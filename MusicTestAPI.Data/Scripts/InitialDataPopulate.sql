-- *** SqlDbx Personal Edition ***
-- !!! Not licensed for commercial use beyound 90 days evaluation period !!!
-- For version limitations please check http://www.sqldbx.com/personal_edition.htm
-- Number of queries executed: 0, number of rows retrieved: 0
DELETE  Users
INSERT INTO dbo.Users (Email, Password, FirstName, LastName)
VALUES ('systadmin@algo.com', 'abc', 'admin', 'admin')

DELETE  Authors
INSERT INTO dbo.Authors (Name, LastName)
VALUES ('Lars', 'Ulrich')

INSERT INTO dbo.Authors (Name, LastName)
VALUES ('Till', 'Lindemann')

DELETE Song

INSERT INTO dbo.Song (Name, Duration, CreatorId, IsPublic)
VALUES ('One', 5,(SELECT Id FROM USERS WHERE Email='systadmin@algo.com'), 1)

INSERT INTO dbo.Song (Name, Duration, CreatorId, IsPublic)
VALUES ('The Unforgiven', 2,(SELECT Id FROM USERS WHERE Email='systadmin@algo.com'), 1)


INSERT INTO dbo.Song (Name, Duration, CreatorId, IsPublic)
VALUES ('Sad But True', 2,(SELECT Id FROM USERS WHERE Email='systadmin@algo.com'), 1)


INSERT INTO dbo.Song (Name, Duration, CreatorId, IsPublic)
VALUES ('Nothing Else Matter', 2,(SELECT Id FROM USERS WHERE Email='systadmin@algo.com'), 0)

INSERT INTO dbo.Song (Name, Duration, CreatorId, IsPublic)
VALUES ('The God That Failed', 2,(SELECT Id FROM USERS WHERE Email='systadmin@algo.com'), 0)


DELETE albums	
INSERT INTO dbo.Albums (Year, Genre, CreatorId, IsPublic, Name, Band)
VALUES (2000, 'Metal', (SELECT Id FROM USERS WHERE Email='systadmin@algo.com'), 1, 'Greatest Hits', 'Metalica')


INSERT INTO dbo.Albums (Year, Genre, CreatorId, IsPublic, Name, Band)
VALUES (2001, 'Metal', (SELECT Id FROM USERS WHERE Email='systadmin@algo.com'), 0, 'Fuel', 'Metalica')

--updates

UPDATE dbo.Song
SET AlbumId = (SELECT Id FROM albums WHERE Name LIKE '%Greatest Hits%')
WHERE IsPublic= 1

UPDATE dbo.Song
SET AlbumId = (SELECT Id FROM albums WHERE Name LIKE '%Fuel%')
WHERE IsPublic= 0


--likes para album

INSERT INTO dbo.Likes (UserId, AlbumId, SongId)
VALUES ((SELECT Id FROM USERS WHERE Email='systadmin@algo.com'), (SELECT Id FROM albums WHERE Name LIKE '%Greatest Hits%'), null)

INSERT INTO dbo.Likes (UserId, AlbumId, SongId)
VALUES ((SELECT Id FROM USERS WHERE Email='systadmin@algo.com'), (SELECT Id FROM albums WHERE Name LIKE '%Fuel%'), null)

--add author to album

update authors SET albumId=(SELECT Id FROM albums WHERE Name LIKE '%Greatest Hits%') WHERE name like '%Lars%'
update authors SET albumId=(SELECT Id FROM albums WHERE Name LIKE '%Fuel%') WHERE name like '%Till%'
