using Application.Models;
using Application.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class ApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Archive> Archived { get; set; }
        public DbSet<Primary> Primaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Login: dbPostgre
            //Senha: okdsmudar
            optionsBuilder.UseNpgsql(
                "Host=localhost;Database=dbPostgre;Username=dbPostgre;Password=okdsmudar"
                );
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().HasData(Log.ObterDados());
            modelBuilder.Entity<User>().HasData(User.ObterDados());
        }
    }
}
