using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingHubApp.API.Models;

namespace DatingHubApp.API.Data
{
    public interface IDatingRepository
    {
         void Add<T>(T entity) where T: class;

         void Delete<T>(T entity) where T : class;

         Task<bool> Saveall();

         Task<IEnumerable<User>> GetUsers();

         Task<User> GetUser(int id);


    }
}