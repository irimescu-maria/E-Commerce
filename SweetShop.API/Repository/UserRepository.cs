using System.Threading.Tasks;
using SweetShop.API.Data;
using SweetShop.API.Models;

namespace SweetShop.API.Repository
{
    public class UserRepository: IUserRepository
    {
           private readonly DataContext _context;

         public UserRepository(DataContext context)
         {
             _context = context;
         }

        public Task<User> GetUsers(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}