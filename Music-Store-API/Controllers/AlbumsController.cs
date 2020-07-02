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
        public async Task<IActionResult> GetAlbum(long Id)
        {
            var model = await _musicStoreService.GetAlbum(Id);
            IActionResult result;
            string StatusMessage;
            if (model == null)
            {
                StatusMessage = $"No info found for the given Album ID: {Id}.";
                result = new NotFoundObjectResult(new { StatusMessage });
            }
            else
            {
                StatusMessage = $"Album info retreived at: {DateTime.Now}, Id: {Id}";
                result = new OkObjectResult(model);
            }

            _logger.LogInformation(StatusMessage);

            return (result);
        }

        [HttpGet("{Id}/songs")]
        public async Task<IActionResult> GetSongs(long Id)
        {
            var model = await _musicStoreService.GetSongs(Id);
            IActionResult result;
            string StatusMessage;

            if (model == null)
            {
                StatusMessage = $"No songs info found for the given Album ID: {Id}.";
                result = new NotFoundObjectResult(new { StatusMessage });
            }
            else
            {
                StatusMessage = $"Album's song list retreived at: {DateTime.Now}, Id: {Id}";
                result = new OkObjectResult(model);
            }
            _logger.LogInformation(StatusMessage);

            return result;
        }

        [HttpGet("{Id}/reviewSummary")]
        public async Task<IActionResult> GetReviewSummary(long Id)
        {
            var model = await _musicStoreService.GetReviewInfo(Id);
            IActionResult result;
            string StatusMessage;

            if (model == null)
            {
                StatusMessage = $"No album review info found for the given Album ID: {Id}.";
                result = new NotFoundObjectResult(new { StatusMessage });
            }
            else
            {
                StatusMessage = $"Album reviews summary retreived at: {DateTime.Now}, Id: {Id}";
                result = new OkObjectResult(model);
            }

            _logger.LogInformation(StatusMessage);

            return result;
        }
    }
}