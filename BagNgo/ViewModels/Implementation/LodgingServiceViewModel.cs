using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class LodgingServiceViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LodgingId { get; set; }
        public string LodgingCategory { get; set; }
        public string LodgingType { get; set; }
        public string LodgingName { get; set; }
        public string LodgingAdress { get; set; }
        public string LodgingWebsite { get; set; }
        public string LodgingDescript { get; set; }
        public decimal PricePerNight { get; set; }
        [DefaultValue(false)]
        //Admin approval !
        [Required]
        public string CommercantId { get; set; }

    }
}
