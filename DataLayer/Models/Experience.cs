using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
   public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ExperienceId { get; set; }
        public string ExperienceTitle { get; set; }
        public string Location { get; set; }
        [DefaultValue(false)]
        //Admin approval !
        public string ExperienceStatus { get; set; }
        public string MapLocation {get;set;}
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        [DisplayName("Price (dt)")] 
        public decimal Price { get; set; }
        public string PriceUnit { get; set; }
        public int Spots { get; set; }
        public string Theme { get; set; }
        public string SubTheme { get; set; }
        public string DatType { get; set; }
        public int DurationDays { get; set; }
        public string DaysOff { get; set; }
        public int DurationHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Season { get; set; }
        // Duplicated
        public string ExperienceDescription { get; set; }
        [DefaultValue(false)]
        public Boolean FoodExist { get; set; }
        [DefaultValue(false)]
        public Boolean LodgingExist { get; set; }
        [DefaultValue(false)]
        public Boolean TransportExist { get; set; }
        public Boolean PetsAllowed { get; set; }
        public int MinAge { get; set; }
        public string OtherCritics { get; set; }

        // From one to many Host :
        [ForeignKey(nameof(Users))]
        [Column("HostId")]
        [Required]
        public string HostId { get; set; }
        public Hote Host { get; set; }

        // Class Experience : 
        // Listes : 
        public virtual ICollection<Activity> Activites { get; set; }
        public virtual ICollection<LodgingExperience> LodgingExperience { get; set; }
        public virtual ICollection<FoodExperience> FoodExperience { get; set; }
        public virtual ICollection<TransportExperience> TransportExperience { get; set; }
        public virtual ICollection<ExperienceDates> ExperienceDates { get; set; }
        public virtual ICollection<PhotosExperience> Photos { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<ServicesLikes> ServicesLikes { get; set; }
        public virtual ICollection<ExperiencesReservation> ExperiencesReservation { get; set; }

    }
}
