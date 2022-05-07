using Microsoft.EntityFrameworkCore;
using ParisTaxiFare.RideAPI.Data.Dao;

namespace ParisTaxiFare.RideAPI.Data
{
    public partial class RideDbContext : DbContext
    {
        public RideDbContext()
        {
        }

        public RideDbContext(DbContextOptions<RideDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RideDao> Rides { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RideDao>(entity =>
            {
                entity.ToTable("ride");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
