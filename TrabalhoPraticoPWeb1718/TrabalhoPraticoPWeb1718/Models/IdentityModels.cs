using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TrabalhoPraticoPWeb1718.Models.ModelosBD;

namespace TrabalhoPraticoPWeb1718.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeDaConta { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) {}

        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Crianca> Criancas { get; set; }
        public virtual DbSet<Instituicao> Instituicoes { get; set; }
        public virtual DbSet<Ensino> Ensinos { get; set; }
        public virtual DbSet<Disciplina> Disciplinas { get; set; }

        public virtual DbSet<InstituicaoAutorizacao> InstituicoesAutorizacao { get; set; }
        public virtual DbSet<PaiAutorizacao> PaisAutorizacao { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mudar os nomes das tabelas
            modelBuilder.Entity<Pai>().ToTable("Pais");
            modelBuilder.Entity<Crianca>().ToTable("Criancas");
            modelBuilder.Entity<Instituicao>().ToTable("Instituicoes");
            modelBuilder.Entity<Disciplina>().ToTable("Disciplinas");
            modelBuilder.Entity<Ensino>().ToTable("Ensinos");

            // Pais <-> Criancas - (1:N)
            modelBuilder.Entity<Pai>().HasMany<Crianca>(p => p.Criancas).WithRequired(c => c.Pai);
            modelBuilder.Entity<Crianca>().HasRequired<Pai>(c => c.Pai).WithMany(p => p.Criancas);

            // Criancas <-> Instituicoes - (N:1)
            modelBuilder.Entity<Crianca>().HasRequired<Instituicao>(c => c.Instituicao).WithMany(i => i.Criancas);
            modelBuilder.Entity<Instituicao>().HasMany<Crianca>(i => i.Criancas).WithRequired(c => c.Instituicao);

            // Criancas <-> Ensinos - (N:1)
            modelBuilder.Entity<Crianca>().HasRequired<Ensino>(c => c.Ensino).WithMany(e => e.Criancas);
            modelBuilder.Entity<Ensino>().HasMany<Crianca>(e => e.Criancas).WithRequired(i => i.Ensino);

            // Instituicoes <-> Ensinos - (M:N)
            modelBuilder.Entity<Instituicao>().HasMany<Ensino>(i => i.Ensinos).WithMany(e => e.Instituicoes);
            modelBuilder.Entity<Ensino>().HasMany<Instituicao>(e => e.Instituicoes).WithMany(i => i.Ensinos);

            // Disciplinas <-> Ensinos - (N:1)
            modelBuilder.Entity<Disciplina>().HasRequired<Ensino>(d => d.Ensino).WithMany(e => e.Disciplinas);
            modelBuilder.Entity<Ensino>().HasMany<Disciplina>(e => e.Disciplinas).WithRequired(d => d.Ensino);

            base.OnModelCreating(modelBuilder);
        }
    }
}