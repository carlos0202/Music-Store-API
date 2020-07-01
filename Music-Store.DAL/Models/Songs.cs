using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Songs
    {
        public Songs()
        {
            Reproductions = new HashSet<Reproductions>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Duration { get; set; }
        [Column(TypeName = "decimal(12, 4)")]
        public decimal Price { get; set; }
        public long? AlbumId { get; set; }
        public long GenreId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty(nameof(Albums.Songs))]
        public virtual Albums Album { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty(nameof(Genres.Songs))]
        public virtual Genres Genre { get; set; }
        [InverseProperty("Song")]
        public virtual ICollection<Reproductions> Reproductions { get; set; }
    }
}
