using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserLikes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LikeId { get; set; }

       [ForeignKey(nameof(Users))]
        [Column("Id")]
        [Required]
        public string userLikesId { get; set; }
        public Users users { get; set; }

    }
}
