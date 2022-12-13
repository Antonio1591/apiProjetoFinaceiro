using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;

namespace apiProjetoFinaceiro.services
{
    public interface IUsuarioServices
    {
        IEnumerable<UsuarioViewModel> ListaUsuarios();

        Task<UsuarioViewModel> Logim(Login login);

        Task<UsuarioViewModel> ObterUsuarioPorId(int Id);

        Task<UsuarioViewModel> Create(UsuarioImputModel input);

        Task Update(Usuario Usuario);

        Task Delete(int Id);
        Task<IEnumerable<CidadeViewModel>> BuscarCidades();
        Task<IEnumerable<BairroViewModel>> BuscarBairros();
    }
}
