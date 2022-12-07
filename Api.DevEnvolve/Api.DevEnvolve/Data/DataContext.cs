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
        public virtual DbSet<Demanda> Demanda { get; set; }
        public virtual DbSet<CandidatarDemanda> CandidatoDemanda { get; set; }
        public virtual DbSet<PlanoEmpresa> PlanoEmpresa { get; set; }
        public virtual DbSet<PlanoFreelancer> PlanoFreelancer { get; set; }
        public virtual DbSet<PlanosDevEnvolve> PlanosDevEnvolve { get; set; }
        public virtual DbSet<UsuarioToken> UsuarioToken { get; set; }

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
            modelBuilder.Entity<Freelancer>(x => x.ToTable("Freelancer").HasOne(y => y.endereco).WithOne(w => w.freelancer).HasForeignKey<EnderecoFreelancer>(b => b.idFreelancer));
            modelBuilder.Entity<Freelancer>(x => x.ToTable("Freelancer").HasOne(y => y.planoFreelancer).WithOne(w => w.freelancer).HasForeignKey<PlanoFreelancer>(b => b.idFreelancer));
            modelBuilder.Entity<Empresa>(x => x.ToTable("Empresa").HasOne(y => y.endereco).WithOne(w => w.Empresa).HasForeignKey<EnderecoEmpresa>(b => b.idEmpresa));
            modelBuilder.Entity<Empresa>(x => x.ToTable("Empresa").HasOne(y => y.planoEmpresa).WithOne(w => w.Empresa).HasForeignKey<PlanoEmpresa>(b => b.idEmpresa));
            modelBuilder.Entity<EnderecoEmpresa>(x => x.ToTable("EnderecoEmpresa"));
            modelBuilder.Entity<EnderecoFreelancer>(x => x.ToTable("EnderecoFreelancer"));
            modelBuilder.Entity<Usuario>(x => x.HasNoKey());
            modelBuilder.Entity<UsuarioToken>(x => x.HasNoKey());
            modelBuilder.Entity<Demanda>(x => x.ToTable("Demanda"));
            modelBuilder.Entity<CandidatarDemanda>(x => x.ToTable("CandidatoDemanda"));
            modelBuilder.Entity<PlanoEmpresa>(x => x.ToTable("PlanosEmpresa"));
            modelBuilder.Entity<PlanoFreelancer>(x => x.ToTable("PlanosFreelancer"));
            modelBuilder.Entity<PlanosDevEnvolve>(x => x.ToTable("PlanosDevEnvolve"));
        }
    }
}