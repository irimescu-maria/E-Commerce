using System;
using SweetShop.API.Data;
using SweetShop.API.Models;
using SweetShop.API.UnitOfWork;

namespace SweetShop.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly ShoppingCart _shoppingCart;
        private readonly IUnitOfWork _unitOfWork;

        public OrderRepository(DataContext context,
                                ShoppingCart shoppingCart,
                                IUnitOfWork unitOfWork)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _unitOfWork = unitOfWork;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
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
    }
}