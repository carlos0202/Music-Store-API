using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Models
{
    public class SongDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public float PopularityIndex { get; set; }
    }
}
