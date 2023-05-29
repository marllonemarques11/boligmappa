using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;

namespace DT.Infra.Repository
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // options.UseNpgsql(_configuration.GetConnectionString(@"Server=localhost;Port=5432;User Id=postgres;Password=pgadmin@1234;Database=dummydb;"));
            options.UseNpgsql(_configuration.GetConnectionString(@"Host=localhost; Database=dummydb; Username=postgres; Password=pgadmin@1234"));
        }

        // public DbSet<User> Users { get; set; }
        // public DbSet<Post> Post { get; set; }
    }
}