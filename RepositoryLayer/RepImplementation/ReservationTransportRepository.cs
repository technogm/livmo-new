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
    public class ReservationTransportRepository : IReservationTransportRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<TransportReservation> _genericRepoExp;

        public ReservationTransportRepository(ApplicationDbContext dbContext, IGenericRepository<TransportReservation> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }
        public async Task<TransportReservation> DeleteTransportReservation(Guid id)
        {
            var exp = await _dbContext.TransportReservation.FindAsync(id);
            if (exp != null)
            {
                _dbContext.TransportReservation.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<TransportReservation> FindTransportReservationById(Guid id)
        {
            var exp = await _dbContext.TransportReservation
                                      .SingleAsync(n => n.TransportReservationId == id);
            _dbContext.Entry(exp);
            return exp;
        }

        public async Task<IEnumerable<TransportReservation>> GetAllClientsTransportReservation(string clid)
        {
            var exp = await _dbContext.TransportReservation
                            .Where(p => p.ClientId == clid).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<TransportReservation>> GetAllCommercantTransportReservation(string clid)
        {
            var exp = await (from b in _dbContext.TransportReservation
                             join com in _dbContext.transportServices
                             on b.TransportId equals com.TransportId
                             where com.CommercantId == clid
                             select new
                             {

                             }
                             ).ToListAsync();


            return (IEnumerable<TransportReservation>)exp;
        }

        public async Task<IEnumerable<TransportReservation>> GetAllTransportReservation()
        {
            var User = await _dbContext.TransportReservation.Where(User => User.TransportReservationId == User.TransportReservationId).ToListAsync();

            return User;
        }

        public async Task<IEnumerable<TransportReservation>> GetTransportReservationAccepted()
        {
            var exp = await _dbContext.TransportReservation
                                                 .Where(p => p.Status.StartsWith("Accepted")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<TransportReservation>> GetTransportReservationPaid()
        {
            var exp = await _dbContext.TransportReservation
                                                 .Where(p => p.Status.StartsWith("Paid")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<TransportReservation>> GetTransportReservationPending()
        {
            var exp = await _dbContext.TransportReservation
                                                 .Where(p => p.Status.StartsWith("Pending")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<TransportReservation>> GetTransportReservationRejected()
        {
            var exp =await _dbContext.TransportReservation
                                                .Where(p => p.Status.StartsWith("Rejected")).ToListAsync();
            return exp;
        }

        public async Task<TransportReservation> InsertTransportReservation(TransportReservation entity)
        {
            await _dbContext.TransportReservation.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateStatus(Guid id, TransportReservation entity)
        {
            var user = await _dbContext.TransportReservation.SingleAsync(user => user.TransportReservationId == entity.TransportReservationId);
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
