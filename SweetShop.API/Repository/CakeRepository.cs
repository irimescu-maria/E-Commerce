using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SweetShop.API.Data;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public class CakeRepository : ICakeRepository
    {
        private readonly DataContext _context;

        public CakeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Cake cake)
        {
            if(cake == null)
            {
                throw new ArgumentNullException();
            }

            await _context.Cakes.AddAsync(cake);

        }

        public async Task<Cake> Get(int id)
        {
            return await _context.Cakes.Include(p=>p.Photo).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cake>> GetAll()
        {
            return await _context.Cakes.ToListAsync();
        }

        public  bool Update(Cake cake)
        {
            if(cake == null)
            {
                throw new ArgumentNullException();
            }

             _context.Cakes.Update(cake);
             return true;

        }

        public async Task Delete(int id) 
        {
            var cakeToDelete = await Get(id);
            _context.Cakes.Remove(cakeToDelete);
        }
    }
}