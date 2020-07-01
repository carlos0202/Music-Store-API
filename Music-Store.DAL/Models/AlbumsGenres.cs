using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class AlbumsGenres
    {
        [Key]
        public long AlbumId { get; set; }
        [Key]
        public long GenreId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty(nameof(Albums.AlbumsGenres))]
        public virtual Albums Album { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty(nameof(Genres.AlbumsGenres))]
        public virtual Genres Genre { get; set; }
    }
}
