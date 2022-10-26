using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class UserClaimViewModel
    {
        public UserClaimViewModel()
        {
            Cliams = new List<UserClaim>();
        }

        public string id { get; set; }
        public List<UserClaim> Cliams { get; set; }
    }
}
