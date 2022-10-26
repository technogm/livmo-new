using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class LodgingReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LodgingReservationId { get; set; }
        [ForeignKey(nameof(LodgingService))]
        [Column("LodgingServiceId")]
        [Required]
        public Guid LodgingId { get; set; }
        public LodgingService LodgingServicee { get; set; } 
        [ForeignKey(nameof(Users))]
        [Column("ClientID")]
        [Required]
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public string Status { get; set; }
        public decimal PriceLodging { get; set; }
        public decimal Seats { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ReservationLArrival { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ReservationLDeparture { get; set; }

    }
}
