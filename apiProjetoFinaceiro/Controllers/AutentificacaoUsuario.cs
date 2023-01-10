using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.services;
using Microsoft.AspNetCore.Mvc;

namespace apiProjetoFinaceiro.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AutentificacaoUsuario:ControllerBase
    {
        private readonly IUsuarioServices _IUsuarioServices;

        public AutentificacaoUsuario(IUsuarioServices iUsuarioServices)
        {
            _IUsuarioServices = iUsuarioServices;
            
        }

        [HttpPost("Login")]
        public async Task<ActionResult<RespostaApi<UsuarioViewModel>>> Logim([FromBody] LoginInputModel loginInput)
        {
            var resultado = await _IUsuarioServices.Logim(loginInput);
            if (resultado == null) return BadRequest(resultado.MenssagensErros);
            if (resultado.Erro)
            {
                return BadRequest(resultado.MenssagensErros);
            }
            return new RespostaApi <UsuarioViewModel>{Dados= resultado.Dados };

        }
        [HttpPut("AlterarSenha")]
        public async Task<ActionResult<RespostaApi<UsuarioViewModel>>> AlterarSenha([FromBody] UsuarioImputModel usuarioImputModel)
        {
            var resultado = await _IUsuarioServices.AlterarSenha(usuarioImputModel);
            if (resultado == null) return BadRequest(resultado.MenssagensErros);
            if (resultado.Erro)
            {
                return BadRequest(resultado.MenssagensErros);
            }
            return new RespostaApi<UsuarioViewModel> { Dados = resultado.Dados };

        }
    }
}
