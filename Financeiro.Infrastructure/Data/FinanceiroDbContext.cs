using Microsoft.EntityFrameworkCore;
using Financeiro.Domain.Entidades;

namespace Financeiro.Infrastructure.Data
{
    public class FinanceiroDbContext : DbContext
    {
        public FinanceiroDbContext(DbContextOptions<FinanceiroDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<LancamentoXtransacao> LancamentosXtransacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ChavesPrimarias
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Banco>()
                .HasKey(b => b.IdBanco);

            modelBuilder.Entity<Conta>()
                .HasKey(c => c.IdConta);

            modelBuilder.Entity<Lancamento>()
                .HasKey(l => l.IdLancamento);

            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.IdCategoria);

            modelBuilder.Entity<Transacao>()
                .HasKey(t => t.IdTransacao);

            modelBuilder.Entity<LancamentoXtransacao>()
                .HasKey(lt => lt.Id);
            #endregion

            #region Relacionamentos
            modelBuilder.Entity<Conta>()
                .HasOne<Banco>()
                .WithMany()
                .HasForeignKey(c => c.IdBanco);

            modelBuilder.Entity<Conta>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(c => c.IdUsuario);

            modelBuilder.Entity<Lancamento>()
                .HasOne<Conta>()
                .WithMany()
                .HasForeignKey(l => l.IdConta);

            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.Categoria)
                .WithMany()
                .HasForeignKey(t => t.IdCategoria);

            modelBuilder.Entity<LancamentoXtransacao>()
                .HasOne<Lancamento>()
                .WithMany()
                .HasForeignKey(lt => lt.IdLancamento);

            modelBuilder.Entity<LancamentoXtransacao>()
                .HasOne<Transacao>()
                .WithMany()
                .HasForeignKey(lt => lt.IdTransacao);
            #endregion
        }
    }
}