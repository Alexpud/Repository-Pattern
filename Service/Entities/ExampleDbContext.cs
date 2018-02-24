using Microsoft.EntityFrameworkCore;

namespace Service.Entities
{
    public class ExampleDbContext : DbContext
    {
        public DbSet<ExampleEntity> ExampleEntities { get; set; }
        
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options): base(options)
        {
            
        }
    }
}