using System.Threading.Tasks;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}