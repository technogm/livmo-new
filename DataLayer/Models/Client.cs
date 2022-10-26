using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Client : Users
    {

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name cannot contain a number")]
        public string Nom { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name cannot contain a number")]
        public string Prenom { get; set; }
      
        [Required]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(8, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Telephone { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }

        public IList<TransportReservation> TransportReservations { get; set; }
        public IList<LodgingReservation> LodgingReservations { get; set; }
        public IList<FoodReservation> FoodReservations { get; set; }
        public IList<ExperiencesReservation> ExperiencesReservation { get; set; }
        public IList<Experience> Experiences { get; set; }

        public IList<UserLikes> userLikes { get; set; }
      

    }
}
