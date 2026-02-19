using BerkayShop.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace BerkayShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CommentContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<UserComment> UserComments { get; set; }

    }
}
