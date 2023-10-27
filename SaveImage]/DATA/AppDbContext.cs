using Microsoft.EntityFrameworkCore;
using SaveImage_.Models;

namespace SaveImage_.DATA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Image> Images { get; set; }
    }
}
