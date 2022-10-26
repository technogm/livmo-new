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
   public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users> FindByEmail(string mail)
        {
            var user = await _dbContext.User.SingleAsync(x => x.Email == mail);
            _dbContext.Entry(user);
            return user;
        }

        public IEnumerable<Users> GetAllUserAsync()
        {
            var User = _dbContext.User.Where(User => User.Id != "");

            return User;
        }

        public async Task<Users> GetUserDetailsAsync(string id)
        {
            var User = await _dbContext.User.SingleAsync(User => User.Id == id);

            _dbContext.Entry(User);

            return User;
        }

        public async Task<bool> GetUserEmailValidation(string email)
        {
            var User = await _dbContext.User.SingleAsync(User => User.Email == email);

            return User.EmailConfirmed;
        }

        public async Task PutUserAsync(string id, Users entity)
        {
            var user = await _dbContext.User.SingleAsync(user => user.Id == entity.Id);
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
        public List<Guid> GetPhotoIdOfUser(string UserId)
        {
            var ID = new List<Guid>();
            var Exp = _dbContext.User.SingleOrDefault(exp => exp.Id == UserId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Photos)
                .Load();

            foreach (var id in Exp.Photos)
            {
                if (id.TypeFile.StartsWith("ProfilePic"))
                {
                    Console.WriteLine(id.Id);
                    ID.Add(id.Id);
                }  
            }
            return ID;
        }
        public List<Guid> GetCINidOfUser(string UserId)
        {
            var ID = new List<Guid>();
            var Exp = _dbContext.User.SingleOrDefault(exp => exp.Id == UserId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Photos)
                .Load();

            foreach (var id in Exp.Photos)
            {
                if (id.TypeFile.StartsWith("CIN Copy"))
                {
                    Console.WriteLine(id.Id);
                    ID.Add(id.Id);
                }
            }
            return ID;
        }
        public List<Guid> GetCADTransportidOfUser(string UserId)
        {
            var ID = new List<Guid>();
            var Exp = _dbContext.User.SingleOrDefault(exp => exp.Id == UserId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Photos)
                .Load();

            foreach (var id in Exp.Photos)
            {
                if (id.TypeFile.StartsWith("Transport"))
                {
                    Console.WriteLine(id.Id);
                    ID.Add(id.Id);
                }
            }
            return ID;
        }
        public List<Guid> GetRNEidOfUser(string UserId)
        {
            var ID = new List<Guid>();
            var Exp = _dbContext.User.SingleOrDefault(exp => exp.Id == UserId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Photos)
                .Load();

            foreach (var id in Exp.Photos)
            {
                if (id.TypeFile.StartsWith("RNEFile"))
                {
                    Console.WriteLine(id.Id);
                    ID.Add(id.Id);
                }
            }
            return ID;
        }
        public List<Guid> GetLicenceidOfUser(string UserId)
        {
            var ID = new List<Guid>();
            var Exp = _dbContext.User.SingleOrDefault(exp => exp.Id == UserId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Photos)
                .Load();

            foreach (var id in Exp.Photos)
            {
                if (id.TypeFile.StartsWith("Licence"))
                {
                    Console.WriteLine(id.Id);
                    ID.Add(id.Id);
                }
            }
            return ID;
        }

    }
}
