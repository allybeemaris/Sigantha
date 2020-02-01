using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sigantha.Data.Entities;

namespace Sigantha.Data.Contexts
{
    public class SiganthaContext : DbContext
    {
        public DbSet<Timeline> Timelines { get; set; }
        public DbSet<Legacy> Legacies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sigantha.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timeline>(ConfigureTimelines)
                .Entity<Legacy>(ConfigureLegacies);
        }

        private void ConfigureLegacies(EntityTypeBuilder<Legacy> entity)
        {
            entity.ToTable("Legacies");

            entity.HasKey(s => s.Id);

            entity.Property(s => s.Name)
                .IsRequired();
            entity.Property(s => s.SymbolPath)
                .IsRequired();
            entity.Property(s => s.Created)
                .IsRequired();
            entity.Property(s => s.Modified)
                .IsRequired();

            entity.HasIndex(s => s.Name);

            entity.HasOne(s => s.Timeline)
                .WithMany(s => s.Legacies);
        }

        private void ConfigureTimelines(EntityTypeBuilder<Timeline> entity)
        {
            entity.ToTable("Timelines");

            entity.HasKey(s => s.Id);

            entity.Property(s => s.Name)
                .IsRequired();
            entity.Property(s => s.Created)
                .IsRequired();
            entity.Property(s => s.Modified)
                .IsRequired();

            entity.HasIndex(s => s.Name);
        }
    }
}
