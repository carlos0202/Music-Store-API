using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Genre
    {
        public Genre()
        {
            AlbumsGenres = new HashSet<AlbumsGenre>();
            Songs = new HashSet<Song>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty(nameof(AlbumsGenre.Genre))]
        public virtual ICollection<AlbumsGenre> AlbumsGenres { get; set; }
        [InverseProperty(nameof(Song.Genre))]
        public virtual ICollection<Song> Songs { get; set; }
    }
}
