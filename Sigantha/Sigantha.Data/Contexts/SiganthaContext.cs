using Microsoft.EntityFrameworkCore;

using Sigantha.Data.Entities;

namespace Sigantha.Data.Contexts
{
    public class SiganthaContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sigantha.db");
    }
}
