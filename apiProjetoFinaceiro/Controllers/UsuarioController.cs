using Microsoft.AspNetCore.Mvc;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.services;
using apiProjetoFinaceiro.Model;

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

        [HttpGet("{Id}")]
        
        public async Task<ActionResult<UsuarioViewModel>> Pessoa(int Id)
        {
            return await _IUsuarioServices.ObterUsuarioPorId(Id);
        }

        [HttpPost("CadastrarUsuario")]

        public async Task<ActionResult<RespostaApi<UsuarioViewModel>>> AdicionarUsuario([FromBody] UsuarioImputModel usuarioInputModel)
        {
            var newUsuario = await _IUsuarioServices.Create(usuarioInputModel);

            if (newUsuario.Erro)
                return BadRequest(newUsuario.MenssagensErros);

            //return CreatedAtAction(nameof(UsuarioViewModel), new { newUsuario.Dados.Id }, newUsuario.Dados);
            return new RespostaApi<UsuarioViewModel> { Dados = newUsuario.Dados };

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<UsuarioViewModel>> DeletaUsuario(int Id)
        {
            var deletePessoa = _IUsuarioServices.ObterUsuarioPorId(Id);
            if (deletePessoa == null)
                NotFound();

            await _IUsuarioServices.Delete(deletePessoa.Id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<UsuarioViewModel>> AtualizarUsuario(int Id, [FromBody] UsuarioImputModel usuarioInputModel)
        {
            if (Id != usuarioInputModel.Id)
                return BadRequest();

            await _IUsuarioServices.Update(usuarioInputModel);
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
