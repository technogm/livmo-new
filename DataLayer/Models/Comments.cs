using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Comments
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; }
        public string Post { get; set; }
        public DateTime DatePost { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Users))]
        [Column("Id")]
        [Required]
        public string? Id { get; set; }
        public Users users { get; set; }

          [ForeignKey(nameof(Experience))]
          [Column("ExperienceId")]
          public Guid? ExperienceId { get; set; }
          public Experience experience { get; set; }
        
          [ForeignKey(nameof(FoodService))]
          [Column("FoodServId")]
          public Guid? FoodServId { get; set; }
          public FoodService foodService { get; set; }

          [ForeignKey(nameof(LodgingService))]
          [Column("LodgingId")]
          public Guid? LodgingId { get; set; }
          public LodgingService lodgingService { get; set; }

          [ForeignKey(nameof(TransportService))]
          [Column("TransportId")]
          public Guid? TransportId { get; set; }
          public TransportService transportService { get; set; }
        
    }
}
      