﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Reproductions
    {
        [Key]
        public long Id { get; set; }
        public long SongId { get; set; }
        public long UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DatePlayed { get; set; }

        [ForeignKey(nameof(SongId))]
        [InverseProperty(nameof(Songs.Reproductions))]
        public virtual Songs Song { get; set; }
        [ForeignKey(nameof(SongId))]
        [InverseProperty(nameof(Users.Reproductions))]
        public virtual Users SongNavigation { get; set; }
    }
}
