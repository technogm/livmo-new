using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid activiteId { get; set; }
        public DateTime StartDateActivity { get; set; }
        public DateTime StartTimeActivity { get; set; }
        public DateTime EndDateActivity { get; set; }
        public DateTime EndTimeActivity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Experience))]
        [Column("ExperienceId")]
        [Required]
        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }
        public virtual ICollection <PhotosActivity> Activityphoto { get; set; }

    }
}
