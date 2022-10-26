using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IFoodService
    {
        public Task<FoodService> InsertFoodService(FoodService entity);
        public Task<FoodService> DeleteFoodService(FoodService entity);
        public Task<FoodService> DeleteFoodService(Guid id);
        public Task<FoodService> FindFoodServiceById(Guid id);
        public IEnumerable<FoodService> GetAllFoodServices();
        public Task<IEnumerable<FoodService>> GetAllCommercantFoodServices(string HostId);
        public Task<IEnumerable<FoodService>> GetCommercantValidFood(string id);
        public Task<IEnumerable<FoodService>> GetCommercantInValidFood(string id);
        public Task<IEnumerable<FoodService>> GetCommercanEnAttenteFood(string id); public Task UpdateFoodServiceAsync(Guid id, FoodService FoodService);
        public List<string> GetAllFoodServiceImagesLink(Guid expId);
        public Task<IEnumerable<FoodService>> GetAllValidFood();
        public List<Guid> getAllFoodIDS(Guid expId);

    }
}
