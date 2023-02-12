using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.View;
using Microsoft.AspNetCore.Identity;

namespace apiProjetoFinaceiro.Model.Mapping
{
    public static class MovimentacaoFinanceiraMapping
    {
        public static MovimentacaoFinanceiraViewModel ParaViewModel(this MovimentacaoFinanceira movimentacaoFinaceira, IdentityUser user)
        {
            return new MovimentacaoFinanceiraViewModel
            {
                Id = movimentacaoFinaceira.Id,
                NomeUsuario=user.UserName,
                DatamovimentacaoEntrada=movimentacaoFinaceira.DatamovimentacaoEntrada,
                ValorMovimentacao=movimentacaoFinaceira.ValorMovimentacao,
                TipoOperacao=movimentacaoFinaceira.TipoMovimentacao.TipoOperacao.ToString(),
                TipoMovimentacaoDescriscao=movimentacaoFinaceira.TipoMovimentacao.TipoDescriscao,
                Situacao=movimentacaoFinaceira.Situacao,
            
               

            };
        }
    }
}
