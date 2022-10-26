using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataLayer.Models
{
    public class Hote : Users
    {
        public string PersAContact { get; set; }
        [DefaultValue(false)] 
        public string Verified { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string Type { get; set; }
        public string Gouvernorate { get; set; }
        public string Delegation { get; set; }
        [Required]
        // Nom du personne ou bien du societé !
        public string LegalName { get; set; }
        public string CINCopy { get; set; }
        public string RNECopy { get; set; }
        public string LicenceCopy { get; set; }
        public string ZipCode { get; set; }
        public string NumCnss { get; set; }
        public string TaxNum { get; set; }

        public string MaleWorkforce { get; set; }
        public string FemaleWorkforce { get; set; }
        // One to Many : Each host have many experiences
        public virtual IList<Experience> Experiences { get; set; }

    }
}
