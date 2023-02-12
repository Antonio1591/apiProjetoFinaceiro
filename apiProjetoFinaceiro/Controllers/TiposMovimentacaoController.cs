using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.services;
using Microsoft.AspNetCore.Mvc;

namespace apiProjetoFinaceiro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposMovimentacaoController:ControllerBase
    {
        private readonly ITipoMovimentacaoServices _ITiposMovimentacaoServices;

        public TiposMovimentacaoController(ITipoMovimentacaoServices iTiposMovimentacaoServices)
        {
            _ITiposMovimentacaoServices = iTiposMovimentacaoServices;
        }

        [HttpGet]
        public IEnumerable<TipoMovimentacaoViewModel> BuscarMovimentacoes()
        {
            return _ITiposMovimentacaoServices.BuscarTipos();

        }

        [HttpPost("CadastroTipo")]
        public async Task<ActionResult<RespostaApi<TipoMovimentacaoViewModel>>> CadastrarTipos(TipoMovimentacaoInputModel input)
        {
            var tiposMovimentacao = await _ITiposMovimentacaoServices.CadastroTipo(input);
            if (tiposMovimentacao.Erro)
                return BadRequest(tiposMovimentacao.MenssagensErros);

            return new RespostaApi<TipoMovimentacaoViewModel>
            {
                Dados = tiposMovimentacao.Dados,
            };
        }

        [HttpPut("AlterarTipo")]
        public async Task<ActionResult<RespostaApi<TipoMovimentacaoViewModel>>> AlterarTipo(TipoMovimentacaoInputModel input)
        {
            var tipoMovimentacao = await _ITiposMovimentacaoServices.AtualizarTipo(input);
            if (tipoMovimentacao.Erro)
                return BadRequest(tipoMovimentacao.MenssagensErros);

            return new RespostaApi<TipoMovimentacaoViewModel>
            {
                Dados = tipoMovimentacao.Dados,
            };

        }
    }
}
