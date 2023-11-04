using DonutQueen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DonutQueen.Data
{
    public class DonutQueenContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Donut> Donuts { get; set; } = default!;

        public DbSet<Winkel> Winkels { get; set; } = default!;

        public DonutQueenContext(DbContextOptions<DonutQueenContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Donut>().ToTable("Donut");
            modelBuilder.Entity<Winkel>().ToTable("Winkel");
        }
    }
}