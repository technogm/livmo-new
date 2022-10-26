using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface ICommercantRepository
    {
        public Task<Commercant> GetCommercantDetailsAsync(string id);
        public Task PutCommercantAsync(string id, Commercant entity);
        public IEnumerable<Commercant> GetAllCommercantsAsync();
        public Task<Commercant> FindByEmail(string mail);
        public Task<string> Delete(Commercant entity);
        public IEnumerable<Commercant> GetCommEnAttente();
        public IEnumerable<Commercant> GetCommValidations();
        public IEnumerable<Commercant> GetAllTransportComm();
        public IEnumerable<Commercant> GetAllLodgingComm();
        public IEnumerable<Commercant> GetAllFoodComm();

    }
}
