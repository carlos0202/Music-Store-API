﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty(nameof(Album.Genre))]
        public virtual ICollection<Album> Albums { get; set; }
        [InverseProperty(nameof(Song.Genre))]
        public virtual ICollection<Song> Songs { get; set; }
    }
}
