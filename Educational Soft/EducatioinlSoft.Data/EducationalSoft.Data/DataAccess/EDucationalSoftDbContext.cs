using EducationalSoft.Model.Entities;
using System.Data.Entity;

namespace EducationalSoft.Data.DataAccess
{
    public class EducationalSoftDbContext: DbContext
    {
        public EducationalSoftDbContext():base("name = EductionalSoft.ConnectionString")  { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("UserRole");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}