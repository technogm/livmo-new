using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface ICommentService
    {
        public Task<Comments> InsertComments(Comments entity);
        public Task<string> DeleteComments(Guid ClientId);
        public Task<Comments> FindComById(Guid id);
        public Task<IEnumerable<Comments>> GetExperienceComments(Guid expId);
        public Task<IEnumerable<Comments>> GetLodgingComments(Guid expId);
        public Task<IEnumerable<Comments>> GetFoodComments(Guid expId);
        public Task<IEnumerable<Comments>> GetTransportComments(Guid expId);

    }
}
