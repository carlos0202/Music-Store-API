using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    [Table("Artist")]
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(200)]
        public string PublicName { get; set; }
        [Required]
        [StringLength(200)]
        public string Country { get; set; }

        [InverseProperty(nameof(Album.Artist))]
        public virtual ICollection<Album> Albums { get; set; }
        [InverseProperty(nameof(Song.Artist))]
        public virtual ICollection<Song> Songs { get; set; }
    }
}
