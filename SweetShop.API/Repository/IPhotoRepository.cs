using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetAll();
        Task<Photo> Get(int id);
        bool Update(Photo photo);
        Task Create(IFormFile  photo);
        Task Delete(int id);
    }
}