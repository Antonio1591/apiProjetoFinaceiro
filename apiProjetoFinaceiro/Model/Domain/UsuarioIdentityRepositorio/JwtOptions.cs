using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;

namespace apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio
{
    public class JwtOptions
    {
       
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public SigningCredentials signingCredentials{ get; set; }
        public double Expiration { get; set; }
    }
}
