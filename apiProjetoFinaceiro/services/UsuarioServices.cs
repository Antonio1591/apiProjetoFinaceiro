using api.Data;
using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.Mapping;
using apiProjetoFinaceiro.Model.View;
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
        public async Task<UsuarioViewModel> Create(UsuarioImputModel input)
        {
            var cidade = await _context.cidade.FindAsync(input.Cidade.Id);
            if (cidade == null) return null;
            var bairro = await _context.bairro.FindAsync(input.Bairro.Id);
            if (bairro == null) return null;
            var usuario = new Usuario(input.Nome, input.Senha, input.Email, input.Telefone, cidade, bairro, input.CPF, input.DataNascimento, SituacaoEnum.ATIVO.ToString());

            if (usuario.CadastrarUsuario(usuario) == false)
                return default;

            _context.usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario.ParaViewModel();
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

        public async Task<UsuarioViewModel> Logim(Login login)
        {
            var usuario = await _context.usuario.Include(p => p.Bairro)
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(U => U.Email == login.Email && U.Senha == login.Senha);
            if (usuario == null) return null;

            return usuario.ParaViewModel();


        }

        public async Task Update(Usuario usuario)
        {
            //_context.Entry(usuario).State = EntityState.Modified;
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<CidadeViewModel>> BuscarCidades()
        {

            IEnumerable<CidadeViewModel> cidades= _context.cidade.Select(C=>C.ParaViewModel());
            return cidades;
                               

        }

        public async Task<IEnumerable<BairroViewModel>> BuscarBairros()
        {

            IEnumerable<BairroViewModel> bairros = _context.bairro.Select(C => C.ParaViewModel());
            return bairros;

        }

    }
}


