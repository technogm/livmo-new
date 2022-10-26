using DataLayer.Models;
using Microsoft.AspNetCore.JsonPatch;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServImplementation
{
    public class HostServices : IHostService

    {
        readonly private IGenericRepository<Hote> GenericRepo;
        readonly private IHostRepository HostRepo;
        public HostServices(IGenericRepository<Hote> _GenericRepo, IHostRepository _CompanyRepo)
        {
            GenericRepo = _GenericRepo;
            HostRepo = _CompanyRepo;
        }
        public Task AddHostAsync(Hote Hote)
        {
            return GenericRepo.InsertAsync(Hote);

        }

        public Task DeleteHostAsync(Hote Hote)
        {
            return GenericRepo.DeleteAsync(Hote.Id);
        }

        public IList<Hote> GetAllHosts()
        {
            return HostRepo.GetAllHotesAsync().ToList();
        }

        public Task<Hote> GetHostById(string id)
        {
            return HostRepo.GetHoteDetailsAsync(id);
        }
        public Task<Hote> GetHostByEmail(string email)
        {
            return HostRepo.FindByEmail(email);
        }

        public Task UpdateHostAsync(string id, JsonPatchDocument Hote)
        {
            return HostRepo.PutHoteAsync(id, Hote);
        }
        public Task PutHostAsync(string id, Hote entity)
        {
            return HostRepo.PutHostAsync(id,entity);
        }

        public IList<Hote> GetHostEnAttente()
        {
            return HostRepo.GetHostEnAttente().ToList();
        }

        public IList<Hote> GetHostValidations()
        {
            return HostRepo.GetHostValidations().ToList();
        }

        public IList<Hote> GetIndividualHosts()
        {
            return HostRepo.GetIndividualHosts().ToList();
        }

        public IList<Hote> GetOragnaisationsHosts()
        {
            return HostRepo.GetOragnaisationsHosts().ToList();
        }
    }
}
