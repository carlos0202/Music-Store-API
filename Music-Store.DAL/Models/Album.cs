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
        public long ArtistId { get; set; }
        [Required]
        [StringLength(200)]
        public string CopyrightInfo { get; set; }
        public long GenreId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        [InverseProperty("Albums")]
        public virtual Artist Artist { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty("Albums")]
        public virtual Genre Genre { get; set; }
        [InverseProperty(nameof(Review.Album))]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty(nameof(Song.Album))]
        public virtual ICollection<Song> Songs { get; set; }
    }
}
