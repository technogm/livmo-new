using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class ActivityViewModel
    {
        [Key]
        public string activiteId { get; set; }
        public DateTime StartDateActivity { get; set; }
        public DateTime StartTimeActivity { get; set; }
        public DateTime EndDateActivity { get; set; }
        public DateTime EndTimeActivity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ExperienceId { get; set; }
    }
}
