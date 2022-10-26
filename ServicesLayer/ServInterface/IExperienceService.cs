using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IExperienceService
    {
        public Task<Experience> InsertExperience(Experience entity);
        public Task<Experience> DeleteExperience(Experience entity);
        public Task<Experience> DeleteExperience(Guid id);
        public Task<Experience> FindExperienceById(Guid id);

        public IEnumerable<Experience> GetAllExperiences();
        public Task<IEnumerable<Experience>> GetAllHostExperiences(string HostId);
        public Task<IEnumerable<Experience>> GetValidExperiences();
        public Task UpdateExperienceAsync(Guid id, Experience Experience);
        public Task<IEnumerable<Experience>> GetHostValidExperiences(string id);
        public Task<IEnumerable<Experience>> GetHostInvalidExperiences(string id);
        public Task<IEnumerable<Experience>> GetHostEnAttExperiences(string id);
        public List<string> GetAllExperienceImagesLink(Guid expId);
        public List<Guid> getAllExperienceIDS(Guid expId);


    }
}
