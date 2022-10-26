using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class ClientViewModel
    {
        /// <summary>
        ///  Client Variables
        /// </summary>
        /// 
        public string Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        [Required]
        public string Telephone { get; set; }

        public DateTime DateOfBirth { get; set; }

        /// <summary>
        ///  Users Variables
        /// </summary>
        public string Country { get; set; }
        public string Adresse { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //public Photo Photo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string ClientURI { get; set; }






/*
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public string UserId { get; set; }*/

    }
}
