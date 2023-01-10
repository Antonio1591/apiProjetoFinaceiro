namespace apiProjetoFinaceiro.Model.Domain
{
    public class TipoMovimentacao : Entidade
    {

        public TipoMovimentacao(TipoMovimentacaoEnum tipoOperacao, string tipoDescriscao, SituacaoEnum situacaoEnum)
        {

            if (string.IsNullOrEmpty(TipoOperacao.ToString()))
                AddErro("Informe o tipo da movimentação (E para entrada e S para saida");
            if (string.IsNullOrEmpty(TipoDescriscao))
                AddErro("Informe o nome da movimentação");
            if(!EhValido)
            TipoOperacao = tipoOperacao;
            TipoDescriscao = tipoDescriscao;
            SituacaoEnum = situacaoEnum;
        }

        public int id { get; set; }
        public TipoMovimentacaoEnum TipoOperacao { get; private set; }
        public string TipoDescriscao { get; private set; }
        public SituacaoEnum SituacaoEnum { get; private set; }
    }
}
