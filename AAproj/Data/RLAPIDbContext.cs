using AAproj.Models;
using Microsoft.EntityFrameworkCore;

namespace AAproj.Data
{
    public class RLAPIDbContext : DbContext
    {
        public RLAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Register> Registers { get; set; }
    }
}
