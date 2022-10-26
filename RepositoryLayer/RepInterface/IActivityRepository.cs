using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface IActivityRepository
    {
        public Task<Activity> InsertActivity(Activity entity);
        public Task<Activity> DeleteActivity(Activity entity);
        public Task<Activity> DeleteActivity(Guid id);
        public Task<IEnumerable<Activity>> GetSpecificActivity(Guid expId);
        public Task<Activity> FindActivityById(Guid id);
        public List<string> GetAllActivityLinks(Guid expId);
        public List<Guid> getAllActivityIDS(Guid expId);


    }
}
