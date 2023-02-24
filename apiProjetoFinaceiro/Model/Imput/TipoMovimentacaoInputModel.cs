using System.ComponentModel.DataAnnotations;

namespace apiProjetoFinaceiro.Model.Imput
{
    public class TipoMovimentacaoInputModel
    {

        public int Id { get; set; }
        [Required]
        public TipoMovimentacaoEnum TipoOperacao { get;  set; }
        [Required]
        public string TipoDescriscao { get;  set; }
        [Required]
        public SituacaoEnum SituacaoEnum { get;  set; }
    }
}
