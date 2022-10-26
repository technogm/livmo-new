using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class FoodReservation
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FoodReservationId { get; set; }

        [ForeignKey(nameof(FoodService))]
        [Column("FoodServId")]
        [Required]
        public Guid FoodServId { get; set; }
        public FoodService FoodServicee { get; set; }


        [ForeignKey(nameof(Users))]
        [Column("ClientID")]
        [Required]
        public string ClientId { get; set; }
        public Client Client { get; set; }

        public string Status { get; set; }
        public decimal PriceFood { get; set; }

        public decimal Seats { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime Arrival { get; set; }


    }
}
