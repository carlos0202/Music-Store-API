using Music_Store.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music_Store.DL.Contracts
{
    /// <summary>
    /// Songs repository interface that exposes the
    /// required methods to be implemented to provide
    /// basic album songs fetching operations.
    /// </summary>
    public interface ISongRepository
    {
        /// <summary>
        /// Obtains the list of songs of a given album by its
        /// identifier passed as parameter.
        /// </summary>
        /// <param name="AlbumId">The album identifier.</param>
        /// <returns>A list of songs that belongs to an album</returns>
        Task<IEnumerable<Song>> GetSongs(long AlbumId);
    }
}
