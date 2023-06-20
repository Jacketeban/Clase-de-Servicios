using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;
namespace SchoolAPI.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                
        }

        public DbSet<Student> Students { get; set; }
    }
}
