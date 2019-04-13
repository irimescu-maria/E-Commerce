using System.Threading.Tasks;

namespace SweetShop.API.UnitOfWork
{
    public interface IUnitOfWork
    {
         Task<bool> SaveAll();
    }
}