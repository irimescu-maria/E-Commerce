using System.IO;
using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SweetShop.API.Data;
using SweetShop.API.Models;
using SweetShop.API.UnitOfWork;
using static System.Net.Mime.MediaTypeNames;

namespace SweetShop.API.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext _context;

        public PhotoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(IFormFile photo)
        {
            if (photo == null)
            {
                throw new ArgumentNullException();
            }
            var uploadFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
            if (!Directory.Exists(uploadFilesPath))
                Directory.CreateDirectory(uploadFilesPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            var filePath = Path.Combine(uploadFilesPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
        //     var newPhoto = new Photo { Name = fileName };
        //     await _context.Photos.AddAsync(newPhoto);
        //    await context.SaveChangesAsync();   
        //     if(photo.Length> 0) {
        //         string fileName = photo.FileName;
        //         string extension = Path.GetExtension(fileName);
        //             if (extension == ".png" || extension == ".jpg")
        //         {
        //             //4 set the path where file will be copied
        //             string filePath = Path.GetFullPath(
        //                 Path.Combine(Directory.GetCurrentDirectory(), 
        //                                             "UploadedFiles"));
        //             //5 copy the file to the path
        //             using (var fileStream = new FileStream(
        //                 Path.Combine(filePath, fileName), 
        //                                FileMode.Create))
        //             {
        //                 await photo.CopyToAsync(fileStream);
        //            }
        //         }
        //         else
        //         {
        //             throw new Exception("File must be either .png or .JPG");
        //         }
        //     }
        //     using (var stream = photo.OpenReadStream())
        //     {
        //         var photoToUpload = new Photo()
        //         {
        //             Name = photo.FileName,

        //             Length = (int)stream.Length,
        //             Width = 450,
        //             Height = 450,
        //             ContentType = photo.ContentType
        //         };
        //         await _context.Photos.AddAsync(photoToUpload);
        //     }
        }

        public async Task Delete(int id)
        {
            var photoToDelete = await Get(id);
            _context.Photos.Remove(photoToDelete);
        }

        public async Task<Photo> Get(int id)
        {
            return await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Photo>> GetAll()
        {
            return await _context.Photos.ToListAsync();
        }

        public bool Update(Photo photo)
        {
            if (photo == null)
            {
                throw new ArgumentNullException();
            }

            _context.Photos.Update(photo);
            return true;
        }
    }
}