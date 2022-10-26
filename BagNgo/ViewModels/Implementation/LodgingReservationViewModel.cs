using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class LodgingReservationViewModel
    {
        public Guid LodgingId { get; set; }
       
        public string ClientId { get; set; }
        public string Status { get; set; }
        public decimal PriceLodging { get; set; }
        public decimal Seats { get; set; }
        public DateTime ReservationLArrival { get; set; }
        public DateTime ReservationLDeparture { get; set; }
    }
}
