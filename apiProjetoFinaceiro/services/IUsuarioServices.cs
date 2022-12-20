using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;

namespace apiProjetoFinaceiro.services
{
    public interface IUsuarioServices
    {
        IEnumerable<UsuarioViewModel> ListaUsuarios();

        Task<UsuarioViewModel> Logim(LoginInputModel login);

        Task<UsuarioViewModel> ObterUsuarioPorId(int Id);

        Task<RespostaApi<UsuarioViewModel>> Create(UsuarioImputModel input);

        Task Update(UsuarioImputModel Usuario);

        Task Delete(int Id);
        Task<IEnumerable<CidadeViewModel>> BuscarCidades();
        Task<IEnumerable<BairroViewModel>> BuscarBairros();
    }
}
