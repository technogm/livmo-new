using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class CommercantViewModel
    {
        /// <summary>
        ///  Commercant Variables
        /// </summary>

        public string TypeService { get; set; }
        public string LegalStatus { get; set; }
        public string BasicActivity { get; set; }
        public string RestaurantType { get; set; }
        public string RestaurantSpeciality { get; set; }


        /// <summary>
        ///  Host Variables
        /// </summary>
        public string PersAContact { get; set; }
        [DefaultValue(false)]
        public string Verified { get; set; }
        public string Telephone { get; set; }
        public string Gouvernorate { get; set; }
        public string Delegation { get; set; }
        public string LegalName { get; set; }
        public string ZipCode { get; set; }
        public string NumCnss { get; set; }
        public string TaxNum { get; set; }
        public string MaleWorkforce { get; set; }
        public string FemaleWorkforce { get; set; }

        /// <summary>
        ///  Users Variables
        /// </summary>
        public string Country { get; set; }
        public string Adresse { get; set; }


        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string ClientURI { get; set; }

    }
}
