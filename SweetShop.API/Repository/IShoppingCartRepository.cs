using System;
using System.Collections.Generic;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Cake cake, int amount);
        int RemoveToCart(Cake cake);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
    }
}