using Microsoft.AspNetCore.Mvc;
using SweetShop.API.Repository;

namespace SweetShop.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public OrderController(IOrderRepository orderRepository,
                                IShoppingCartRepository shoppingCartRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }
    }
}