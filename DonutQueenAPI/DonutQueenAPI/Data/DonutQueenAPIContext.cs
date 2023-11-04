using DonutQueenAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;

namespace DonutQueenAPI.Data
{
    public class DonutQueenAPIContext : DbContext
    {
        public DbSet<Donut> Donuts { get; set; } = default!;

        public DonutQueenAPIContext(DbContextOptions<DonutQueenAPIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Donut>().ToTable("Donut");
        }
    }
}