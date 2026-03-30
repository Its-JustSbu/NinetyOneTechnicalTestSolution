using Microsoft.EntityFrameworkCore;
using NinetyOneTechnicalTestSolution.Models.DTOs;

namespace NinetyOneTechnicalTestSolution.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Scores> Scores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Scores>((entity) =>
            {
                entity.HasKey(e => e.Id);
            });
        }

    }
}
