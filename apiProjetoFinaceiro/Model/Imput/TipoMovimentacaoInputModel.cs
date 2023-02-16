using System.ComponentModel.DataAnnotations;

namespace apiProjetoFinaceiro.Model.Imput
{
    public class TipoMovimentacaoInputModel
    {
        public TipoMovimentacaoInputModel(TipoMovimentacaoEnum tipoOperacao, string tipoDescriscao, SituacaoEnum situacaoEnum)
        {
            
            TipoOperacao = tipoOperacao;
            TipoDescriscao = tipoDescriscao;
            SituacaoEnum = situacaoEnum;
        }
        [Required]
      
        public TipoMovimentacaoEnum TipoOperacao { get;  set; }
        [Required]
        public string TipoDescriscao { get;  set; }
        [Required]
        public SituacaoEnum SituacaoEnum { get;  set; }
    }
}
