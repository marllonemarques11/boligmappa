using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;
using DT.Domain.Entities;

namespace DT.Infra.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Todo> Todos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasMany(e => e.Posts)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.userId)
            .IsRequired();

            modelBuilder.Entity<User>()
            .HasMany(e => e.Todos)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.userId)
            .IsRequired();
        }
    }
}