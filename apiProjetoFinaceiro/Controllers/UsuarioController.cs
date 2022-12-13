using Microsoft.AspNetCore.Mvc;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.services;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace apiProjetoFinaceiro.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _IUsuarioServices;

        public UsuarioController(IUsuarioServices iUsuarioServices)
        {
            _IUsuarioServices = iUsuarioServices;
        }

        [HttpGet]
        public IEnumerable<UsuarioViewModel> ListaUsuario()
        {
            return _IUsuarioServices.ListaUsuarios();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioViewModel>> Logim([FromBody] Login login)
        {
            if (login == null) return BadRequest();
            return await _IUsuarioServices.Logim(login);      

        }
        [HttpGet("{Id}")]

        public async Task<ActionResult<UsuarioViewModel>> Pessoa(int Id)
        {
            return await _IUsuarioServices.ObterUsuarioPorId(Id);
        }

        [HttpPost("Resultado")]

        public async Task<ActionResult<Usuario>> AdicionarUsuario([FromBody] UsuarioImputModel usuario)
        {
            var newUsuario = await _IUsuarioServices.Create(usuario);
            return CreatedAtAction(nameof(usuario), new { newUsuario.Id }, newUsuario);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Usuario>> DeletaUsuario(int Id)
        {
            var deletePessoa = _IUsuarioServices.ObterUsuarioPorId(Id);
            if (deletePessoa == null)
                NotFound();

            await _IUsuarioServices.Delete(deletePessoa.Id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Usuario>> AtualizarUsuario(int Id, [FromBody] Usuario usuario)
        {
            if (Id != usuario.Id)
                return BadRequest();

            await _IUsuarioServices.Update(usuario);
            return NoContent();
        }
       
        [HttpGet("buscarCidade")]
        public async Task<IEnumerable<CidadeViewModel>> BuscarCidades()
        {
            return await _IUsuarioServices.BuscarCidades();
        }
        [HttpGet("buscarBairro")]
        public async Task<IEnumerable<BairroViewModel>> BuscarBairros()
        {
            return await _IUsuarioServices.BuscarBairros();
        }

    }
   
}
