using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Reproductions = new HashSet<Reproduction>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SignUpDate { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [InverseProperty(nameof(Reproduction.SongNavigation))]
        public virtual ICollection<Reproduction> Reproductions { get; set; }
        [InverseProperty(nameof(Review.User))]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
