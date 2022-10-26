using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface ITransportExperienceRepository
    {
        public Task<TransportExperience> InsertTransportExperience(TransportExperience entity);
        public Task<TransportExperience> DeleteTransportExperience(TransportExperience entity);
        public Task<TransportExperience> DeleteTransportExperience(Guid id);
        public Task<IEnumerable<TransportExperience>> GetSpecificTransportExperiences(Guid expId);
        public Task<TransportExperience> FindTransportById(Guid id);
        public List<string> GetAllTransportExperienceImagesLink(Guid expId);
        public List<Guid> getAllTransportExpIDS(Guid expId);


    }
}
