using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.Context
{
    public class PsqlContext : DbContext
    {

        public PsqlContext() { }
        public PsqlContext(DbContextOptions<PsqlContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

    }
}