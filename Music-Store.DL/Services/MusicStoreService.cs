using AutoMapper;
using Microsoft.Extensions.Logging;
using Music_Store.DAL.Models;
using Music_Store.DL.Contracts;
using Music_Store.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Services
{
    public class MusicStoreService : IMusicStoreService
    {
        private readonly IRepository<Album, long> _albumRepository;
        private readonly ISongRepository _songRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Review, long> _reviewRepository;
        private readonly IMapper _mapper;

        public MusicStoreService
            (
            IRepository<Album, long> albumRepository,
            ISongRepository songRepository,
            IUserRepository userRepository,
            IRepository<Review, long> reviewRepository,
            IMapper mapper
            )
        {
            _albumRepository = albumRepository;
            _songRepository = songRepository;
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<AlbumDTO> GetAlbum(long AlbumId)
        {
            Album model = await _albumRepository.FindById(AlbumId);
            AlbumDTO album = _mapper.Map<Album, AlbumDTO>(model);

            return album;
        }

        public async Task<AlbumReviewInfo> GetReviewInfo(long AlbumId)
        {
            IEnumerable<Review> reviews =
                await _reviewRepository.Where(review => review.AlbumId == AlbumId);
            // ReviewInfo will be calculated using an Automapper resolver.
            AlbumReviewInfo reviewInfo = _mapper.Map<IEnumerable<Review>, AlbumReviewInfo>(reviews);

            return reviewInfo;
        }

        public async Task<IEnumerable<SongDTO>> GetSongs(long AlbumId)
        {
            IEnumerable<Song> songs =
                await _songRepository.GetSongs(AlbumId);
            int UsersCount =
                await _userRepository.Count();
        }
    }
}
