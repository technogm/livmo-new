using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class ExperienceDatesViewModels
    {
      
        public DateTime StartTimeExpDate { get; set; }

        public DateTime EndTimeExpDate { get; set; }
        public Guid ExperienceId { get; set; }

    }
}
