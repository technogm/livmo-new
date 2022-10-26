using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IExperiencesDatesServices
    {
        public Task<ExperienceDates> InsertExperienceDates(ExperienceDates entity);
        public Task<ExperienceDates> DeleteExperienceDates(Guid id);
        public Task<IEnumerable<ExperienceDates>> GetExperienceDatess(Guid expId);

    }
}
