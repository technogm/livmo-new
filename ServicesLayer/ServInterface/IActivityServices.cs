using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IActivityServices
    {
        public Task<Activity> InsertActivity(Activity entity);
        public Task<Activity> DeleteActivity(Activity entity);
        public Task<Activity> DeleteActivity(Guid id);
        public Task<IEnumerable<Activity>> GetActivitys(Guid expId);
        public IEnumerable<Activity> GetAllActivity();
        public Task<Activity> FindActivityByExperience(Guid id);
        public Task<Activity> FindActivityById(Guid id);
        public List<string> GetAllActivityImagesLink(Guid expId);

        public List<Guid> getAllActitvityIDS(Guid expId);

    }
}
