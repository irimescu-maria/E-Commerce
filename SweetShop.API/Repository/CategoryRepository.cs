using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SweetShop.API.Data;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Category category)
        {
            if(category == null)
            {
                throw new ArgumentNullException();
            }

            await _context.Categories.AddAsync(category);
        }

        public async Task Delete(int id)
        {
            var categoryToDelete = await Get(id);
            _context.Categories.Remove(categoryToDelete);
        }

        public async Task<Category> Get(int id)
        {
           return await _context.Categories.Include(x=>x.Cakes).FirstOrDefaultAsync(c=>c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
           return await _context.Categories.Include(c=>c.Cakes).ToListAsync();
        }

        public bool Update(Category category)
        {
            if(category == null){
                throw new ArgumentNullException();
            }

            _context.Categories.Update(category);
            return true;
        }
    }
}