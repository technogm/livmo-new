using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Admin : Users
    {

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name cannot contain a number")]
        public String NomAdmin { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name cannot contain a number")]
        public String PrenomAdmin { get; set; }

    }
}
