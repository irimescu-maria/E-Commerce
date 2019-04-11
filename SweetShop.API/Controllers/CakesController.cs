using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetShop.API.Models;
using SweetShop.API.Repository;

namespace SweetShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController: ControllerBase
    {
        private readonly ISweetShopRepository _repo;

        public CakesController(ISweetShopRepository repo)
        {
            _repo = repo;
        }

        //GET: api/cakes
        [HttpGet]
        public async Task<IActionResult> GetCakes(){
            var cakes = await _repo.GetAll();
            return Ok(cakes);
        }

        //GET: api/cakes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cake>> GetCake(int id){
            var cake = await _repo.Get(id);

            if(cake == null)
                return NotFound();

            return cake;
        }

        //POST: api/cakes
        [HttpPost]
        public async Task<ActionResult<Cake>> Create(Cake cake)
        {
            _repo.Add(cake);
          
          if(await _repo.SaveAll())
            return Ok();

        return BadRequest("Failed to add a cake");
        }

        //PUT: api/cakes/{id}
        [HttpPut]
        public async Task<ActionResult<Cake>> Update([FromBody]Cake cake, int id)
        {
            if(id == cake.Id)
                return BadRequest();

            _repo.Update(cake);
            await _repo.SaveAll();
            return NoContent();
        }
    }
}