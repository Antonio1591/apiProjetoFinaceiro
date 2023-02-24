using apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;

namespace apiProjetoFinaceiro.services
{
    public interface IIdentityUsuarioServices
    {
        Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest input);

        Task<UsuarioLoginResponse> Login(UsuarioLoginRequet usuarioLogin);

        Task<UsuarioAlterarSenhaResponse> ChangePassword(UsuarioAlterarSenhaRequest model);
    }
}
