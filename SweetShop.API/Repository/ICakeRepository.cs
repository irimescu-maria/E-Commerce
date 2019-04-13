using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweetShop.API.Data;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public interface ICakeRepository
    {
        Task<IEnumerable<Cake>> GetAll();
        Task<Cake> Get(int id);
        bool Update(Cake cake);
        Task Create(Cake cake);
      Task Delete(int id);
    }
}