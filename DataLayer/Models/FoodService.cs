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
    public class FoodService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FoodServId { get; set; }
        public decimal FoodPrice { get; set; }
        public string RestaurantName { get; set; }
        public string Slogan { get; set; }
        public DateTime OpenHour { get; set; }
        public DateTime ClosingHour { get; set; }
        public string DishName { get; set; }
        public int Stars { get; set; }
        public string Rules { get; set; }
        public string RestaurantRules { get; set; }
        public string DishDescription { get; set; }
        public string Adress { get; set; }
        public string Website { get; set; }
        public string DaysOff { get; set; }
        [DefaultValue(false)]
        //Admin approval !
        public string Status { get; set; }

        [ForeignKey(nameof(Users))]
        [Column("CommercantId")]
        [Required]
        public string CommercantId { get; set; }
        public Commercant Commercant { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }

        public virtual ICollection<PhotosFood> Foodhoto { get; set; }
        public virtual ICollection<PhotosRestaurants> RestaurantPhotos { get; set; }
        public virtual ICollection<FoodReservation> FoodReservations { get; set; }
        public virtual ICollection<ServicesLikes> ServicesLikes { get; set; }

    }
}
