using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetShop.API.Repository;

namespace SweetShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ICakeRepository _cakeRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartController(ICakeRepository cakeRepository,
                                    IShoppingCartRepository shoppingCartRepository )
        {
            _cakeRepository = cakeRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        //GET: api/shoppingcart
          [HttpGet]
        public ActionResult GetCartItems()
        {
            var items = _shoppingCartRepository.GetShoppingCartItems();
            return Ok(items);
        }

        //POST: api/shoppingCart/{id}
        [HttpPost("{id}")]
        public async Task<RedirectToActionResult> AddToShoppingCart(int id) 
        {
            var selectedCake = await _cakeRepository.Get(id);

            if(selectedCake != null) 
            {
                _shoppingCartRepository.AddToCart(selectedCake, 1);
            }

            return RedirectToAction("GetCartItems");
        }

        //DELETE: api/shoppingCart/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveFromShoppingCart(int id)
        {
            var selectedCake = await _cakeRepository.Get(id);

            
            if(selectedCake == null) 
            {
                throw new ArgumentNullException();
            }
             _shoppingCartRepository.RemoveToCart(selectedCake);
            return Ok();
        }
    }
}