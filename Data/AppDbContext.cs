using Curso_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso_Entity.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Category> Category { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = TI-ELTONGAS\\SQLEXPRESS; Initial Catalog = Blog; Integrated Security = True; Encrypt = False");
        }
    }
}