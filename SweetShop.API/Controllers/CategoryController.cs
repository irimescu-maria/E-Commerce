using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetShop.API.Models;
using SweetShop.API.Repository;
using SweetShop.API.UnitOfWork;

namespace SweetShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(IUnitOfWork unitOfWork,
                                 ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _unitOfWork = unitOfWork;
        }

        //GET: api/categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await _categoryRepo.GetAll();
            return Ok(categories);
        }

        //POST: api/categories
        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category category)
        {
            await _categoryRepo.Create(category);

            if (await _unitOfWork.SaveAll())
                return Ok();

            return BadRequest("Failed to create category");
        }

        //GET: api/categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepo.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        //DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryRepo.Delete(id);

            if (await _unitOfWork.SaveAll())
                return Ok();
            return BadRequest("Failed to delete category");
        }

        //PUT: api/categories/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Category category, int id)
        {
            await _categoryRepo.Delete(id);
            if (await _unitOfWork.SaveAll())
                return Ok();
            return BadRequest("Failed to delete cake");
        }
    }
}