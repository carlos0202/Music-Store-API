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
    public class SongRepository : ISongRepository
    {
        private readonly MusicStoreContext _context;

        public SongRepository(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetSongs(long AlbumId)
        {
            return await _context
                .Songs
                .Include(song => song.Reproductions)
                .ToListAsync();
        }
    }
}
