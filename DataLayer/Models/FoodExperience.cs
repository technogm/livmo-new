using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class FoodExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FoodId { get; set; }
        public string NameDish { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Experience))]
        [Column("ExperienceId")]
        [Required]
        public Guid ExperienceId { get; set; }
        public Experience experience { get; set; }

        public virtual ICollection<PhotosFoodExp> Foodphoto { get; set; }
    }
}
