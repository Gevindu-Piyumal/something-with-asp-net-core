using Microsoft.EntityFrameworkCore;
using Something.Models;

namespace Something.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<People>People { get; set; }
    }
}
