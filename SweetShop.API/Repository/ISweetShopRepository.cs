using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public interface ISweetShopRepository
    {   

         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         bool Update<T>(T entity) where T: class;
         Task<IEnumerable<Cake>> GetAll();
         Task<Cake> Get(int id);
    }
}