using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Album
    {
        public Album()
        {
            AlbumsGenres = new HashSet<AlbumsGenre>();
            Reviews = new HashSet<Review>();
            Songs = new HashSet<Song>();
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

        [InverseProperty(nameof(AlbumsGenre.Album))]
        public virtual ICollection<AlbumsGenre> AlbumsGenres { get; set; }
        [InverseProperty(nameof(Review.Album))]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty(nameof(Song.Album))]
        public virtual ICollection<Song> Songs { get; set; }
    }
}
