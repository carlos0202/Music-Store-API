using Music_Store.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music_Store.DL.Contracts
{
    /// <summary>
    /// Reviews repository interface that exposes the
    /// required methods to be implemented to provide
    /// basic album reviews fetching operations.
    /// </summary>
    public interface IReviewRepository
    {
        /// <summary>
        /// Obtains the list of reviews of a given album by its
        /// identifier passed as parameter.
        /// </summary>
        /// <param name="AlbumId">The album identifier.</param>
        /// <returns>A list of reviews for the given album.</returns>
        Task<IEnumerable<Review>> GetAlbumReviews(long AlbumId);
    }
}
