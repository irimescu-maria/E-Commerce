using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public interface IOrderRepository
    {
         void CreateOrder(Order order);
    }
}