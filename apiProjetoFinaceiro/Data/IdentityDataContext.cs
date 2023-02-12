using apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class IdentityDataContext: IdentityDbContext
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasData(
                   new IdentityRole { Name = "VIP", NormalizedName = "VIP", Id = "E2AFAC93-D1E2-4A09-A860-E38F735519F1" },
                   new IdentityRole { Name = "GRATUITO", NormalizedName = "GRATUITO", Id = "90EE101C-63B2-4F5C-B0DF-C198DDCB8A9E" }
                );
            });
        }
    }
    
}
