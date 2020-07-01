using Music_Store.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Contracts
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetSongs(long AlbumId);
    }
}
