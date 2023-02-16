using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.Model;

namespace apiProjetoFinaceiro.services
{
    public interface ITipoMovimentacaoServices
    {
        Task<RespostaApi<TipoMovimentacaoViewModel>> CadastroTipo(TipoMovimentacaoInputModel input);
        Task<RespostaApi<TipoMovimentacaoViewModel>> AtualizarTipo(TipoMovimentacaoInputModel input);
        IEnumerable<TipoMovimentacaoViewModel> BuscarTipos();
        Task<RespostaApi<TipoMovimentacaoViewModel>> ObterPorId(int Id);
    }
}
