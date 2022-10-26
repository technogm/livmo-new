using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class SubTheme
    {
        [Key]
        public int SubThemeId { get; set; }
        public String Name { get; set; }
        public Theme theme { get; set; }
        public int ThemeID { get; set; }
    }
}
