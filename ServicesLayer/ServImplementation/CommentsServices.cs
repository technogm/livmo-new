using DataLayer.Models;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServImplementation
{
    public class CommentsServices : ICommentService
    {
        readonly private IGenericRepository<Comments> GenericRepo;
        readonly private ICommentsRepository ExperienceRepo;

        public CommentsServices(IGenericRepository<Comments> genericRepo, ICommentsRepository experienceRepo)
        {
            GenericRepo = genericRepo;
            ExperienceRepo = experienceRepo;
        }

        public async Task<string> DeleteComments(Guid ClientId)
        {
            return await ExperienceRepo.DeleteComments(ClientId);
        }

        public Task<Comments> FindComById(Guid id)
        {
            return ExperienceRepo.FindComById(id);
        }

        public async Task<IEnumerable<Comments>> GetExperienceComments(Guid ExpId)
        {
            return await ExperienceRepo.GetExperienceComments(ExpId);
        }

        public async Task<IEnumerable<Comments>> GetFoodComments(Guid expId)
        {
            return await ExperienceRepo.GetFoodComments(expId);
        }

        public async Task<IEnumerable<Comments>> GetLodgingComments(Guid expId)
        {
            return await ExperienceRepo.GetLodgingComments(expId);
        }

        public async Task<IEnumerable<Comments>> GetTransportComments(Guid expId)
        {
            return await ExperienceRepo.GetTransportComments(expId);

        }

        public async Task<Comments> InsertComments(Comments entity)
        {
            return await ExperienceRepo.InsertComments(entity);
        }
    }
}
