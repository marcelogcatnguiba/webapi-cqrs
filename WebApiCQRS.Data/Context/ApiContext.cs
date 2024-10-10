using Microsoft.EntityFrameworkCore;
using WebApiCQRS.Domain.Entities;

namespace WebApiCQRS.Data.Context
{
    public class ApiContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("UserDb");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasData(
                    new Usuario("Marcos", 22) { Id = 1 },
                    new Usuario("Marcia", 19) { Id = 2 },
                    new Usuario("Lula", 65) { Id = 3 },
                    new Usuario("Chico", 78) { Id = 4 }
                );
        }
    }
}