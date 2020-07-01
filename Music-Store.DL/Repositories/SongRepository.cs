using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.Models;
using Music_Store.DL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Music_Store.DL.Repositories
{
    public class SongRepository : IRepository<Song, long>
    {
        private readonly MusicStoreContext _context;

        public SongRepository(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<Song> FindById(long Id)
        {
            return await _context.Songs.FindAsync(Id);
        }

        public async Task<IEnumerable<Song>> GetAll()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<IEnumerable<Song>> Where(Expression<Func<Song, bool>> exp)
        {
            return await _context.Songs.AsQueryable().Where(exp).ToListAsync();
        }
    }
}
