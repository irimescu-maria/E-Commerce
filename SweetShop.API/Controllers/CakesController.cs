using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetShop.API.Models;
using SweetShop.API.Repository;
using SweetShop.API.UnitOfWork;

namespace SweetShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController: ControllerBase
    {
        private readonly ICakeRepository _cakeRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CakesController(ICakeRepository cakeRepo,
                               IUnitOfWork unitOfWork)
        {
            _cakeRepo = cakeRepo;
            _unitOfWork = unitOfWork;
        }

        //GET: api/cakes
        [HttpGet]
        public async Task<ActionResult> GetCakes()
        {
            var cakes = await _cakeRepo.GetAll();
            return Ok(cakes);
        }

        //GET: api/cakes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cake>> GetCake(int id)
        {
            var cake = await _cakeRepo.Get(id);

            if(cake == null)
                return NotFound();

            return cake;
        }

        // //POST: api/cakes
        [HttpPost]
        public async Task<ActionResult<Cake>> Create(Cake cake)
        {
            await _cakeRepo.Create(cake);

            if(await _unitOfWork.SaveAll())
                  return Ok();

            return BadRequest("Failed to create cake");

        }

        //PUT: api/cakes/{id}
        [HttpPut("{id}")]
        public  IActionResult Update(Cake cake, int id)
        {
            if(id != cake.Id)
                return BadRequest();

            _cakeRepo.Update(cake);
            _unitOfWork.SaveAll();

            return NoContent();
        }

        //DELETE: api/cakes/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           await _cakeRepo.Delete(id);
           if(await _unitOfWork.SaveAll())
           return Ok();
           return BadRequest("Failed to delete cake");
        }
    }
}