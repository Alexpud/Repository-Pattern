using Microsoft.EntityFrameworkCore;

namespace Service.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<ExampleEntity> ExampleEntities { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
    }
}