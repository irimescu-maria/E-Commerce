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
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Photo> Photos { get; set; }
        
    }
}