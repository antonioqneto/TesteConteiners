using Microsoft.EntityFrameworkCore;
using TesteConteiners.Data.Models;

namespace TesteConteiners.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conteiner> Conteiners { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurarRelacionamentos();
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void ConfigurarRelacionamentos(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conteiner>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(m => m.ClienteId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Movimentacao>()
                .HasOne<Conteiner>()
                .WithMany()
                .HasForeignKey(m => m.ConteinerId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nome = "Cliente 1" },
                new Cliente { Id = 2, Nome = "Cliente 2" },
                new Cliente { Id = 3, Nome = "Cliente 3" },
                new Cliente { Id = 4, Nome = "Cliente 4" }
            );

            modelBuilder.Entity<Conteiner>().HasData(
                new Conteiner { Id = 1, ClienteId = 1, NumeroIdentificao = "ABCD1234567", Tipo = ConteinerEnums.Tipo.Vinte, Status = ConteinerEnums.Status.Cheio, Categoria = ConteinerEnums.Categoria.Importacao },
                new Conteiner { Id = 2, ClienteId = 2, NumeroIdentificao = "BCDE6654321", Tipo = ConteinerEnums.Tipo.Quarenta, Status = ConteinerEnums.Status.Vazio, Categoria = ConteinerEnums.Categoria.Exportacao },
                new Conteiner { Id = 3, ClienteId = 2, NumeroIdentificao = "BCDE7654321", Tipo = ConteinerEnums.Tipo.Quarenta, Status = ConteinerEnums.Status.Cheio, Categoria = ConteinerEnums.Categoria.Importacao }
            );

            modelBuilder.Entity<Movimentacao>().HasData(
                new Movimentacao { Id = 1, ConteinerId = 1, Tipo = ConteinerEnums.TipoMovimentacao.Embarque, Inicio = new DateTime(2021, 1, 1), Fim = new DateTime(2021, 1, 2) },
                new Movimentacao { Id = 2, ConteinerId = 2, Tipo = ConteinerEnums.TipoMovimentacao.GateOut, Inicio = new DateTime(2021, 1, 3), Fim = new DateTime(2021, 1, 4) }
            );
        }
    }
}
