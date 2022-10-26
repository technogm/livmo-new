using DataLayer.Models;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServImplementation
{
    public class LodgingExperienceService : ILodgingExperienceService
    {

        readonly private IGenericRepository<LodgingExperience> GenericRepo;
        readonly private ILodgingExpRepository ExperienceRepo;

        public LodgingExperienceService(IGenericRepository<LodgingExperience> genericRepo, ILodgingExpRepository experienceRepo)
        {
            GenericRepo = genericRepo;
            ExperienceRepo = experienceRepo;
        }
        public async Task<LodgingExperience> DeleteLodgingExperience(LodgingExperience entity)
        {
            return await ExperienceRepo.DeleteLodgingExperience(entity);
        }

        public async Task<LodgingExperience> DeleteLodgingExperience(Guid id)
        {
            return await ExperienceRepo.DeleteLodgingExperience(id);

        }

        public async Task<LodgingExperience> FindLodgingByExperience(Guid id)
        {
            return await ExperienceRepo.FindLodgingById(id);

        }

        public List<string> GetAllLdogingExperienceImagesLink(Guid expId)
        {
            return ExperienceRepo.GetAllLdogingExperienceImagesLink(expId);
        }

        public IEnumerable<LodgingExperience> GetAllLodgingExperiences()
        {
            return GenericRepo.GetAll();
        }

        public List<Guid> getAllLodgingExpIDS(Guid expId)
        {
            return ExperienceRepo.getAllLodgingExpIDS(expId);
        }

        public async Task<IEnumerable<LodgingExperience>> GetLodgingExperiences(Guid expId)
        {
            return await ExperienceRepo.GetLodgingExperiences(expId);
        }

        public async Task<LodgingExperience> InsertLodgingExperience(LodgingExperience entity)
        {
            return await ExperienceRepo.InsertLodgingExperience(entity);

        }
    }
}
