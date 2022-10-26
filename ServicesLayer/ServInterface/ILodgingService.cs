using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface ILodgingService
    {
        public Task<LodgingService> InsertLodgingService(LodgingService entity);
        public Task<LodgingService> DeleteLodgingService(LodgingService entity);
        public Task<LodgingService> DeleteLodgingService(Guid id);
        public Task<LodgingService> FindLodgingServiceById(Guid id);
        public IEnumerable<LodgingService> GetAllLodgingServices();
        public Task<IEnumerable<LodgingService>> GetAllCommercantLodgingServices(string HostId);
        public Task<IEnumerable<LodgingService>> GetCommercantValidLodging(string id);
        public Task<IEnumerable<LodgingService>> GetCommercantInValidLodging(string id);
        public Task<IEnumerable<LodgingService>> GetCommercanEnAttenteLodging(string id);
        public Task UpdateLodgingServiceAsync(Guid id, LodgingService LodgingService);
        public List<string> GetAllLodgingServiceImagesLink(Guid expId);
        public Task<IEnumerable<LodgingService>> GetAllValidLodging();
        public List<Guid> getAllLodgingIDS(Guid expId);

    }
}
