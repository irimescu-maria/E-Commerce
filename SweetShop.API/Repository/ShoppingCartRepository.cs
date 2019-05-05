using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SweetShop.API.Data;
using SweetShop.API.Models;
using SweetShop.API.Repository;
using SweetShop.API.UnitOfWork;

namespace SweetShop.API.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUnitOfWork _unitOfWork;
        private ShoppingCart _shoppingCart;

        private string ShoppingCartId { get; set; }
        public ShoppingCartRepository(DataContext dataContext,
                                    IUnitOfWork unitOfWork)
        {
            _dataContext = dataContext;
            _unitOfWork = unitOfWork;
        }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart() { ShoppingCartId = cartId };
        }
        public void AddToCart(Cake cake, int amount)
        {
            var shoppingCartItem = _dataContext.ShoppingCartItems
                                    .FirstOrDefault(s => s.Cake.Id == cake.Id
                                    && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Cake = cake,
                    Amount = 1
                };

                _dataContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _unitOfWork.SaveAll();
        }

        public int RemoveToCart(Cake cake)
        {
            var shoppingCartItem = _dataContext.ShoppingCartItems
                                 .FirstOrDefault(s => s.Cake.Id == cake.Id);

            var localAmount = 0;
            if (shoppingCartItem != null && shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                _dataContext.ShoppingCartItems.Remove(shoppingCartItem);
            }

            _unitOfWork.SaveAll();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _dataContext.ShoppingCartItems.Include(s => s.Cake).ToList();
        }

        public void ClearCart()
        {
            var cartItems = _dataContext.ShoppingCartItems
                                 .Where(s => s.ShoppingCartId == _shoppingCart.ShoppingCartId);

            _dataContext.ShoppingCartItems.RemoveRange(cartItems);

            _unitOfWork.SaveAll();
        }

         public decimal GetShoppingCartTotal()
        {
            var total = _dataContext.ShoppingCartItems
                                    .Where(c => c.ShoppingCartId == _shoppingCart.ShoppingCartId)
                                    .Select(c => c.Cake.Price * c.Amount).Sum();
            return total;
        }
    }
}