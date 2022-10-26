using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface ILodgingExpRepository
    {
        public Task<LodgingExperience> InsertLodgingExperience(LodgingExperience entity);
        public Task<LodgingExperience> DeleteLodgingExperience(LodgingExperience entity);
        public Task<LodgingExperience> DeleteLodgingExperience(Guid id);
        public Task<IEnumerable<LodgingExperience>> GetLodgingExperiences(Guid expId);
        public Task<LodgingExperience> FindLodgingById(Guid id);
        public List<string> GetAllLdogingExperienceImagesLink(Guid expId);
        public List<Guid> getAllLodgingExpIDS(Guid expId);


    }
}
