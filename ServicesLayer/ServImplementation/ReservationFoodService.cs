using DataLayer.Models;
using RepositoryLayer.RepImplementation;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServImplementation
{
    public class ReservationFoodService : IReservationFoodService
    {
        readonly private IGenericRepository<FoodService> GenericRepo;
        readonly private IReservationFoodRespository FoodRepo;

        public ReservationFoodService(IGenericRepository<FoodService> genericRepo, IReservationFoodRespository _FoodRepo)
        {
            GenericRepo = genericRepo;
            FoodRepo = _FoodRepo;
        }

        public async Task<FoodReservation> DeleteFoodReservation(Guid id)
        {
            return await FoodRepo.DeleteFoodReservation(id);

        }

        public async Task<FoodReservation> FindFoodReservationById(Guid id)
        {
            return await FoodRepo.FindFoodReservationById(id);
        }

        public async Task<IEnumerable<FoodReservation>> GetAllClientsFoodReservation(string clid)
        {
            return await FoodRepo.GetAllClientsFoodReservation(clid);
        }

        public async Task<IEnumerable<FoodReservation>> GetAllCommercantFoodReservation(string clid)
        {
            return await FoodRepo.GetAllCommercantFoodReservation(clid);

        }

        public async Task<IEnumerable<FoodReservation>> GetAllFoodReservation()
        {
            return await FoodRepo.GetAllFoodReservation();
        }

        public async Task<IEnumerable<FoodReservation>> GetFoodReservationAccepted()
        {
            return await FoodRepo.GetFoodReservationAccepted();
        }

        public async Task<IEnumerable<FoodReservation>> GetFoodReservationPaid()
        {
            return await FoodRepo.GetFoodReservationPaid();
        }

        public async Task<IEnumerable<FoodReservation>> GetFoodReservationPending()
        {
            return await FoodRepo.GetFoodReservationPending();
        }

        public async Task<IEnumerable<FoodReservation>> GetFoodReservationRejected()
        {
            return await FoodRepo.GetFoodReservationRejected();
        }

        public async Task<FoodReservation> InsertFoodReservation(FoodReservation entity)
        {
            return await FoodRepo.InsertFoodReservation(entity);
        }

        public Task UpdateStatus(Guid id, FoodReservation entity)
        {
            return FoodRepo.UpdateStatus(id, entity);
        }
    }
}
