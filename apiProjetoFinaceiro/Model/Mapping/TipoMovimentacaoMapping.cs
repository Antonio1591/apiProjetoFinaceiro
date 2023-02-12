using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.View;

namespace apiProjetoFinaceiro.Model.Mapping
{
    public static class TipoMovimentacaoMapping
    {
        public static TipoMovimentacaoViewModel ParaViewModel(this TipoMovimentacao tipoMovimentacao)
        {

            return new TipoMovimentacaoViewModel
            {
                TipoDescriscao = tipoMovimentacao.TipoDescriscao,
                TipoOperacao = tipoMovimentacao.TipoOperacao.ToString(),
                Situacao = tipoMovimentacao.Situacao.ToString(),
            };
        }
    }
}
