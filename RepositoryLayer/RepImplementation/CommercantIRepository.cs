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
    public class CommercantIRepository : ICommercantRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<Commercant> genericRepoCommercant;

        public CommercantIRepository(ApplicationDbContext dbContext, IGenericRepository<Commercant> _GenericRepoCommercant)
        {
            _dbContext = dbContext;
            genericRepoCommercant = _GenericRepoCommercant;
        }
        public async Task<string> Delete(Commercant entity)
        {
            try
            {

                await genericRepoCommercant.DeleteAsync(entity.Id);
            }
            catch (Exception)
            {
                return "fail";

            }
            return "success";
        }

        public async Task<Commercant> FindByEmail(string mail)
        {
            var user = await _dbContext.Commercants.SingleAsync(x => x.Email == mail);
            _dbContext.Entry(user);
            return user;
        }

        public IEnumerable<Commercant> GetAllCommercantsAsync()
        {
            var User = _dbContext.Commercants.Where(User => User.Id != "" );

            return User;
        }
        public IEnumerable<Commercant> GetCommEnAttente()
        {
            var exp = _dbContext.Commercants
                                            .Where(p => p.Verified.StartsWith("En Attente"));
            return exp;
        }
        public IEnumerable<Commercant> GetCommValidations()
        {
            var exp = _dbContext.Commercants
                                            .Where(p => p.Verified.EndsWith("Valid"));
            return exp;
        }


        public async Task<Commercant> GetCommercantDetailsAsync(string id)
        {
            var User = await _dbContext.Commercants.SingleAsync(User => User.Id == id);

            _dbContext.Entry(User);

            return User;
        }

        public async Task PutCommercantAsync(string id, Commercant entity)
        {
            var user = await _dbContext.Commercants.SingleAsync(user => user.Id == entity.Id);
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

        public IEnumerable<Commercant> GetAllTransportComm()
        {
            var exp = _dbContext.Commercants
                                          .Where(p => p.TypeService.EndsWith("Transport"));
            return exp;
        }

        public IEnumerable<Commercant> GetAllLodgingComm()
        {
            var exp = _dbContext.Commercants
                                          .Where(p => p.TypeService.EndsWith("Lodging"));
            return exp;
        }

        public IEnumerable<Commercant> GetAllFoodComm()
        {
            var exp = _dbContext.Commercants
                                          .Where(p => p.TypeService.EndsWith("Restaurant"));
            return exp;
        }
    }
}
