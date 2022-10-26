using DataLayer.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IHostService
    {
        public Task AddHostAsync(Hote Hote);
        public IList<Hote> GetAllHosts();
        public Task UpdateHostAsync(string id, JsonPatchDocument Hote);
        public Task<Hote> GetHostById(string id);
        public Task<Hote> GetHostByEmail(string email);

        public Task DeleteHostAsync(Hote Hote);
        public Task PutHostAsync(string id, Hote entity);
        public IList<Hote> GetHostEnAttente();
        public IList<Hote> GetHostValidations();
        public IList<Hote> GetIndividualHosts();
        public IList<Hote> GetOragnaisationsHosts();



    }
}
