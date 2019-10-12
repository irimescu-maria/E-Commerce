using System.Net.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetShop.API.Data;
using SweetShop.API.Models;
using SweetShop.API.Repository;
using SweetShop.API.UnitOfWork;

namespace SweetShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };
        private readonly IHostingEnvironment _host;
        private readonly DataContext _context;
        private readonly IPhotoRepository _photoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PhotoController(IHostingEnvironment host, DataContext context,
                                IPhotoRepository photoRepository,
                                IUnitOfWork unitOfWork)
        {
            _context = context;
            _host = host;
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
        }
  

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile filesData)
        {
            if (filesData == null) return BadRequest("Null File");
            if (filesData.Length == 0)
            {
                return BadRequest("Empty File");
            }
            if (filesData.Length > 10 * 1024 * 1024) return BadRequest("Max file size exceeded.");
            if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(filesData.FileName).ToLower())) return BadRequest("Invalid file type.");
            var uploadFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
            if (!Directory.Exists(uploadFilesPath))
                Directory.CreateDirectory(uploadFilesPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(filesData.FileName);
            var filePath = Path.Combine(uploadFilesPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await filesData.CopyToAsync(stream);
            }
            var photo = new Photo
            {
                Name = fileName.ToString(),
                Data = fileName.LongCount().ToString(),

            };
            await _context.Photos.AddAsync(photo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // private readonly IPhotoRepository _photoRepository;
        // private readonly IUnitOfWork _unitOfWork;

        // public PhotoController(IPhotoRepository photoRepository,
        //                         IUnitOfWork unitOfWork)
        // {
        //     _photoRepository = photoRepository;
        //     _unitOfWork = unitOfWork;
        // }

        //GET: api/photo
        [HttpGet(Name = "GetPhotos")]
        public async Task<ActionResult> GetPhotos()
        {
            var photos = await _photoRepository.GetAll();
            return Ok(photos);
        }

        // //GET: api/photo/{id}
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Photo>> GetPhoto(int id)
        // {
        //     var photo = await _photoRepository.Get(id);

        //     if (photo == null)
        //         return NotFound();

        //     return photo;
        // }

        // //POST: api/photo
        // [HttpPost]
        // public async Task<ActionResult<Photo>> UploadPhoto([FromBody]IFormFile photo)
        // {
        //     await _photoRepository.Create(photo);

        //     if (await _unitOfWork.SaveAll())
        //         return Ok();

        //     return BadRequest("Failed to upload photo");
        // }

        //DELETE: api/photo/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _photoRepository.Delete(id);
            if (await _unitOfWork.SaveAll())
                return Ok();
            return BadRequest("Failed to delete photo");
        }
    }
}
