using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface ICommercantService
    {
        public Task AddCommercantAsync(Commercant Commercant);
        public IList<Commercant> GetAllCommercants();
        public Task UpdateCommercantAsync(string id ,Commercant Commercant);
        public Task<Commercant> GetCommercantById(string id);
        public Task<Commercant> GetCommercantByEmail(string email);
        public Task DeleteCommercantAsync(Commercant Commercant);
        public IList<Commercant> GetCommEnAttente();
        public IList<Commercant> GetCommValidations();
        public IList<Commercant> GetAllTransportComm();
        public IList<Commercant> GetAllLodgingComm();
        public IList<Commercant> GetAllFoodComm();

    }
}
