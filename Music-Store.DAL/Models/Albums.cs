using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Albums
    {
        public Albums()
        {
            AlbumsGenres = new HashSet<AlbumsGenres>();
            Reviews = new HashSet<Reviews>();
            Songs = new HashSet<Songs>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        [Column("CoverURL")]
        [StringLength(2083)]
        public string CoverUrl { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [InverseProperty("Album")]
        public virtual ICollection<AlbumsGenres> AlbumsGenres { get; set; }
        [InverseProperty("Album")]
        public virtual ICollection<Reviews> Reviews { get; set; }
        [InverseProperty("Album")]
        public virtual ICollection<Songs> Songs { get; set; }
    }
}
