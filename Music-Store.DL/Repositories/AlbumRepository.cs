using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.Models;
using Music_Store.DL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Repositories
{
    public class AlbumRepository : IRepository<Album, long>
    {
        private readonly MusicStoreContext _context;

        public AlbumRepository(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<Album> FindById(long Id)
        {
            return await _context.Albums.FindAsync(Id);
        }

        public async Task<IEnumerable<Album>> GetAll()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task<IEnumerable<Album>> Where(Expression<Func<Album, bool>> exp)
        {
            return await _context.Albums.AsQueryable().Where(exp).ToListAsync();
        }
    }
}
