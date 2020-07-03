using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Models
{
    /// <summary>
    /// Model containing summary info about
    /// user reviews to a given album.
    /// </summary>
    public class AlbumReviewInfo
    {
        /// <summary>
        /// Total reviews given to the album.
        /// </summary>
        public int ReviewsCount { get; set; }
        /// <summary>
        /// AveraageScore of the reviews given
        /// by the users.
        /// </summary>
        public float AverageScore { get; set; }
        /// <summary>
        /// Album identifier owner of the review
        /// information.
        /// </summary>
        public long AlbumId { get; set; }
    }
}
