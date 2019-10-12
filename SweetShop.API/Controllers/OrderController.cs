using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetShop.API.Repository;

namespace SweetShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        //GET: api/order
        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            var orders = await _orderRepository.GetAll();
            return Ok(orders);
        }
    }
}