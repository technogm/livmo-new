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
    public class TransportServiceRepositroy : ITransportServiceRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<TransportService> _genericRepoExp;

        public TransportServiceRepositroy(ApplicationDbContext dbContext, IGenericRepository<TransportService> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }

        public async Task<TransportService> DeleteTransportService(TransportService entity)
        {
            var exp = await _dbContext.transportServices.FindAsync(entity.TransportId);
            if (exp != null)
            {
                _dbContext.transportServices.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }
        public async Task<TransportService> DeleteTransportService(Guid id)
        {
            var exp = await _dbContext.transportServices.FindAsync(id);
            if (exp != null)
            {
                _dbContext.transportServices.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<TransportService> FindTransportById(Guid id)
        {
            var exp = await _dbContext.transportServices
                .FirstOrDefaultAsync(n => n.TransportId == id);

            return exp;
        }

       
        public async Task<IEnumerable<TransportService>> GetCommercantTransportServices(string HostId)
        {
            var exp = await _dbContext.transportServices
                                             .Where(p => p.CommercantId == HostId).ToListAsync();
            return exp;
        }

      

        public async Task<TransportService> InsertTransportService(TransportService model)
        {

            await _dbContext.transportServices.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;

        }

        public async Task PutTransportServiceAsync(Guid id, TransportService entity)
        {
            var TransportService = await _dbContext.transportServices.SingleAsync(e => e.TransportId == entity.TransportId);
            _dbContext.Entry(TransportService).State = EntityState.Detached;
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
        public List<string> GetAllTransServiceImagesLink(Guid expId)
        {
            var links = new List<string>();
            var Exp = _dbContext.transportServices.SingleOrDefault(exp => exp.TransportId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Transportphoto)
                .Load();

            foreach (var link in Exp.Transportphoto)
            {
                System.Console.WriteLine(link.Url);
                links.Add(link.Url);

            }
            return links;
        }

        public async Task<IEnumerable<TransportService>> GetCommercantValidTransport(string id)
        {
            var exp = await _dbContext.transportServices
                                                     .Where(p => p.CommercantId == id && p.Status.StartsWith("Valid")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<TransportService>> GetCommercantInValidTransport(string id)
        {
            var exp = await _dbContext.transportServices
                                                     .Where(p => p.CommercantId == id && p.Status.StartsWith("InValid")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<TransportService>> GetCommercanEnAttenteTransport(string id)
        {
            var exp = await _dbContext.transportServices
                                                    .Where(p => p.CommercantId == id && p.Status.StartsWith("En Attente")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<TransportService>> GetAllValidTransport()
        {
            var exp = await _dbContext.transportServices
                                                                .Where(p => p.Status.StartsWith("Valid")).ToListAsync();
            return exp;
        }

        public List<Guid> getAllTransportIDS(Guid expId)
        {
            var links = new List<Guid>();
            var Exp = _dbContext.transportServices.SingleOrDefault(exp => exp.TransportId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Transportphoto)
                .Load();

            foreach (var link in Exp.Transportphoto)
            {
                System.Console.WriteLine(link.Id);
                links.Add(link.Id);

            }
            return links;
        }
    }
}
