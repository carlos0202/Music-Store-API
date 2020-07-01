using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Genres
    {
        public Genres()
        {
            AlbumsGenres = new HashSet<AlbumsGenres>();
            Songs = new HashSet<Songs>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty("Genre")]
        public virtual ICollection<AlbumsGenres> AlbumsGenres { get; set; }
        [InverseProperty("Genre")]
        public virtual ICollection<Songs> Songs { get; set; }
    }
}
