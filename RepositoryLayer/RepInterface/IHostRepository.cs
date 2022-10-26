using DataLayer.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface IHostRepository
    {
        public Task<Hote> GetHoteDetailsAsync(string id);
        public Task PutHoteAsync(string id, JsonPatchDocument entity);
        public IEnumerable<Hote> GetAllHotesAsync();
        public Task<Hote> FindByEmail(string mail);
        public Task<string> Delete(Hote entity);
        public Task PutHostAsync(string id, Hote entity);
        public IEnumerable<Hote> GetHostEnAttente();
        public IEnumerable<Hote> GetHostValidations();
        public IEnumerable<Hote> GetIndividualHosts();
        public IEnumerable<Hote> GetOragnaisationsHosts();



    }
}
