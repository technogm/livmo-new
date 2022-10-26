using DataLayer.Data;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.RepInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepImplementation
{
    public class ReservationFoodRepository : IReservationFoodRespository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<FoodReservation> _genericRepoExp;

        public ReservationFoodRepository(ApplicationDbContext dbContext, IGenericRepository<FoodReservation> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }
        public async Task<FoodReservation> DeleteFoodReservation(Guid id)
        {
            var exp = await _dbContext.FoodReservation.FindAsync(id);
            if (exp != null)
            {
                _dbContext.FoodReservation.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<FoodReservation> FindFoodReservationById(Guid id)
        {
            var exp = await _dbContext.FoodReservation
                                      .SingleAsync(n => n.FoodReservationId == id);
            _dbContext.Entry(exp);
            return exp;
        }

        public async Task<IEnumerable<FoodReservation>> GetAllClientsFoodReservation(string clid)
        {
            var exp = await _dbContext.FoodReservation
                            .Where(p => p.ClientId == clid).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<FoodReservation>> GetAllCommercantFoodReservation(string clid)
        {
            var exp = await (from b in _dbContext.FoodReservation
                             join com in _dbContext.foodServices
                             on b.FoodServId equals com.FoodServId             
                             where com.CommercantId == clid
                             select new
                             {
                                
                             }
                             ).ToListAsync();


                return (IEnumerable<FoodReservation>)exp;
        }

        public async Task<IEnumerable<FoodReservation>> GetAllFoodReservation()
        {
            var User = await _dbContext.FoodReservation.Where(User => User.FoodReservationId == User.FoodReservationId).ToListAsync();

            return User;
        }

        public async Task<IEnumerable<FoodReservation>> GetFoodReservationAccepted()
        {
            var exp = await _dbContext.FoodReservation
                                                 .Where(p => p.Status.StartsWith("Accepted")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<FoodReservation>> GetFoodReservationPaid()
        {
            var exp = await _dbContext.FoodReservation.Where(p => p.Status.StartsWith("Paid")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<FoodReservation>> GetFoodReservationPending()
        {
            var exp = await _dbContext.FoodReservation.Where(p => p.Status.StartsWith("Pending")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<FoodReservation>> GetFoodReservationRejected()
        {
            var exp = await _dbContext.FoodReservation.Where(p => p.Status.StartsWith("Rejected")).ToListAsync();
            return exp;
        }

        public async Task<FoodReservation> InsertFoodReservation(FoodReservation entity)
        {
            await _dbContext.FoodReservation.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateStatus(Guid id, FoodReservation entity)
        {
            var user = await _dbContext.FoodReservation.SingleAsync(user => user.FoodReservationId == entity.FoodReservationId);
            _dbContext.Entry(user).State = EntityState.Detached;
            _dbContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
