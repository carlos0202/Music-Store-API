USE [MusicDB]
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Pop')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Artist] ON 

INSERT [dbo].[Artist] ([Id], [PublicName], [Country]) VALUES (1, N'Backstreet Boys', N'United States')
SET IDENTITY_INSERT [dbo].[Artist] OFF
GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([Id], [Name], [ReleaseDate], [CoverURL], [Price], [Description], [ArtistId], [CopyrightInfo], [GenreId]) VALUES (2, N'DNA', CAST(N'2019-01-25' AS Date), N'https://m.media-amazon.com/images/I/71w0ze2NduL.jpg', CAST(11.99 AS Decimal(12, 2)), N'There’s one question the Backstreet Boys can’t seem to escape: Do they still consider themselves a boy band? The five-piece, most of whom are now over 40 and married with children, have come to embrace the term. “At this point, ‘boys'' has come to mean more, like, ‘friends,’" Kevin Richardson told Apple Music’s Arjan Timmermans. “It keeps us young.” There might be some truth to that. On their ninth album <i>DNA</i>, the group dabbles in the sounds that are driving mainstream music in 2019: mid-tempo EDM (“Don’t Go Breaking My Heart”), ’80s-inspired synth-pop (“Is It Just Me”), and heart-on-sleeve country (“You’re my daybreak/You’re my California sun/You’re my Memphis, New York, New Orleans all rolled into one,” they croon on “No Place”). Even when they’re experimenting, though, they always feel familiar—they’ve still got those irresistible five-part harmonies, R&amp;B leanings, and swoonworthy come-ons that made fans fall in love with them 25 years ago. The slick and swaggering “New Love” sounds like classic BSB. “There are moments when all five of us are like, ‘Oh, dude, absolutely,’” Brian Littrell said of the moment they first heard the song. “That’s what you’re striving for.”', 1, N'@2018 K-Bahn, LLC & RCA Records, a division of Sony Music Entertainment', 1)
SET IDENTITY_INSERT [dbo].[Albums] OFF
GO
SET IDENTITY_INSERT [dbo].[Songs] ON 

INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (2, N'Don''t Go Breaking My Heart', 216, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 1)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (3, N'Nobody Else', 218, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 2)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (4, N'Breathe', 186, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 3)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (5, N'New Love', 180, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 4)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (6, N'Passionate', 223, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 5)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (7, N'Is It Just Me', 217, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 6)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (8, N'Chances', 172, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 7)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (9, N'No Place', 179, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 8)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (10, N'Chateau', 188, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 9)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (11, N'The Way It Was', 206, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 10)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (12, N'Just Like You Like It', 222, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 11)
INSERT [dbo].[Songs] ([Id], [Name], [Duration], [Price], [AlbumId], [GenreId], [ArtistId], [TrackNumber]) VALUES (13, N'OK', 155, CAST(1.2900 AS Decimal(12, 4)), 2, 1, 1, 12)
SET IDENTITY_INSERT [dbo].[Songs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [SignUpDate], [Email]) VALUES (1, N'User 1', CAST(N'2020-07-02T08:48:18.633' AS DateTime), N'testmail@that.com')
INSERT [dbo].[Users] ([Id], [UserName], [SignUpDate], [Email]) VALUES (2, N'User 2', CAST(N'2020-07-02T08:48:31.067' AS DateTime), N'anotheremail@test.com')
INSERT [dbo].[Users] ([Id], [UserName], [SignUpDate], [Email]) VALUES (3, N'User 3', CAST(N'2020-07-02T08:48:49.750' AS DateTime), N'lastone@yeah.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [DateReviewed], [Score], [AlbumId], [UserId]) VALUES (2, CAST(N'2020-07-02T08:49:58.073' AS DateTime), 4, 2, 1)
INSERT [dbo].[Reviews] ([Id], [DateReviewed], [Score], [AlbumId], [UserId]) VALUES (3, CAST(N'2020-07-02T08:50:14.700' AS DateTime), 3, 2, 2)
INSERT [dbo].[Reviews] ([Id], [DateReviewed], [Score], [AlbumId], [UserId]) VALUES (4, CAST(N'2020-07-02T08:50:21.733' AS DateTime), 5, 2, 3)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Reproductions] ON 

INSERT [dbo].[Reproductions] ([Id], [SongId], [UserId], [DatePlayed]) VALUES (1, 2, 1, CAST(N'2020-07-02T08:56:06.943' AS DateTime))
INSERT [dbo].[Reproductions] ([Id], [SongId], [UserId], [DatePlayed]) VALUES (2, 2, 1, CAST(N'2020-07-02T08:56:12.653' AS DateTime))
INSERT [dbo].[Reproductions] ([Id], [SongId], [UserId], [DatePlayed]) VALUES (3, 2, 2, CAST(N'2020-07-02T08:56:17.463' AS DateTime))
INSERT [dbo].[Reproductions] ([Id], [SongId], [UserId], [DatePlayed]) VALUES (4, 3, 1, CAST(N'2020-07-02T08:56:43.003' AS DateTime))
INSERT [dbo].[Reproductions] ([Id], [SongId], [UserId], [DatePlayed]) VALUES (5, 3, 2, CAST(N'2020-07-02T08:56:46.957' AS DateTime))
INSERT [dbo].[Reproductions] ([Id], [SongId], [UserId], [DatePlayed]) VALUES (6, 3, 3, CAST(N'2020-07-02T08:57:00.407' AS DateTime))
SET IDENTITY_INSERT [dbo].[Reproductions] OFF
GO
