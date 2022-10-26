using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface IReservationFoodRespository
    {
        public Task<FoodReservation> InsertFoodReservation(FoodReservation entity);
        public Task<FoodReservation> DeleteFoodReservation(Guid id);
        public Task<FoodReservation> FindFoodReservationById(Guid id);
        public  Task<IEnumerable<FoodReservation>> GetAllClientsFoodReservation(string clid);
        public  Task<IEnumerable<FoodReservation>> GetAllCommercantFoodReservation(string clid);
        public Task<IEnumerable<FoodReservation>> GetFoodReservationPending();
        public Task<IEnumerable<FoodReservation>> GetFoodReservationAccepted();
        public Task<IEnumerable<FoodReservation>> GetFoodReservationRejected();
        public Task<IEnumerable<FoodReservation>> GetFoodReservationPaid();
        public Task<IEnumerable<FoodReservation>> GetAllFoodReservation();
        public Task UpdateStatus(Guid id, FoodReservation entity);
    }
}
