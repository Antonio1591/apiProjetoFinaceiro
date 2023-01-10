using apiProjetoFinaceiro.Model.Domain;
using Microsoft.EntityFrameworkCore;
namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Cidade> cidade { get; set; }
        public DbSet<Bairro> bairro { get; set; }
        public DbSet<MovimentacaoFinanceira> movimentacaoFinaceira { get; set; }
        public DbSet<TipoMovimentacao> tipoMovimentacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        }
    }

}
