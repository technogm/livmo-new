using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class TransportExperienceViewModel
    {
        [Key]
        public string TransportId { get; set; }
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
        public Guid ExperienceId { get; set; }
    }
}
