using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class EditCommercantViewModel
    {
        public string TypeService { get; set; }
        public string LegalStatus { get; set; }
        public string BasicActivity { get; set; }
        public string CADTouristTraansp { get; set; }
        public string RestaurantType { get; set; }
        public string RestaurantSpeciality { get; set; }

        public string PersAContact { get; set; }
        [DefaultValue(false)]
        public string Verified { get; set; }
        public string Telephone { get; set; }
        public string Delegation { get; set; }
        public string Gouvernorate { get; set; }
        public string LegalName { get; set; }
        public string CINCopy { get; set; }
        public string RNECopy { get; set; }
        public string LicenceCopy { get; set; }
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

    }
}
