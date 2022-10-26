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
     public class LodgingService
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
        public string Status { get; set; }
        [ForeignKey(nameof(Users))]
        [Column("CommercantId")]
        [Required]
        public string CommercantId { get; set; }
        public Commercant Commercant { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }

        public virtual ICollection<PhotosLodgings> Lodgingphoto { get; set; }
        public virtual ICollection<LodgingReservation> LodgingReservations { get; set; }
        public virtual ICollection<ServicesLikes> ServicesLikes { get; set; }
    }
}
