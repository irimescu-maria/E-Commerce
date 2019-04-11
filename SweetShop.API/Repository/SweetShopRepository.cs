using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetShop.API.Data;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public class SweetShopRepository : ISweetShopRepository
    {
        private readonly DataContext _context;

        public SweetShopRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Cake> Get(int id)
        {
            return await _context.Cakes
                .Where(c=>c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cake>> GetAll()
        {
            return await _context.Cakes.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
         return await _context.SaveChangesAsync() > 0   ;
        }

        public bool Update<T>(T entity) where T : class
        {
         var updatedEntity =  _context.Update(entity);
         _context.SaveChanges();
         return true;
        }
    }
}