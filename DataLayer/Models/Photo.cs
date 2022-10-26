using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Photo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string TypeFile { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        // Relationships 
        public string UserId { get; set; }
        public Users AppUser { get; set; }
        //public Guid? ExperienceIDFK { get; set; }
        //public Experience Experience { get; set; }
        //public Guid? LodgingExperineceId { get; set; }
        //public LodgingExperience LodgingExperience{ get; set; }
        //public Guid? TransportExperineceId { get; set; }
        //public TransportExperience TransportExperience { get; set; }
        //public Guid? FoodxperineceId { get; set; }
        //public FoodExperience FoodExperience { get; set; }
        //public Guid? ActivitiyId { get; set; }
        //public Activity Activity { get; set; }

        // Services
        
        //public Guid? FoodServId { get; set; }
        //public FoodService foodService { get; set; }
        ////public Guid? RestaurantId { get; set; }
        //public FoodService restaurantService { get; set; }
        //public Guid? TransportId { get; set; }
        //public TransportService TransportService { get; set; }
        //public Guid? LodgingId { get; set; }
        //public LodgingService lodgingService { get; set; }

    }
}
