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
   public class LikeServices : ILikesService
    {
        readonly private IGenericRepository<ServicesLikes> GenericRepo;
        readonly private ILikesRepository ExperienceRepo;

        public LikeServices(IGenericRepository<ServicesLikes> genericRepo, ILikesRepository experienceRepo)
        {
            GenericRepo = genericRepo;
            ExperienceRepo = experienceRepo;
        }

        public async Task<string> DeleteServicesLikes(Guid ClientId)
        {
            return await ExperienceRepo.DeleteServicesLikes(ClientId);
        }

        public Task<ServicesLikes> FindLikeById(Guid id)
        {
            return ExperienceRepo.FindLikeById(id);
        }

        public async Task<IEnumerable<ServicesLikes>> GetExperienceServicesLikes(Guid ExpId)
        {
            return await ExperienceRepo.GetExperienceServicesLikes(ExpId);
        }

        public async Task<IEnumerable<ServicesLikes>> GetFoodServicesLikes(Guid expId)
        {
            return await ExperienceRepo.GetFoodServicesLikes(expId);
        }

        public async Task<IEnumerable<ServicesLikes>> GetLodgingServicesLikes(Guid expId)
        {
            return await ExperienceRepo.GetLodgingServicesLikes(expId);
        }

        public async Task<IEnumerable<ServicesLikes>> GetTransportServicesLikes(Guid expId)
        {
            return await ExperienceRepo.GetTransportServicesLikes(expId);

        }

        public async Task<ServicesLikes> InsertServicesLikes(ServicesLikes entity)
        {
            return await ExperienceRepo.InsertServicesLikes(entity);
        }
    }
}

