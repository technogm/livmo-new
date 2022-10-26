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
    public class ExperiencesDatesServices : IExperiencesDatesServices
    {
        readonly private IGenericRepository<FoodExperience> GenericRepo;
        readonly private IDatesExpRepository ExperienceRepo;

        public ExperiencesDatesServices(IGenericRepository<FoodExperience> genericRepo, IDatesExpRepository experienceRepo)
        {
            GenericRepo = genericRepo;
            ExperienceRepo = experienceRepo;
        }

        public async Task<ExperienceDates> DeleteExperienceDates(Guid id)
        {
            return await ExperienceRepo.DeleteExperienceDates(id);
        }

     
        public async Task<IEnumerable<ExperienceDates>> GetExperienceDatess(Guid expId)
        {
            return await ExperienceRepo.GetExperienceDates(expId);
        }

        public  async Task<ExperienceDates> InsertExperienceDates(ExperienceDates entity)
        {
            return await ExperienceRepo.InsertExperienceDates(entity);
        }
    }
}
