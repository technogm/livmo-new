using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;

namespace ServicesLayer.ServImplementation
{
    public class LodgingServices : ILodgingService
    {
        readonly private IGenericRepository<LodgingService> GenericRepo;
        readonly private ILodgingServiceRepository _LodgingServiceRepo;

        public LodgingServices(IGenericRepository<LodgingService> genericRepo, ILodgingServiceRepository LodgingServiceRepo)
        {
            GenericRepo = genericRepo;
            _LodgingServiceRepo = LodgingServiceRepo;
        }

        public async Task<LodgingService> DeleteLodgingService(LodgingService entity)
        {
            return await _LodgingServiceRepo.DeleteLodgingService(entity);
        }

        public async Task<LodgingService> DeleteLodgingService(Guid id)
        {
            return await _LodgingServiceRepo.DeleteLodgingService(id);
        }

        public async Task<LodgingService> FindLodgingServiceById(Guid id)
        {
            return await _LodgingServiceRepo.FindLodgingById(id);
        }

        public IEnumerable<LodgingService> GetAllLodgingServices()
        {
            return GenericRepo.GetAll();

        }

        public async Task<IEnumerable<LodgingService>> GetAllCommercantLodgingServices(string HostId)
        {
            return await _LodgingServiceRepo.GetCommercantLodgingServices(HostId);

        }

      
        public async Task<LodgingService> InsertLodgingService(LodgingService entity)
        {
            return await _LodgingServiceRepo.InsertLodgingService(entity);
        }

        public Task UpdateLodgingServiceAsync(Guid id, LodgingService LodgingService)
        {
            return _LodgingServiceRepo.PutLodgingServiceAsync(id, LodgingService);

        }

        public List<string> GetAllLodgingServiceImagesLink(Guid expId)
        {
            return _LodgingServiceRepo.GetAllLodgingServiceImagesLink(expId);
        }

        public Task<IEnumerable<LodgingService>> GetCommercantValidLodging(string id)
        {
            return _LodgingServiceRepo.GetCommercantValidLodging(id);

        }

        public Task<IEnumerable<LodgingService>> GetCommercantInValidLodging(string id)
        {
            return _LodgingServiceRepo.GetCommercantInValidLodging(id);
        }

        public Task<IEnumerable<LodgingService>> GetCommercanEnAttenteLodging(string id)
        {
            return _LodgingServiceRepo.GetCommercanEnAttenteLodging(id);
        }

        public Task<IEnumerable<LodgingService>> GetAllValidLodging()
        {
            return _LodgingServiceRepo.GetAllValidLodging();
        }

        public List<Guid> getAllLodgingIDS(Guid expId)
        {
            return _LodgingServiceRepo.getAllLodgingIDS(expId);
        }
    }
}
