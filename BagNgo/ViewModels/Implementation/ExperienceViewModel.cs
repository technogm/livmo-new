using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class ExperienceViewModel
    {
        [Key]
        public string ExperienceId { get; set; }
        public string ExperienceTitle { get; set; }
        public string Location { get; set; }
        public string ExperienceStatus { get; set; }
        public decimal Price { get; set; }
        public string PriceUnit { get; set; }
        public string MapLocation { get; set; }

        public int Spots { get; set; }

        public string Theme { get; set; }
        public string SubTheme { get; set; }
        public string DatType { get; set; }
        public int DurationDays { get; set; }
        public int DurationHours { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Season { get; set; }
        //public string Pictures { get; set; }

        public string ExperienceDescription { get; set; }
        public Boolean FoodExist { get; set; }

        public Boolean LodgingExist { get; set; }

        public Boolean TransportExist { get; set; }

        public Boolean PetsAllowed { get; set; }
        public int MinAge { get; set; }
        public string OtherCritics { get; set; }
        public string HostId { get; set; }


        /// ACTIVITY :
        /// 
        public string activiteId { get; set; }
        public DateTime StartDateAct { get; set; }
        public DateTime StartTimeAct { get; set; }
        public DateTime EndDateAct { get; set; }
        public DateTime EndTimeAct { get; set; }
        public string TitleAct { get; set; }
        public string DescriptionAct { get; set; }

        // FOOD

        public string FoodId { get; set; }
        public string NameDish { get; set; }
        public string DescriptionFood { get; set; }

        // TRANSPORT

        public string TransportId { get; set; }
        public string VehiculeName { get; set; }
        public int Seats { get; set; }
        public string ToGoFrom { get; set; }
        public DateTime ToGoFromDeparture { get; set; }
        public string ToGoTo { get; set; }
        public DateTime ToGoToArrival { get; set; }
        public string ToReturnFrom { get; set; }
        public DateTime ToReturnFromDeparture { get; set; }
        public string ToReturnTo { get; set; }
        public DateTime ToReturnToArrival { get; set; }
        public string DescriptionTransport { get; set; }
        // LODGING

        public string LodgingId { get; set; }
        public string CategoryLodging { get; set; }
        public string TypeLodging { get; set; }
        public string AdressLodging { get; set; }
        public string DescriptionLodging { get; set; }
        public string InstructionsLodging { get; set; }
        public string CriteriaLodging { get; set; }
        public DateTime StartDateLodging { get; set; }
        public DateTime EndDateLodging { get; set; }

        // DATES :

    
        public DateTime StartTimeSpecific { get; set; }
        public DateTime EndTimeSpecific { get; set; }

        // Days :
        public string Day { get; set; }

        //public virtual ICollection<Activity> Activites { get; set; }

    }
}
