using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Song
    {
        public Song()
        {
            Reproductions = new HashSet<Reproduction>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Duration { get; set; }
        [Column(TypeName = "decimal(12, 4)")]
        public decimal Price { get; set; }
        public long AlbumId { get; set; }
        public long GenreId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty("Songs")]
        public virtual Album Album { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty("Songs")]
        public virtual Genre Genre { get; set; }
        [InverseProperty(nameof(Reproduction.Song))]
        public virtual ICollection<Reproduction> Reproductions { get; set; }
    }
}
