using Microsoft.EntityFrameworkCore;

namespace CoreProject.Data.Models
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer("server=DESKTOP-09OM028;database=Yasin_Top_NET_CORE_MVC_Project; integrated security=true");

        }

        // DESKTOP-09OM028

        public DbSet<Item> Items { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
