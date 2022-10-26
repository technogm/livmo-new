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
    public class TransportExperienceRepository : ITransportExperienceRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<TransportExperience> _genericRepoExp;

        public TransportExperienceRepository(ApplicationDbContext dbContext, IGenericRepository<TransportExperience> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }
        public async Task<TransportExperience> DeleteTransportExperience(TransportExperience entity)
        {
            var exp = await _dbContext.TransportExperience.FindAsync(entity.TransportId);
            if (exp != null)
            {
                _dbContext.TransportExperience.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }

        public  async Task<TransportExperience> DeleteTransportExperience(Guid id)
        {
            var exp = await _dbContext.TransportExperience.FindAsync(id);
            if (exp != null)
            {
                _dbContext.TransportExperience.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<TransportExperience> FindTransportById(Guid id)
        {
            var exp = await _dbContext.TransportExperience
                           .SingleAsync(n => n.TransportId == id);
            _dbContext.Entry(exp);
            return exp;
        }

        public async Task<IEnumerable<TransportExperience>> GetSpecificTransportExperiences(Guid expId)
        {
            var exp = await _dbContext.TransportExperience
                                         //  .Include(u => u.Experience)
                                           .Where(p => p.ExperienceId == expId).ToListAsync();
            return exp;
        }

        public async Task<TransportExperience> InsertTransportExperience(TransportExperience entity)
        {
            await _dbContext.TransportExperience.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public List<string> GetAllTransportExperienceImagesLink(Guid expId)
        {
            var links = new List<string>();
            var Exp = _dbContext.TransportExperience.SingleOrDefault(exp => exp.TransportId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Transphoto)
                .Load();

            foreach (var link in Exp.Transphoto)
            {
                System.Console.WriteLine(link.Url);
                links.Add(link.Url);

            }
            return links;
        }

        public List<Guid> getAllTransportExpIDS(Guid expId)
        {
            var links = new List<Guid>();
            var Exp = _dbContext.TransportExperience.SingleOrDefault(exp => exp.TransportId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Transphoto)
                .Load();

            foreach (var link in Exp.Transphoto)
            {
                System.Console.WriteLine(link.Id);
                links.Add(link.Id);

            }
            return links;
        }
    }
}
