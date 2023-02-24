using Microsoft.AspNetCore.Identity;

namespace apiProjetoFinaceiro.Model.Domain
{
    public class MovimentacaoFinanceira : Entidade
    {
        protected MovimentacaoFinanceira(){}
        public MovimentacaoFinanceira(Guid idUsuarioIdentity, DateTime datamovimentacaoEntrada, decimal valorMovimentacao, TipoMovimentacao tipoMovimentacao, SituacaoEnum situacao)
        {
            if (valorMovimentacao <= 0)
                AddErro("Favor informar um valor valido");
            if (datamovimentacaoEntrada.Year < DateTime.Now.Year - 100)
                AddErro("Favor informa uma data valida");

            if (string.IsNullOrEmpty(situacao.ToString()))
                AddErro("Informe a situação da movimentação");
            if (!EhValido)
                return;
            IdUsuarioIdentity = idUsuarioIdentity;
            Datamovimentacaolancamento = DateTime.Now;
            DatamovimentacaoEntrada = datamovimentacaoEntrada;
            ValorMovimentacao = valorMovimentacao;
            TipoMovimentacao = tipoMovimentacao;
            Situacao = situacao;
        }

        public int Id { get;private set; }
        public Guid IdUsuarioIdentity { get; private set; }
        public DateTime Datamovimentacaolancamento { get; private set; }
        public DateTime DatamovimentacaoEntrada { get; private set; }
        public decimal ValorMovimentacao { get; private set; }
        public TipoMovimentacao TipoMovimentacao { get; private set; }
        public SituacaoEnum Situacao { get; private set; }

        public void alterarMovimentacao(decimal valorMovimentacao, TipoMovimentacao tipoMovimentacao, SituacaoEnum situacao )
        {
            Datamovimentacaolancamento = DateTime.Now;
            if (valorMovimentacao <= 0)
                AddErro("Para aterar o valor da movimentação necessita de ser maior que 0, caso deseja tirar essa movimentação e so cancelar a mesma!");
            if (string.IsNullOrEmpty(tipoMovimentacao.ToString()))
                AddErro("Informe o tipo da operação ");
            if (string.IsNullOrEmpty(situacao.ToString()))
                AddErro("Digite a situação da movimentação");
            if (ValorMovimentacao == valorMovimentacao && TipoMovimentacao ==  tipoMovimentacao && Situacao == situacao)
                AddErro("Nenhuma informação a ser alterada!");
            if (!EhValido)
                return;
            ValorMovimentacao = valorMovimentacao;
            TipoMovimentacao=tipoMovimentacao;
            Situacao = situacao;

        }
    }

}
