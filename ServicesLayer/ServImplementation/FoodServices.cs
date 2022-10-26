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
    public class FoodServices : IFoodService
    {
        readonly private IGenericRepository<FoodService> GenericRepo;
        readonly private IFoodServiceRepository _FoodServiceRepo;

        public FoodServices(IGenericRepository<FoodService> genericRepo, IFoodServiceRepository FoodServiceRepo)
        {
            GenericRepo = genericRepo;
            _FoodServiceRepo = FoodServiceRepo;
        }

        public async Task<FoodService> DeleteFoodService(FoodService entity)
        {
            return await _FoodServiceRepo.DeleteFoodService(entity);
        }

        public async Task<FoodService> DeleteFoodService(Guid id)
        {
            return await _FoodServiceRepo.DeleteFoodService(id);
        }

        public async Task<FoodService> FindFoodServiceById(Guid id)
        {
            return await _FoodServiceRepo.FindFoodById(id);
        }

        public IEnumerable<FoodService> GetAllFoodServices()
        {
            return GenericRepo.GetAll();

        }

        public async Task<IEnumerable<FoodService>> GetAllCommercantFoodServices(string HostId)
        {
            return await _FoodServiceRepo.GetCommercantFoodServices(HostId);

        }

     

        public async Task<FoodService> InsertFoodService(FoodService entity)
        {
            return await _FoodServiceRepo.InsertFoodService(entity);
        }

        public Task UpdateFoodServiceAsync(Guid id, FoodService FoodService)
        {
            return _FoodServiceRepo.PutFoodServiceAsync(id, FoodService);

        }

        public List<string> GetAllFoodServiceImagesLink(Guid expId)
        {
            return _FoodServiceRepo.GetAllFoodServiceImagesLink(expId);
        }

        public Task<IEnumerable<FoodService>> GetCommercantValidFood(string id)
        {
            return _FoodServiceRepo.GetCommercantValidFood(id);

        }

        public Task<IEnumerable<FoodService>> GetCommercantInValidFood(string id)
        {
            return _FoodServiceRepo.GetCommercantInValidFood(id);
        }

        public Task<IEnumerable<FoodService>> GetCommercanEnAttenteFood(string id)
        {
            return _FoodServiceRepo.GetCommercanEnAttenteFood(id);
        }

        public Task<IEnumerable<FoodService>> GetAllValidFood()
        {
            return _FoodServiceRepo.GetAllValidFood();
        }

        public List<Guid> getAllFoodIDS(Guid expId)
        {
            return _FoodServiceRepo.getAllFoodIDS(expId);
        }
    }
}
