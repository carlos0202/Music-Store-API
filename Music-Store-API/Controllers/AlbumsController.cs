using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music_Store.DL.Contracts;
using Music_Store.DL.Models;
using Music_Store_API.Models;

namespace Music_Store_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumsController
    {
        private readonly IMusicStoreService _musicStoreService;
        private readonly ILogger _logger;

        public AlbumsController
            (
                IMusicStoreService musicStoreService,
                ILogger<AlbumsController> logger
            )
        {
            _musicStoreService = musicStoreService;
            _logger = logger;
        }

        [HttpGet("{Id}")]
        public async Task<ResponseModel<AlbumDTO>> GetAlbum(long Id)
        {
            var model = await _musicStoreService.GetAlbum(Id);

            var result = new ResponseModel<AlbumDTO>
            {
                StatusCode = 200,
                Result = model
            };
            _logger.LogInformation($"Album info retreived at: {DateTime.Now}, Id: {Id}");

            return result;
        }

        [HttpGet("{Id}/songs")]
        public async Task<ResponseModel<IEnumerable<SongDTO>>> GetSongs(long Id)
        {
            var model = await _musicStoreService.GetSongs(Id);

            var result = new ResponseModel<IEnumerable<SongDTO>>
            {
                StatusCode = 200,
                Result = model
            };
            _logger.LogInformation($"Album's song list retreived at: {DateTime.Now}, Id: {Id}");

            return result;
        }

        [HttpGet("{Id}/reviewSummary")]
        public async Task<ResponseModel<AlbumReviewInfo>> GetReviewSummary(long Id)
        {
            var model = await _musicStoreService.GetReviewInfo(Id);

            var result = new ResponseModel<AlbumReviewInfo>
            {
                StatusCode = 200,
                Result = model
            };
            _logger.LogInformation($"Album reviews summary retreived at: {DateTime.Now}, Id: {Id}");

            return result;
        }
    }
}