using System.Collections.Generic;
using System.Threading.Tasks;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> Get(int id);
        bool Update(Category category);
        Task Create(Category category);
        Task Delete(int id);
    }
}