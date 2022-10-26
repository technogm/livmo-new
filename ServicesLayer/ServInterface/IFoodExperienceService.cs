using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IFoodExperienceService
    {
        public Task<FoodExperience> InsertFoodExperience(FoodExperience entity);
        public Task<FoodExperience> DeleteFoodExperience(FoodExperience entity);
        public Task<FoodExperience> DeleteFoodExperience(Guid id);
        public Task<IEnumerable<FoodExperience>> GetFoodExperiences(Guid expId);
        public IEnumerable<FoodExperience> GetAllFoodExperiences();
        public Task<FoodExperience> FindFoodByExperience(Guid id);
        public List<string> GetAllFoodExperienceImagesLink(Guid expId);
        public List<Guid> getAllFoodExpIDS(Guid expId);

    }
}
