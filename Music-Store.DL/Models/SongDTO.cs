using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Models
{
    /// <summary>
    /// Model containing basic informaation about
    /// a song, excluding relationship data and
    /// focusing on lightweight data transfers.
    /// </summary>
    public class SongDTO
    {
        /// <summary>
        /// The song's identifier.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// The song's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The song's track duration in seconds.
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// The song's price.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// The song's pupularity index calculated
        /// using stored song reproductions of users
        /// registered.
        /// </summary>
        public float PopularityIndex { get; set; }
        /// <summary>
        /// The song's artist.
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// The song's playback order in the album.
        /// </summary>
        public int TrackNumber { get; set; }
    }
}
