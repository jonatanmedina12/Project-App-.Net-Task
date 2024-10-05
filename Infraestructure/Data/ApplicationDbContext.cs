using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Tareas> Tareas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tareas>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tareas)
                .HasForeignKey(t => t.IdUser);
        }
    }
}
