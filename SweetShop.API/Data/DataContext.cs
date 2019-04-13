using Microsoft.EntityFrameworkCore;
using SweetShop.API.Models;

namespace SweetShop.API.Data
{
    public class DataContext: DbContext 
    {
        public DataContext(DbContextOptions options): base(options)
        { }

        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}