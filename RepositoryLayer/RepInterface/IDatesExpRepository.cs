using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface IDatesExpRepository
    {
        public Task<ExperienceDates> InsertExperienceDates(ExperienceDates entity);
        public Task<ExperienceDates> DeleteExperienceDates(Guid id);
        public Task<IEnumerable<ExperienceDates>> GetExperienceDates(Guid expId);
    }
}
