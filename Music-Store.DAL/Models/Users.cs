using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.DAL.Models
{
    public partial class Users
    {
        public Users()
        {
            Reproductions = new HashSet<Reproductions>();
            Reviews = new HashSet<Reviews>();
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

        [InverseProperty("SongNavigation")]
        public virtual ICollection<Reproductions> Reproductions { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
