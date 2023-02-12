using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.Model;
using Microsoft.AspNetCore.Identity;

namespace apiProjetoFinaceiro.services
{
    public interface IMovimentacaoFinanceiraServices
    {
        Task<RespostaApi<MovimentacaoFinanceiraViewModel>> NovaMovimentacao(MovimentacaoFinaceiraInputModel movimentacaoInputModel,IdentityUser user);
        Task<RespostaApi<MovimentacaoFinanceiraViewModel>> AtualizarMovimentacao(MovimentacaoFinaceiraInputModel movimentacaoInputModel);
        IEnumerable<MovimentacaoFinanceiraViewModel> BuscarMovimentacao(IdentityUser user);
    }
}
