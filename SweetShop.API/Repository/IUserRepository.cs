using System.Threading.Tasks;
using SweetShop.API.Data;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUsers(User user);
    }
}