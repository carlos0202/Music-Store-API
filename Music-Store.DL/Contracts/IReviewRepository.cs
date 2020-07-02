using Music_Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Contracts
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAlbumReviews(long AlbumId);
    }
}
