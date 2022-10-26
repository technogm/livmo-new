using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class LodgingExperience 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LodgingId { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string Criteria { get; set; }

        public DateTime StartDateLodgignExp { get; set; }
        public DateTime EndDateLodgingExp { get; set; }


        [ForeignKey(nameof(Experience))]
        [Column("ExperienceId")]
        [Required]
        public Guid ExperienceId { get; set; }
        public Experience experience { get; set; }

        public virtual ICollection<PhotosLodgingsExp> Lodgingphoto { get; set; }

    }
}
