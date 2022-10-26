using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class LodgingExperienceViewModel
    {
        [Key]
        public string LodgingId { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string Criteria { get; set; }
        public DateTime StartDateLodgignExp { get; set; }
        public DateTime EndDateLodgingExp { get; set; }
        public Guid ExperienceId { get; set; }

    }
}
