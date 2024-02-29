using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiProjetoFinaceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "VIP")]
    public class MovimentacaoFinanceiraController : ControllerBase
    {
        private readonly IMovimentacaoFinanceiraServices _IMovimentacaoFinanceira;
        public MovimentacaoFinanceiraController(IMovimentacaoFinanceiraServices iMovimentacaoFinanceira)
        {
            _IMovimentacaoFinanceira = iMovimentacaoFinanceira;
        }

        [HttpGet]
        
        public IEnumerable<MovimentacaoFinanceiraViewModel> BuscarMovimentacoes( )
        {
           
            return _IMovimentacaoFinanceira.BuscarMovimentacao();

        }

        [HttpPost("CadastroMovimentacao")]
        public async Task<ActionResult<RespostaApi<MovimentacaoFinanceiraViewModel>>> CadastrarMovimentacao(MovimentacaoFinanceiraInputModel input)
        {
            
            var movimentacaoFinaceira = await _IMovimentacaoFinanceira.NovaMovimentacao(input);
            if (movimentacaoFinaceira.Erro)
                return BadRequest(movimentacaoFinaceira.MenssagensErros);

            return new RespostaApi<MovimentacaoFinanceiraViewModel>
            {
                Dados = movimentacaoFinaceira.Dados,
            };
        }

        [HttpPut("AlterarMovimentacao")]
        public async Task<ActionResult<RespostaApi<MovimentacaoFinanceiraViewModel>>> AlterarMovimentacao(MovimentacaoFinanceiraInputModel input)
        {
            var movimentacaoFinaceira = await _IMovimentacaoFinanceira.AtualizarMovimentacao(input);
            if (movimentacaoFinaceira.Erro)
                return BadRequest(movimentacaoFinaceira.MenssagensErros);

            return new RespostaApi<MovimentacaoFinanceiraViewModel>
            {
                Dados = movimentacaoFinaceira.Dados,
            };
//
        }
    }
}
