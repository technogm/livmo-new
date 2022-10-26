using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class EditExperienceViewModel
    {
        public string Title { get; set; }
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

        public string Description { get; set; }
        public Boolean FoodExist { get; set; }

        public Boolean LodgingExist { get; set; }

        public Boolean TransportExist { get; set; }

        public Boolean PetsAllowed { get; set; }
        public int MinAge { get; set; }
        public string OtherCritics { get; set; }

    }
}
