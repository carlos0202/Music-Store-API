using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.Models;
using Music_Store.DL.Contracts;
using Music_Store.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly MusicStoreContext _context;

        public ReviewRepository(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAlbumReviews(long AlbumId)
        {
            return await _context
                            .Reviews
                            .Where(review => review.AlbumId == AlbumId)
                            .ToListAsync();
        }
    }
}
