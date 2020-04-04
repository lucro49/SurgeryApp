using System.Collections.Generic;
using System.Threading.Tasks;
using SurgeryApp.API.Models;

namespace SurgeryApp.API.Data
{
    public interface ISurgeryRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById (int id);
    }
}