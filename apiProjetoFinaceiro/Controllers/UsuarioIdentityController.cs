using apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio;
using apiProjetoFinaceiro.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiProjetoFinaceiro.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UsuarioIdentityController:ControllerBase
    {
        private readonly IIdentityUsuarioServices _identityUsuarioServices;

        public UsuarioIdentityController(IIdentityUsuarioServices identityUsuarioServices)
        {
            _identityUsuarioServices = identityUsuarioServices;
        }

        [HttpPost("Cadastro")]
        public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            var resultado = await _identityUsuarioServices.CadastrarUsuario(usuarioCadastro);
            if(resultado.Sucesso)
                return Ok(resultado);
            if(resultado.Erros.Count >0)
                return BadRequest(resultado);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioLoginResponse>> login(UsuarioLoginRequet usuarioLoginResponse)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var resultado = await _identityUsuarioServices.Login(usuarioLoginResponse);
            if (resultado.Sucesso)
                return Ok(resultado);

            return Unauthorized(resultado);
        }
    }
}
