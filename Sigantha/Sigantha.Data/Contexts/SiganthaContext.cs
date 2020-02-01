using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sigantha.Data.Entities;

namespace Sigantha.Data.Contexts
{
    public class SiganthaContext : DbContext
    {
        public DbSet<Timeline> Timelines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sigantha.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timeline>(ConfigureTimelines);
        }

        private void ConfigureTimelines(EntityTypeBuilder<Timeline> entity)
        {
            entity.ToTable("Timelines");

            entity.HasKey(s => s.Id);

            entity.Property(s => s.Name)
                .IsRequired();

            entity.HasIndex(s => s.Name);
        }
    }
}
