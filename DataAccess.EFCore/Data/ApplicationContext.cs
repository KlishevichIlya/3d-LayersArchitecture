using Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
           modelBuilder.Entity<Developer>()
                .HasOne(u => u.CurrentProject)
                .WithMany(u => u.CurrentDevelopers)
                .OnDelete(DeleteBehavior.SetNull)
                    .HasForeignKey(p => p.CurrentProjectId);

            modelBuilder.Entity<WorkHistory>()
                    .HasKey(u => new { u.PreviousDeveloperId, u.PreviousProjectId });
            modelBuilder.Entity<WorkHistory>()
                .HasOne(u => u.Developer)
                .WithMany(u => u.PreviousProjects)
                .HasForeignKey(u => u.PreviousDeveloperId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<WorkHistory>()
                .HasOne(u => u.Project)
                .WithMany(u => u.PreviousDevelopers)
                .HasForeignKey(u => u.PreviousProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Developer>()
            //    .HasMany(u => u.PreviousProjects)
            //    .WithMany(u => u.PreviousDevelopers)
            //    .UsingEntity(u => u.ToTable("WorkHistory"));


            base.OnModelCreating(modelBuilder);
        }
    }
}