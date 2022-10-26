using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ExperiencesReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ExperienceReservationId { get; set; }
        public int Seats { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public string IntervalTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey(nameof(Client))]
        [Column("ClientID")]
        [Required]
        public string ClientId { get; set; }
        public Client Client { get; set; }
        [ForeignKey(nameof(Experience))]
        [Column("ExperienceId")]
        [Required]
        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }

    }
}
