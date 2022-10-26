using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class CommentsViewModel
    {
     
        public string Post { get; set; }
        public DateTime DatePost { get; set; } = DateTime.Now; 
       

    }
}
