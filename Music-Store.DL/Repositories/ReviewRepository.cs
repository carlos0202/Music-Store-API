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
    public class ReviewRepository : IRepository<Review, long>
    {
        private readonly MusicStoreContext _context;

        public ReviewRepository(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<Review> FindById(long Id)
        {
            return await _context.Reviews.FindAsync(Id);
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> Where(Expression<Func<Review, bool>> exp)
        {
            return await _context.Reviews.AsQueryable().Where(exp).ToListAsync();
        }
    }
}
