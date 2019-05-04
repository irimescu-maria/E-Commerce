using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SweetShop.API.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        
        public static ShoppingCart GetCart(IServiceProvider services)
        {
           ISession  session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart() { ShoppingCartId = cartId };
        }

    }
}