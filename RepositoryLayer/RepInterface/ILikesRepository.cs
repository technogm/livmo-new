using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface ILikesRepository
    {
        public Task<ServicesLikes> InsertServicesLikes(ServicesLikes entity);
        public Task<string> DeleteServicesLikes(Guid ClientId);
        public Task<ServicesLikes> FindLikeById(Guid id);
        public Task<IEnumerable<ServicesLikes>> GetExperienceServicesLikes(Guid UserId);
        public Task<IEnumerable<ServicesLikes>> GetLodgingServicesLikes(Guid UserId);
        public Task<IEnumerable<ServicesLikes>> GetFoodServicesLikes(Guid UserId);
        public Task<IEnumerable<ServicesLikes>> GetTransportServicesLikes(Guid UserId);
    }
}
