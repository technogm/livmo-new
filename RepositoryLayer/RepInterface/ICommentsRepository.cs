using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface ICommentsRepository
    {
        public Task<Comments> InsertComments(Comments entity);
        public Task<string> DeleteComments(Guid ClientId);
        public Task<Comments> FindComById(Guid id);
        public Task<IEnumerable<Comments>> GetExperienceComments(Guid HostId);
        public Task<IEnumerable<Comments>> GetLodgingComments(Guid HostId);
        public Task<IEnumerable<Comments>> GetFoodComments(Guid HostId);
        public Task<IEnumerable<Comments>> GetTransportComments(Guid HostId);

    }
}
