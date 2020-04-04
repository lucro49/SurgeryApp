using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurgeryApp.API.Models;

namespace SurgeryApp.API.Data
{
    public class SurgeryRepository : ISurgeryRepository
    {
        private readonly DataContext _dataContext;
        public SurgeryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dataContext.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _dataContext.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}