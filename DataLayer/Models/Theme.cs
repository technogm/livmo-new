using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Theme
    {
        [Key]
        public int ThemeID { get; set; }
        public String Name { get; set; }

        public virtual List<SubTheme> themes { get; set; }
    }
}
