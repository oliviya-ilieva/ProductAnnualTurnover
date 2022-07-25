using Microsoft.EntityFrameworkCore;
using ProductAnnualTurnover.Entities;

namespace ProductAnnualTurnover.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

   

    }
    
}
