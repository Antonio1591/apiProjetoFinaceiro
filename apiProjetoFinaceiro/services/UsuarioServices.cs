using api.Data;
using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.ClasseDbSet;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.Mapping;
using apiProjetoFinaceiro.Model.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;

namespace apiProjetoFinaceiro.services
{

    public class UsuarioServices : IUsuarioServices
    {
        public readonly DataContext _context;

        public UsuarioServices(DataContext context)
        {
            _context = context;
        }
        public async Task<RespostaApi<UsuarioViewModel>> Create(UsuarioImputModel input)
        {
            Cidade cidade = await _context.cidade.FindAsync(input.Cidade.Id);
            if (cidade == null) return null;
            Bairro bairro = await _context.bairro.FindAsync(input.Bairro.Id);
            if (bairro == null) return null;
            //var usuario = new Usuario(input.Nome, input.Senha, input.Email, input.Telefone, cidade, bairro, input.CPF, input.DataNascimento, SituacaoEnum.ATIVO.ToString());
            var usuario = new Usuario("", "123", "", input.Telefone, cidade, bairro, input.CPF, input.DataNascimento, SituacaoEnum.ATIVO.ToString());
            //if (usuario == null) usuario.AddErro("O usuario deve ter todos os campos preenchidos!");
            if (!usuario.EhValido)
            {
                //RespostaApi<List<string>> RetornoErro = new RespostaApi<List<string>>;
                //RetornoErro.MenssagemErro = usuario.Erros;

                return new RespostaApi<UsuarioViewModel>
                {
                    MenssagemErro = usuario.Erros,
                    Erro=true,

                };
            }
            var novoUsuario = new UsuarioDbSet(usuario.Nome, usuario.Senha, usuario.Email, usuario.Telefone, cidade, bairro, usuario.CPF, usuario.DataNascimento, SituacaoEnum.ATIVO.ToString());
            _context.usuario.Add(novoUsuario);
            await _context.SaveChangesAsync();
            return new RespostaApi<UsuarioViewModel>
            { Dados = novoUsuario.ParaViewModel() };
        }

        public async Task Delete(int id)
        {
            var usuarioToDelete = await _context.usuario.FindAsync(id);
            _context.usuario.Remove(usuarioToDelete);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<UsuarioViewModel> ListaUsuarios()
        {
            IEnumerable<UsuarioViewModel> usuarios = _context.usuario
                                          .Include(p => p.Bairro)
                                          .Include(p => p.Cidade).ToList()
                                          .Select(p => p.ParaViewModel());
            return usuarios;

        }

        public async Task<UsuarioViewModel> ObterUsuarioPorId(int id)
        {
            var usuario = await _context.usuario
                      .Include(p => p.Bairro)
                       .Include(p => p.Cidade)
                        .FirstOrDefaultAsync(U => U.Id == id);

            return usuario.ParaViewModel();
        }

        public async Task<UsuarioViewModel> Logim(LoginInputModel login)
        {
            var usuario = await _context.usuario.Include(p => p.Bairro)
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(U => U.Email == login.Email && U.Senha == login.Senha);
            if (usuario == null) return null;

            return usuario.ParaViewModel();


        }

        public async Task Update(UsuarioImputModel usuarioInputModel)
        {
            //_context.Entry(usuario).State = EntityState.Modified;
            _context.Update(usuarioInputModel);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<CidadeViewModel>> BuscarCidades()
        {

            IEnumerable<CidadeViewModel> cidades = _context.cidade.Select(C => C.ParaViewModel());
            return cidades;


        }

        public async Task<IEnumerable<BairroViewModel>> BuscarBairros()
        {

            IEnumerable<BairroViewModel> bairros = _context.bairro.Select(C => C.ParaViewModel());
            return bairros;

        }

    }
}


