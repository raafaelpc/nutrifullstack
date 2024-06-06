using Microsoft.EntityFrameworkCore;
using nutriapi.Models;

namespace nutriapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BasalModel> BasalModels { get; set; }
    }
}
