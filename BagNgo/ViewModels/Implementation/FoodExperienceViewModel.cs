using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class FoodExperienceViewModel
    {
        [Key]
        public string FoodId { get; set; }
        public string NameDish { get; set; }
        public string Description { get; set; }
        public Guid ExperienceId { get; set; }
    }
}
