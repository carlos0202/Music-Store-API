using AutoMapper;
using Music_Store.DAL.Models;
using Music_Store.DL.Contracts;
using Music_Store.DL.Models;
using Music_Store.DL.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Store.DL.Services
{
    public class MusicStoreService : IMusicStoreService
    {
        private readonly IRepository<Album, long> _albumRepository;
        private readonly ISongRepository _songRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReviewRepository _reviewRepository;

        public MusicStoreService(
                IRepository<Album, long> albumRepository,
                ISongRepository songRepository,
                IUserRepository userRepository,
                IReviewRepository reviewRepository
            )
        {
            _albumRepository = albumRepository;
            _songRepository = songRepository;
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<AlbumDTO> GetAlbum(long AlbumId)
        {
            Album model = await _albumRepository.FindById(AlbumId);

            if(model == null)
            {
                return null;
            }

            // Album important data will be passed to viewModel using Automapper.
            AlbumDTO album = Mapping.Mapper.Map<Album, AlbumDTO>(model);

            return album;
        }

        public async Task<AlbumReviewInfo> GetReviewInfo(long AlbumId)
        {
            IEnumerable<Review> reviews =
                await _reviewRepository.GetAlbumReviews(AlbumId);

            // Check if there's any review information.
            if (!reviews.Any())
            {
                return null;
            }

            // ReviewInfo will be calculated using an Automapper resolver.
            AlbumReviewInfo reviewInfo = 
                Mapping.Mapper.Map<IEnumerable<Review>, AlbumReviewInfo>(reviews);

            return reviewInfo;
        }

        public async Task<IEnumerable<SongDTO>> GetSongs(long AlbumId)
        {
            IEnumerable<Song> songs =
                await _songRepository.GetSongs(AlbumId);

            if (!songs.Any())
            {
                return null;
            }

            int UsersCount =
                await _userRepository.Count();
            // Map an calculate song's popularity using Automapper resolver.
            // It uses and advanced scenario when you need to pass an extra
            // property for the mapper using the mapping context.
            IEnumerable<SongDTO> model = Mapping.Mapper
                .Map<IEnumerable<Song>, IEnumerable<SongDTO>>(
                    songs,
                    opts => opts.Items["MaxUsers"] = UsersCount
                );

            return model;
        }
    }
}
