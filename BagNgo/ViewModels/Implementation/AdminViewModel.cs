﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class AdminViewModel
    {

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name cannot contain a number")]
        public String NomAdmin { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name cannot contain a number")]
        public String PrenomAdmin { get; set; }

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
    }
}
