using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.RepInterface;

namespace RepositoryLayer.RepImplementation
{
    public class LodgingServiceRepository : ILodgingServiceRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<LodgingService> _genericRepoExp;

        public LodgingServiceRepository(ApplicationDbContext dbContext, IGenericRepository<LodgingService> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }

        public async Task<LodgingService> DeleteLodgingService(LodgingService entity)
        {
            var exp = await _dbContext.lodgingServices.FindAsync(entity.LodgingId);
            if (exp != null)
            {
                _dbContext.lodgingServices.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }
        public async Task<LodgingService> DeleteLodgingService(Guid id)
        {
            var exp = await _dbContext.lodgingServices.FindAsync(id);
            if (exp != null)
            {
                _dbContext.lodgingServices.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<LodgingService> FindLodgingById(Guid id)
        {
            var exp = await _dbContext.lodgingServices
                .FirstOrDefaultAsync(n => n.LodgingId == id);

            return exp;
        }


        public async Task<IEnumerable<LodgingService>> GetCommercantLodgingServices(string HostId)
        {
            var exp = await _dbContext.lodgingServices
                                             .Where(p => p.CommercantId == HostId).ToListAsync();
            return exp;
        }

     
        public async Task<LodgingService> InsertLodgingService(LodgingService model)
        {

            await _dbContext.lodgingServices.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;

        }

        public async Task PutLodgingServiceAsync(Guid id, LodgingService entity)
        {
            var LodgingService = await _dbContext.lodgingServices.SingleAsync(e => e.LodgingId == entity.LodgingId);
            _dbContext.Entry(LodgingService).State = EntityState.Detached;
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
        public List<string> GetAllLodgingServiceImagesLink(Guid expId)
        {
            var links = new List<string>();
            var Exp = _dbContext.lodgingServices.SingleOrDefault(exp => exp.LodgingId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Lodgingphoto)
                .Load();

            foreach (var link in Exp.Lodgingphoto)
            {
                System.Console.WriteLine(link.Url);
                links.Add(link.Url);

            }
            return links;
        }

        public async Task<IEnumerable<LodgingService>> GetCommercantValidLodging(string id)
        {
            var exp = await _dbContext.lodgingServices
                                                    .Where(p => p.CommercantId == id && p.Status.StartsWith("Valid")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<LodgingService>> GetCommercantInValidLodging(string id)
        {
            var exp = await _dbContext.lodgingServices
                                        .Where(p => p.CommercantId == id && p.Status.StartsWith("InValid")).ToListAsync();
            return exp;

        }

        public async Task<IEnumerable<LodgingService>> GetCommercanEnAttenteLodging(string id)
        {
            var exp = await _dbContext.lodgingServices
                                        .Where(p => p.CommercantId == id && p.Status.StartsWith("En Attente")).ToListAsync();
            return exp;
            ;
        }

        public async Task<IEnumerable<LodgingService>> GetAllValidLodging()
        {
            var exp = await _dbContext.lodgingServices
                                                               .Where(p => p.Status.StartsWith("Valid")).ToListAsync();
            return exp;
        }

        public List<Guid> getAllLodgingIDS(Guid expId)
        {
            var links = new List<Guid>();
            var Exp = _dbContext.lodgingServices.SingleOrDefault(exp => exp.LodgingId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Lodgingphoto)
                .Load();

            foreach (var link in Exp.Lodgingphoto)
            {
                System.Console.WriteLine(link.Id);
                links.Add(link.Id);

            }
            return links;
        }
    }
}
