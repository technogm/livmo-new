using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface ILodgingServiceRepository
    {
        public Task<LodgingService> InsertLodgingService(LodgingService entity);
        public Task<LodgingService> DeleteLodgingService(LodgingService entity);
        public Task<LodgingService> DeleteLodgingService(Guid id);
        public Task<LodgingService> FindLodgingById(Guid id);
        public Task PutLodgingServiceAsync(Guid id, LodgingService entity);
        public Task<IEnumerable<LodgingService>> GetCommercantLodgingServices(string HostId);
        public Task<IEnumerable<LodgingService>> GetCommercantValidLodging(string id);
        public Task<IEnumerable<LodgingService>> GetCommercantInValidLodging(string id);
        public Task<IEnumerable<LodgingService>> GetCommercanEnAttenteLodging(string id); 
        public List<string> GetAllLodgingServiceImagesLink(Guid expId);
        public Task<IEnumerable<LodgingService>> GetAllValidLodging();
        public List<Guid> getAllLodgingIDS(Guid expId);



    }
}
