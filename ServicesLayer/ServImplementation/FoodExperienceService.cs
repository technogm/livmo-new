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
    public class FoodExperienceService : IFoodExperienceService
    {

        readonly private IGenericRepository<FoodExperience> GenericRepo;
        readonly private IFoodExpRepository ExperienceRepo;

        public FoodExperienceService(IGenericRepository<FoodExperience> genericRepo, IFoodExpRepository experienceRepo)
        {
            GenericRepo = genericRepo;
            ExperienceRepo = experienceRepo;
        }
        public async Task<FoodExperience> DeleteFoodExperience(FoodExperience entity)
        {
            return await ExperienceRepo.DeleteFoodExperience(entity);
        }

        public async Task<FoodExperience> DeleteFoodExperience(Guid id)
        {
            return await ExperienceRepo.DeleteFoodExperience(id);

        }

        public async Task<FoodExperience> FindFoodByExperience(Guid id)
        {
            return await ExperienceRepo.FindFoodById(id);

        }

        public List<string> GetAllFoodExperienceImagesLink(Guid expId)
        {
            return ExperienceRepo.GetAllFoodExperienceImagesLink(expId);
        }

        public IEnumerable<FoodExperience> GetAllFoodExperiences()
        {
            return GenericRepo.GetAll();
        }

        public List<Guid> getAllFoodExpIDS(Guid expId)
        {
            return ExperienceRepo.getAllFoodExpIDS(expId);
        }

        public async Task<IEnumerable<FoodExperience>> GetFoodExperiences(Guid expId)
        {
            return await ExperienceRepo.GetSpecificFoodExperiences(expId);
        }

        public async Task<FoodExperience> InsertFoodExperience(FoodExperience entity)
        {
            return await ExperienceRepo.InsertFoodExperience(entity);

        }
    }
}
