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
    public class TransportExperienceServices : ITransportExperienceServices
    {
        readonly private IGenericRepository<TransportExperience> GenericRepo;
        readonly private ITransportExperienceRepository ExperienceRepo;

        public TransportExperienceServices (IGenericRepository<TransportExperience> genericRepo, ITransportExperienceRepository experienceRepo)
        {
            GenericRepo = genericRepo;
            ExperienceRepo = experienceRepo;
        }
        public async Task<TransportExperience> DeleteTransportExperience(TransportExperience entity)
        {
            return await ExperienceRepo.DeleteTransportExperience(entity);
        }

        public async Task<TransportExperience> DeleteTransportExperience(Guid id)
        {
            return await ExperienceRepo.DeleteTransportExperience(id);

        }

        public async Task<TransportExperience> FindTransportByExperience(Guid id)
        {
            return await ExperienceRepo.FindTransportById(id);

        }

        public List<string> GetAllTransportExperienceImagesLink(Guid expId)
        {
            return ExperienceRepo.GetAllTransportExperienceImagesLink(expId);
        }

        public List<Guid> getAllTransportExpIDS(Guid expId)
        {
            return ExperienceRepo.getAllTransportExpIDS(expId);
        }

        public  IEnumerable<TransportExperience> GetAllTransportsExperiences()
        {
            return GenericRepo.GetAll();
        }

        public async Task<IEnumerable<TransportExperience>> GetTransportExperiences(Guid expId)
        {
            return await ExperienceRepo.GetSpecificTransportExperiences(expId);
        }

        public async Task<TransportExperience> InsertTransportExperience(TransportExperience entity)
        {
            return await ExperienceRepo.InsertTransportExperience(entity);

        }
    }
}
