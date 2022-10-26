using DataLayer.Data;
using DataLayer.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.RepInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepImplementation
{
    public class HostRepository : IHostRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<Hote> genericRepoHost;

        public HostRepository(ApplicationDbContext dbContext, IGenericRepository<Hote> _GenericRepoHost)
        {
           _dbContext = dbContext;
           genericRepoHost = _GenericRepoHost;
        }

        public async Task<string> Delete(Hote entity)
        {
            try
            {
                await genericRepoHost.DeleteAsync(entity.Id);
            }
            catch (Exception)
            {
                return "fail";

            }
            return "success";
        }

        public async Task<Hote> FindByEmail(string mail)
        {
            var user = await _dbContext.Hosts.SingleAsync(x => x.Email == mail);
            _dbContext.Entry(user);
            return user;
        }

        public IEnumerable<Hote> GetAllHotesAsync()
        {
            var User = _dbContext.Hosts.Where(User => User.Id != "" & User.Type != null);

            return User;
        }

        public async Task<Hote> GetHoteDetailsAsync(string id)
        {
            var User = await _dbContext.Hosts.SingleAsync(User => User.Id == id);

            _dbContext.Entry(User);

            return User;
        }
        public  IEnumerable<Hote> GetHostEnAttente()
        {
            var exp =  _dbContext.Hosts
                                            .Where(p => p.Verified.StartsWith("En Attente"));
            return exp;
        }
        public  IEnumerable<Hote> GetHostValidations()
        {
            var exp =  _dbContext.Hosts
                                            .Where(p => p.Verified.EndsWith("Valid") && p.Type != null);
            return exp;
        }

        public async Task<IEnumerable<Experience>> GetActiveExperiences()
        {
            var exp = await _dbContext.Experience
                                            .Where(p => p.ExperienceStatus.StartsWith("Active")).ToListAsync();
            return exp;
        }

        public async Task PutHostAsync(string id, Hote entity)
        {
            var user = await _dbContext.Hosts.SingleAsync(user => user.Id == entity.Id);
            _dbContext.Entry(user).State = EntityState.Detached;
            _dbContext.Entry(entity).State = EntityState.Modified;
            try
            {
                _dbContext.User.Update(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        public async Task PutHoteAsync(string id, JsonPatchDocument entity)
        {
            var User = await _dbContext.Hosts.SingleAsync(User => User.Id == id);
            if(User != null)
            {
                entity.ApplyTo(User);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Hote> GetIndividualHosts()
        {
            var exp = _dbContext.Hosts
                                            .Where(p => p.Type.StartsWith("individual"));
            return exp;
        }

        public IEnumerable<Hote> GetOragnaisationsHosts()
        {
            var exp = _dbContext.Hosts
                                            .Where(p => p.Type.StartsWith("organisation"));
            return exp;
        }
    }
}
