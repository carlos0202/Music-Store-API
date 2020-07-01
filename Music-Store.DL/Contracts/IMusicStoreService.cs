using Music_Store.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Contracts
{
    /// <summary>
    /// Music Store Service interface abstraction to serve as a
    /// common interface segregation while performing operations
    /// related to the music store API.
    /// </summary>
    public interface IMusicStoreService
    {
        /// <summary>
        /// Get all the songs of the given album Id.
        /// </summary>
        /// <param name="AlbumId">The album identifier.</param>
        /// <returns>A collection of the album's songs.</returns>
        Task<IEnumerable<SongDTO>> GetSongs(long AlbumId);
        /// <summary>
        /// Get album info by the given album Id.
        /// </summary>
        /// <param name="AlbumId">The album identifier.</param>
        /// <returns>The album basic information.</returns>
        Task<AlbumDTO> GetAlbum(long AlbumId);
        /// <summary>
        /// Get album review info by the given album Id.
        /// </summary>
        /// <param name="AlbumId">The album identifier.</param>
        /// <returns>
        /// An object containing the review summary data for
        /// the given album.
        /// </returns>
        Task<AlbumReviewInfo> GetReviewInfo(long AlbumId);
    }
}
