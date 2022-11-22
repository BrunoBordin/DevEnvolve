using Api.DevEnvolve.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.DevEnvolve.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Freelancer> Feelancer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("DevEnvolve");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Freelancer>(x => x.ToTable("Freelancer"));
        }
    }
}