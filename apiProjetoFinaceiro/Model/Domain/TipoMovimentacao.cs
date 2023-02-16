namespace apiProjetoFinaceiro.Model.Domain
{
    public class TipoMovimentacao : Entidade
    {
        protected TipoMovimentacao(){}
        public TipoMovimentacao(Guid idUsuarioIdentity,TipoMovimentacaoEnum tipoOperacao, string tipoDescriscao, SituacaoEnum situacaoEnum)
        {

            if (string.IsNullOrEmpty(tipoOperacao.ToString()))
                AddErro("Informe o tipo da movimentação (E para entrada e S para saida");
            if (string.IsNullOrEmpty(tipoDescriscao))
                AddErro("Informe o nome da movimentação");
            if (!EhValido)
                return;
            IdUsuarioIdentity = idUsuarioIdentity;
            TipoOperacao = tipoOperacao;
            TipoDescriscao = tipoDescriscao;
            Situacao = situacaoEnum;
        }

        public int Id { get; set; }
        public Guid IdUsuarioIdentity { get; private set; }
        public TipoMovimentacaoEnum TipoOperacao { get; private set; }
        public string TipoDescriscao { get; private set; }
        public SituacaoEnum Situacao { get; private set; }

        public void AlterarTipo(TipoMovimentacaoEnum tipoOperacao, string tipoDescriscao, SituacaoEnum situacao)
        {

            if (string.IsNullOrEmpty(tipoOperacao.ToString()))
                AddErro("Digite a operação do tipo (Entrada ou Saida)!");
            if (string.IsNullOrEmpty(TipoDescriscao))
                AddErro("Informe a des ");
            if (string.IsNullOrEmpty(situacao.ToString()))
                AddErro("Digite a situação da movimentação");
            if (TipoOperacao == tipoOperacao &&  TipoDescriscao == tipoDescriscao && Situacao == situacao)
                AddErro("Nenhuma informação a ser alterada!");
            if (!EhValido)
                return;
            TipoOperacao = tipoOperacao;
            TipoDescriscao = tipoDescriscao;
            Situacao = situacao;

        }
    }
}
