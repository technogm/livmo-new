using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface ITransportExperienceServices
    {
        public Task<TransportExperience> InsertTransportExperience(TransportExperience entity);
        public Task<TransportExperience> DeleteTransportExperience(TransportExperience entity);
        public Task<TransportExperience> DeleteTransportExperience(Guid id);
        public Task<IEnumerable<TransportExperience>> GetTransportExperiences(Guid expId);
        public IEnumerable<TransportExperience> GetAllTransportsExperiences();
        public Task<TransportExperience> FindTransportByExperience(Guid id);
        public List<string> GetAllTransportExperienceImagesLink(Guid expId);
        public List<Guid> getAllTransportExpIDS(Guid expId);


    }
}
