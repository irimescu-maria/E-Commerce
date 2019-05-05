using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SweetShop.API.Data;
using SweetShop.API.Models;
using SweetShop.API.UnitOfWork;

namespace SweetShop.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public OrderRepository(DataContext context,
                               IUnitOfWork unitOfWork,
                               IShoppingCartRepository shoppingCartRepository)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCartRepository.GetShoppingCartItems();

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    CakeId = item.Cake.Id,
                    OrderId = order.Id,
                    Price = item.Cake.Price
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _unitOfWork.SaveAll();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
           return await _context.Orders.Include(c=>c.OrderDetails).ToListAsync();
        }
    }
}