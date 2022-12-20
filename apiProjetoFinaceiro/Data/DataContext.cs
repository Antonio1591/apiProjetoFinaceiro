using apiProjetoFinaceiro.Model.ClasseDbSet;
using apiProjetoFinaceiro.Model.Domain;
using Microsoft.EntityFrameworkCore;
namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<UsuarioDbSet> usuario { get; set; }
        public DbSet<Cidade> cidade { get; set; }
        public DbSet<Bairro> bairro { get; set; }

    }

}
