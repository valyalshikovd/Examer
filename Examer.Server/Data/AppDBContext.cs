using Examer.Server.Models;
using Microsoft.EntityFrameworkCore;
using Examer.Server.ModelConfigurations;

namespace Examer.Server.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {

            Console.WriteLine("контекст создался");
    
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new ProblemConfig());
        }
        public DbSet<Problem> Task { get; set; }
        public DbSet<Project> Project {  get; set; }


 

    }
}
