using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.ViewModels.Implementation
{
    public class PhotosViewModel
    {

        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public string UserId { get; set; }
        public string TypeFile {get;set;}
            public Guid ExperienceIDFK { get; set; }
        
    }
}
