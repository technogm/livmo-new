using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class EditClientViewModel
    {
        public string Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        [Required]
        public string Telephone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }
        public string Adresse { get; set; }

    }
}
