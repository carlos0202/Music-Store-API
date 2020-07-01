using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Models
{
    public class AlbumReviewInfo
    {
        public int ReviewsCount { get; set; }
        public float AverageScore { get; set; }
        public long AlbumId { get; set; }
    }
}
