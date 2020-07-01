using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class AlbumsGenre
    {
        [Key]
        public long AlbumId { get; set; }
        [Key]
        public long GenreId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty("AlbumsGenres")]
        public virtual Album Album { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty("AlbumsGenres")]
        public virtual Genre Genre { get; set; }
    }
}
