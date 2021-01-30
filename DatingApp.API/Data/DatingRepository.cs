using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {   
        public readonly DataContext _dbContext;
        public DatingRepository(DataContext dbContext)
        {
          _dbContext = dbContext;  
        }
        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        public async Task<User> GetUser(int Id)
        {
            var user = await _dbContext.Users.Include(p=> p.Photos).FirstOrDefaultAsync(x=> x.Id == Id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.Include(p=> p.Photos).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            if(await _dbContext.SaveChangesAsync()>0){
                return true;
            }

            return false;
        }
    }
}