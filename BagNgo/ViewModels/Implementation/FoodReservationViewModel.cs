using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class FoodReservationViewModel
    {
        public Guid FoodServId { get; set; }
        public string ClientId { get; set; }

        public string Status { get; set; }
        public decimal PriceFood { get; set; }

        public decimal Seats { get; set; }

        public DateTime Arrival { get; set; }

    }
}
