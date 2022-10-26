using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class ExperienceReservationViewModel
    {
        
        public int Seats { get; set; }
        public double Price { get; set; }
        public string IntervalTime { get; set; }
        public string TypeExperience { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ClientId { get; set; }       
        public Guid ExperienceId { get; set; }

    }
}
