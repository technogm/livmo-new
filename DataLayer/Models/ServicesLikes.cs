using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ServicesLikes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ServiceLikeId { get; set; }

      
        [ForeignKey(nameof(Users))]
        [Column("Id")]
        [Required]
        public string Id { get; set; }
        public Users users { get; set; }

        [ForeignKey(nameof(Experience))]
        [Column("ExperienceId")]
        [Required]
        public Guid? ExperienceId { get; set; }
        public Experience experience { get; set; }

        [ForeignKey(nameof(FoodService))]
        [Column("FoodServId")]
        [Required]
        public Guid? FoodServId { get; set; }
        public FoodService foodService { get; set; }

        [ForeignKey(nameof(LodgingService))]
        [Column("LodgingId")]
        [Required]
        public Guid? LodgingId { get; set; }
        public LodgingService lodgingService { get; set; }

        [ForeignKey(nameof(TransportService))]
        [Column("TransportId")]
        [Required]
        public Guid? TransportId { get; set; }
        public TransportService transportService { get; set; }
      
    }
}
