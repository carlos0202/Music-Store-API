using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Reviews
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateReviewed { get; set; }
        public int Score { get; set; }
        public long AlbumId { get; set; }
        public long UserId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty(nameof(Albums.Reviews))]
        public virtual Albums Album { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Reviews))]
        public virtual Users User { get; set; }
    }
}
