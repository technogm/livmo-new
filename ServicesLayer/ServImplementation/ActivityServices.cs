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
   public class ActivityServices : IActivityServices
    {
        readonly private IGenericRepository<Activity> GenericRepo;
        readonly private IActivityRepository ExperienceRepo;

        public ActivityServices(IGenericRepository<Activity> genericRepo, IActivityRepository experienceRepo)
        {
            GenericRepo = genericRepo;
            ExperienceRepo = experienceRepo;
        }
        public async Task<Activity> DeleteActivity(Activity entity)
        {
            return await ExperienceRepo.DeleteActivity(entity);
        }

        public async Task<Activity> DeleteActivity(Guid id)
        {
            return await ExperienceRepo.DeleteActivity(id);

        }

        public async Task<Activity> FindActivityByExperience(Guid id)
        {
            return await ExperienceRepo.FindActivityById(id);

        }

        public IEnumerable<Activity> GetAllActivity()
        {
            return GenericRepo.GetAll();
        }

        public async Task<IEnumerable<Activity>> GetActivitys(Guid expId)
        {
            return await ExperienceRepo.GetSpecificActivity(expId);
        }

        public async Task<Activity> InsertActivity(Activity entity)
        {
            return await ExperienceRepo.InsertActivity(entity);

        }

        public async Task<Activity> FindActivityById(Guid id)
        {
            return await ExperienceRepo.FindActivityById(id);
        }

        public  List<string> GetAllActivityImagesLink(Guid expId)
        {
            return  ExperienceRepo.GetAllActivityLinks(expId);
        }

        public List<Guid> getAllActitvityIDS(Guid expId)
        {
            return  ExperienceRepo.getAllActivityIDS(expId);
        }
    }
}