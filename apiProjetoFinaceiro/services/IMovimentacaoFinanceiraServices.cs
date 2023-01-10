using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.Model;

namespace apiProjetoFinaceiro.services
{
    public interface IMovimentacaoFinanceiraServices
    {
        Task<RespostaApi<MovimentacaoFinanceiraViewModel>> NovaMovimentacao(MovimentacaoFinaceiraInputModel movimentacaoInputModel);
        Task<RespostaApi<MovimentacaoFinanceiraViewModel>> AtualizarMovimentacao(MovimentacaoFinaceiraInputModel movimentacaoInputModel);
        IEnumerable<MovimentacaoFinanceiraViewModel> BuscarMovimentacao();
    }
}
