using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.Models;
using Music_Store.DL.Contracts;
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
            return await _context
                            .Albums
                            .Include(album => album.Artist)
                            .Include(album => album.Genre)
                            .FirstOrDefaultAsync(album => album.Id == Id);
        }
    }
}
