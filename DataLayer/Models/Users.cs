using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DataLayer.Models
{
    public class Users : IdentityUser
    {
        public string Country { get; set; }
        public string Adresse { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public string PhotoLink { get; set; }
       // public string? ImgPath { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

          public  ICollection<Comments> Comments { get; set; }
          public IList<ServicesLikes> servicesLike { get; set; }
          public virtual IList<UserLikes> UserLike { get; set; }



    }
}
