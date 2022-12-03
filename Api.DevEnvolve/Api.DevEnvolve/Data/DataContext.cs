using Api.DevEnvolve.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.DevEnvolve.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Freelancer> Feelancer { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<EnderecoEmpresa> EnderecoEmpresa { get; set; }
        public virtual DbSet<EnderecoFreelancer> EnderecoFreelancer { get; set; }

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
            modelBuilder.Entity<Empresa>(x => x.ToTable("Empresa"));
            modelBuilder.Entity<EnderecoEmpresa>(x => x.ToTable("EnderecoEmpresa"));
            modelBuilder.Entity<EnderecoFreelancer>(x => x.ToTable("EnderecoFreelancer"));
            modelBuilder.Entity<Usuario>(x => x.HasNoKey());
        }
    }
}