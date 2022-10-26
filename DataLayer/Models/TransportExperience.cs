using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TransportExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransportId { get; set; }
        public string VehiculeName { get; set; }
        public int Seats { get; set; }
        public string ToGoFrom { get; set; }
        public DateTime ToGoFromDeparture { get; set; }

        public string ToGoTo { get; set; }
        public DateTime ToGoToArrival { get; set; }

        public string ToReturnFrom { get; set; }
        public DateTime ToReturnFromDeparture { get; set; }
        public string ToReturnTo { get; set; }
        public DateTime ToReturnToArrival { get; set; }

        public string Description { get; set; }


        [ForeignKey(nameof(Experience))]
        [Column("ExperienceId")]
        [Required]
        public Guid ExperienceId { get; set; }
        public Experience eperience { get; set; }

        public virtual ICollection<PhotosTransportsExp> Transphoto { get; set; }

    }
}
