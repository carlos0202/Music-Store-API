using Moq;
using Music_Store.DAL.Models;
using Music_Store.DL.Contracts;
using Music_Store.DL.Models;
using Music_Store.DL.Services;
using Music_Store_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Music_Store.DL.Tests.ServiceTests
{
    public class MusicStoreServiceTests
    {
        private Mock<IRepository<Album, long>> AlbumRepository { get; }
        private Mock<ISongRepository> SongRepository { get; }
        private Mock<IUserRepository> UserRepository { get; }
        private Mock<IReviewRepository> ReviewRepository { get; }
        private IMusicStoreService MusicStoreService { get; }

        public MusicStoreServiceTests()
        {
            long testAlbumId = 1;
            var artist = new Artist()
            {
                Id = 1,
                PublicName = "Backstreet Boys",
                Country = "United States"
            };
            var users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    UserName = "UserName1",
                    Email = "Email",
                    SignUpDate = DateTime.Now
                },
                new User()
                {
                    Id = 2,
                    UserName = "UserName2",
                    Email = "Email2",
                    SignUpDate = DateTime.Now
                }
            };
            var genre = new Genre()
            {
                Id = 1,
                Name = "Pop"
            };
            var album = new Album()
            {
                Id = testAlbumId,
                Name = "DNA",
                CoverUrl = "http",
                Description = "Description",
                Price = 12.99M,
                ArtistId = artist.Id,
                Artist = artist,
                GenreId = genre.Id,
                Genre = genre,
                CopyrightInfo = "@",
                ReleaseDate = DateTime.Now
            };
            var songs = new List<Song>()
            {
                new Song()
                {
                    Id = 1,
                    Name = "Song 1",
                    Duration = 320,
                    Price = 1.29M,
                    AlbumId = testAlbumId,
                    Album = album,
                    GenreId = genre.Id,
                    Genre = genre,
                    ArtistId = artist.Id,
                    Artist = artist,
                    TrackNumber = 1,
                    Reproductions = new List<Reproduction>()
                    {
                        new Reproduction()
                        {
                            Id = 1,
                            UserId = users.ElementAt(0).Id
                        }
                    }
                },
                new Song()
                {
                    Id = 2,
                    Name = "Song 2",
                    Duration = 300,
                    Price = 1.29M,
                    AlbumId = testAlbumId,
                    Album = album,
                    GenreId = genre.Id,
                    Genre = genre,
                    TrackNumber = 2,
                    Reproductions = new List<Reproduction>()
                    {
                        new Reproduction()
                        {
                            Id = 1,
                            UserId = users.ElementAt(0).Id
                        },
                        new Reproduction()
                        {
                            Id = 2,
                            UserId = users.ElementAt(1).Id
                        }
                    }
                }
            };
            
            var reviews = new List<Review>()
            {
                new Review()
                {
                    Id = 1,
                    AlbumId = testAlbumId,
                    Score = 1,
                    UserId = users.ElementAt(0).Id,
                    DateReviewed = DateTime.Now
                },
                new Review()
                {
                    Id = 2,
                    AlbumId = testAlbumId,
                    Score = 5,
                    UserId = users.ElementAt(1).Id,
                    DateReviewed = DateTime.Now
                }
            };

             // Setup AlbumRepository Mock call being tested.
            AlbumRepository = new Mock<IRepository<Album, long>>();
            AlbumRepository.Setup(l => l.FindById(testAlbumId))
                .ReturnsAsync(album);
            // Setup SongRepository Mock call being tested.
            SongRepository = new Mock<ISongRepository>();
            SongRepository.Setup(l => l.GetSongs(testAlbumId))
                .ReturnsAsync(songs);
            // Setup UserRepository Mock call being tested.
            UserRepository = new Mock<IUserRepository>();
            UserRepository.Setup(l => l.Count())
                .ReturnsAsync(users.Count);
            // Setup ReviewRepository Mock call being tested.
            ReviewRepository = new Mock<IReviewRepository>();
            ReviewRepository.Setup(l => l.GetAlbumReviews(testAlbumId))
                .ReturnsAsync(reviews);
            // Setup MusicStoreService Mock for unit tests.
            MusicStoreService = new MusicStoreService(
                AlbumRepository.Object,
                SongRepository.Object,
                UserRepository.Object,
                ReviewRepository.Object
            );

        }

        [Fact]
        public void Can_Get_Album_Info()
        {
            // Arrange
            var albumId = 1;
            var expectedAlbumName = "DNA";

            // Act 
            var albumInfo = MusicStoreService.GetAlbum(albumId).Result;

            // Assert
            // assert that the repository method was indeed called once.
            AlbumRepository.Verify(l => l.FindById(albumId), Times.Once);
            Assert.Equal(albumId, albumInfo.Id);
            Assert.Equal(expectedAlbumName, albumInfo.Name);
        }

        [Fact]
        public void Should_Return_Null_Get_Unknown_Album_Info()
        {
            // Arrange
            var albumId = 2;
            Album outputAlbum = null;
            AlbumRepository.Setup(l => l.FindById(albumId))
                .ReturnsAsync(outputAlbum);

            // Act 
            var albumInfo = MusicStoreService.GetAlbum(albumId).Result;

            // Assert
            // assert that the repository method was indeed called once.
            AlbumRepository.Verify(l => l.FindById(albumId), Times.Once);
            Assert.Null(albumInfo);
        }

        [Fact]
        public void Can_Get_Album_Songs()
        {
            // Arrange
            var albumId = 1;
            var songsCount = 2;

            // Act 
            var songs = MusicStoreService.GetSongs(albumId).Result;

            // Assert
            // assert that the repository method was called once.
            SongRepository.Verify(l => l.GetSongs(albumId), Times.Once);
            Assert.NotNull(songs);
            Assert.Equal(songsCount, songs.Count());
        }

        [Fact]
        public void Should_Return_Null_Get_Album_Songs_Unknown_Album()
        {
            // Arrange
            var albumId = 2;
            SongRepository.Setup(l => l.GetSongs(albumId))
                .ReturnsAsync(Enumerable.Empty<Song>());

            // Act 
            var songs = MusicStoreService.GetSongs(albumId).Result;

            // Assert
            // assert that the repository method was called once.
            SongRepository.Verify(l => l.GetSongs(albumId), Times.Once);
            Assert.Null(songs);
        }

        [Fact]
        public void Can_Get_Album_Review_Info()
        {
            // Arrange
            var albumId = 1;
            var reviewsCount = 2;
            float reviewScore = 3;

            // Act 
            var reviewInfo = MusicStoreService.GetReviewInfo(albumId).Result;

            // Assert
            // assert that the repository method was called once.
            ReviewRepository.Verify(l => l.GetAlbumReviews(albumId), Times.Once);
            Assert.Equal(albumId, reviewInfo.AlbumId);
            Assert.Equal(reviewsCount, reviewInfo.ReviewsCount);
            Assert.Equal(reviewScore, reviewInfo.AverageScore);
        }

        [Fact]
        public void Should_Return_Null_Get_Unknown_Album_Review_Info()
        {
            // Arrange
            var albumId = 2;
            ReviewRepository.Setup(l => l.GetAlbumReviews(albumId))
                .ReturnsAsync(Enumerable.Empty<Review>());

            // Act 
            var reviewInfo = MusicStoreService.GetReviewInfo(albumId).Result;

            // Assert
            // assert that the repository method was called once.
            ReviewRepository.Verify(l => l.GetAlbumReviews(albumId), Times.Once);
            Assert.Null(reviewInfo);
        }
    }
}
