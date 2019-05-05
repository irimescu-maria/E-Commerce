using System.Collections.Generic;
using System.Threading.Tasks;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        Task<IEnumerable<Order>> GetAll();
    }
}