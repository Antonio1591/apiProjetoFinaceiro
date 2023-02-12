using Microsoft.AspNetCore.Identity;

namespace apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio
{
    public class NiveisUsuarioIdentity:IdentityUser
    {
        public int Id { get; set; }
        public NiveisUsuarioEnum NiveisUsuario { get; set; }
    }
}
