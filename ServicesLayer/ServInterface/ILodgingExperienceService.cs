using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface ILodgingExperienceService
    {
        public Task<LodgingExperience> InsertLodgingExperience(LodgingExperience entity);
        public Task<LodgingExperience> DeleteLodgingExperience(LodgingExperience entity);
        public Task<LodgingExperience> DeleteLodgingExperience(Guid id);
        public Task<IEnumerable<LodgingExperience>> GetLodgingExperiences(Guid expId);
        public IEnumerable<LodgingExperience> GetAllLodgingExperiences();
        public Task<LodgingExperience> FindLodgingByExperience(Guid id);
        public List<string> GetAllLdogingExperienceImagesLink(Guid expId);
        public List<Guid> getAllLodgingExpIDS(Guid expId);


    }
}
