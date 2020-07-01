using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Models
{
    public class AlbumDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
