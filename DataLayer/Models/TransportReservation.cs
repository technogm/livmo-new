using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TransportReservation
    {
  
    [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransportReservationId { get; set; }
        [ForeignKey(nameof(TransportService))]
        [Column("TransportServiceId")]
        [Required]
        public Guid TransportId { get; set; }
        public TransportService TransportServicee { get; set; }

        [ForeignKey(nameof(Users))]
        [Column("ClientID")]
        [Required]
        public string ClientId { get; set; }
        public Client Client { get; set; }

        public string Status { get; set; }
        public decimal PriceTransport { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime StartDateReservation { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime EndDateReservation { get; set; }

    }
}

