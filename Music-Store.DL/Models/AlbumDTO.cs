using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Models
{
    /// <summary>
    /// Model containing Album basic information
    /// needed to fulfill operations in the client
    /// calling code.
    /// </summary>
    public class AlbumDTO
    {
        /// <summary>
        /// The album identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// The album name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The album release date.
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// The album cover URL.
        /// </summary>
        public string CoverUrl { get; set; }
        /// <summary>
        /// The album price.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// The Itunes review for that album.
        /// </summary>
        public string ITunesReview { get; set; }
        /// <summary>
        /// The album's artist.
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// The album's copyright info, including recording
        /// company information.
        /// </summary>
        public string CopyrightInfo { get; set; }
        /// <summary>
        /// The album's genre.
        /// </summary>
        public string Genre { get; set; }
    }
}
