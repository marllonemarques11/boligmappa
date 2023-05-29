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
        // protected readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            // _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // options.UseNpgsql(_configuration.GetConnectionString(@"Server=localhost;Port=5432;User Id=postgres;Password=pgadmin@1234;Database=dummydb;"));
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>();
            modelBuilder.Entity<Post>();
        }
    }
}