using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.Model;
using Microsoft.AspNetCore.Identity;

namespace apiProjetoFinaceiro.services
{
    public interface IMovimentacaoFinanceiraServices
    {
        Task<RespostaApi<MovimentacaoFinanceiraViewModel>> NovaMovimentacao(MovimentacaoFinanceiraInputModel movimentacaoInputModel);
        Task<RespostaApi<MovimentacaoFinanceiraViewModel>> AtualizarMovimentacao(MovimentacaoFinanceiraInputModel movimentacaoInputModel);
        IEnumerable<MovimentacaoFinanceiraViewModel> BuscarMovimentacao();
    }
}
