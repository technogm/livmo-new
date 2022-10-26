using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class TransportReservationViewModel
    {
        public Guid TransportId { get; set; }
        public string ClientId { get; set; }

        public string Status { get; set; }
        public decimal PriceTransport { get; set; }

        public DateTime StartDateReservation { get; set; }
        public DateTime EndDateReservation { get; set; }

    }
}
