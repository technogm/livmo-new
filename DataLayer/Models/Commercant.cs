using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Commercant : Hote
    {
        [Required]
        public string TypeService { get; set; }
        [Required]
        public string LegalStatus { get; set; }
        [Required]
        public string BasicActivity { get; set; }
        public string CADTouristTraansp { get; set; }
        public string RestaurantType { get; set; }
        public string RestaurantSpeciality { get; set; }

        public virtual IList<LodgingService> LodgingServices { get; set; }
        public virtual IList<TransportService> TransportServices { get; set; }
        public virtual IList<FoodService> FoodServices { get; set; }
    }
}
