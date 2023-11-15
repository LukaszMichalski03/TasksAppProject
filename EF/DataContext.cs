using Microsoft.EntityFrameworkCore;
using TasksProject.DTOs;

namespace TasksProject.EF
{
    public class DataContext : DbContext
    {
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<TaskDTO> Tasks { get; set; }
        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\Local;Database=TaskDatabaseTest;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1 - *
            modelBuilder.Entity<TaskDTO>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
