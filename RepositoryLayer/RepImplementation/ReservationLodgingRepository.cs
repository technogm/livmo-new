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
    public class ReservationLodgingRepository : IReservationLodgingRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<LodgingReservation> _genericRepoExp;

        public ReservationLodgingRepository(ApplicationDbContext dbContext, IGenericRepository<LodgingReservation> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }
        public async Task<LodgingReservation> DeleteLodgingReservation(Guid id)
        {
            var exp = await _dbContext.LodgingReservation.FindAsync(id);
            if (exp != null)
            {
                _dbContext.LodgingReservation.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<LodgingReservation> FindLodgingReservationById(Guid id)
        {
            var exp = await _dbContext.LodgingReservation
                                      .SingleAsync(n => n.LodgingReservationId == id);
            _dbContext.Entry(exp);
            return exp;
        }

        public async Task<IEnumerable<LodgingReservation>> GetAllClientsLodgingReservation(string clid)
        {
            var exp = await _dbContext.LodgingReservation
                            .Where(p => p.ClientId == clid).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<LodgingReservation>> GetAllCommercantLodgingReservation(string clid)
        {
            var exp = await (from b in _dbContext.LodgingReservation
                             join com in _dbContext.lodgingServices
                             on b.LodgingId equals com.LodgingId
                             where com.CommercantId == clid
                             select new
                             {

                             }
                             ).ToListAsync();


            return (IEnumerable<LodgingReservation>)exp;
        }

        public async Task<IEnumerable<LodgingReservation>> GetAllLodgingReservation()
        {
            var User =await _dbContext.LodgingReservation.Where(User => User.LodgingReservationId == User.LodgingReservationId).ToListAsync();

            return User;
        }

        public async Task <IEnumerable<LodgingReservation>> GetLodgingReservationAccepted()
        {
            var exp = await _dbContext.LodgingReservation
                                                 .Where(p => p.Status.StartsWith("Accepted")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<LodgingReservation>> GetLodgingReservationPaid()
        {
            var exp = await _dbContext.LodgingReservation
                                                 .Where(p => p.Status.StartsWith("Paid")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<LodgingReservation>> GetLodgingReservationPending()
        {
            var exp = await _dbContext.LodgingReservation
                                                 .Where(p => p.Status.StartsWith("Pending")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<LodgingReservation>> GetLodgingReservationRejected()
        {
            var exp = await _dbContext.LodgingReservation
                                                .Where(p => p.Status.StartsWith("Rejected")).ToListAsync();
            return exp;
        }

        public async Task<LodgingReservation> InsertLodgingReservation(LodgingReservation entity)
        {
            await _dbContext.LodgingReservation.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateStatus(Guid id, LodgingReservation entity)
        {
            var user = await _dbContext.LodgingReservation.SingleAsync(user => user.LodgingReservationId == entity.LodgingReservationId);
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
