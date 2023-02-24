using apiProjetoFinaceiro.Model.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace apiProjetoFinaceiro.Model.Imput
{
    public class MovimentacaoFinanceiraInputModel
    {
        [Required]
        public int IdMovimentacao { get; set; } 
        public DateTime DatamovimentacaoEntrada { get; set; }
        [Required]
        public decimal ValorMovimentacao { get; set; }
        [Required]
        public int TipoMovimentacaoId { get; set; }
        [Required]
        public SituacaoEnum Situacao { get; set; }
    }
}
