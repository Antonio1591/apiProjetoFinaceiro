using api.Data;
using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.Mapping;
using apiProjetoFinaceiro.Model.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

namespace apiProjetoFinaceiro.services
{

    public class UsuarioServices : IUsuarioServices
    {
        public readonly DataContext _context;
        List<string> InformacoesNaoEncontrada = new List<string>();

        public UsuarioServices(DataContext context)
        {
            _context = context;
        }

        public async Task<RespostaApi<UsuarioViewModel>> Create(UsuarioImputModel input)
        {
            Cidade cidade = await _context.cidade.FindAsync(input.Cidade.Id);
            if (cidade == null)
            {
                InformacoesNaoEncontrada.Add("Cidade não encontrada");
                return new RespostaApi<UsuarioViewModel>
                {
                    MenssagensErros = InformacoesNaoEncontrada,
                    Erro = true,
                };
            }
            Bairro bairro = await _context.bairro.FindAsync(input.Bairro.Id);
            if (bairro == null)
            {
                InformacoesNaoEncontrada.Add("Bairro não encontrada");
                return new RespostaApi<UsuarioViewModel>
                {
                    MenssagensErros = InformacoesNaoEncontrada,
                    Erro = true,

                };
            }

            var ValidacaoCpfEmail = await _context.usuario.AnyAsync(U => U.CPF == input.CPF || U.Email == input.Email);
            if (ValidacaoCpfEmail)
            {
                InformacoesNaoEncontrada.Add("CPF ou Email, Já cadastrado");
                return new RespostaApi<UsuarioViewModel>
                {
                    MenssagensErros = InformacoesNaoEncontrada,
                    Erro = true,

                };
            }
            //var usuario = new Usuario(input.Nome, input.Senha, input.Email, input.Telefone, cidade, bairro, input.CPF, input.DataNascimento, SituacaoEnum.ATIVO.ToString());
            var usuario = new Usuario(input.Nome, input.Senha, input.Email, input.Telefone, cidade, bairro, input.CPF, input.DataNascimento, SituacaoEnum.ATIVO.ToString());

            if (!usuario.EhValido)
            {
                //RespostaApi<List<string>> RetornoErro = new RespostaApi<List<string>>;
                //RetornoErro.MenssagemErro = usuario.Erros;

                return new RespostaApi<UsuarioViewModel>
                {
                    MenssagensErros = usuario.Erros,
                    Erro = true,

                };
            }
            var novoUsuario = new Usuario(usuario.Nome, usuario.Senha, usuario.Email, usuario.Telefone, cidade, bairro, usuario.CPF, usuario.DataNascimento, SituacaoEnum.ATIVO.ToString());

            _context.usuario.Add(novoUsuario);
            await _context.SaveChangesAsync();
            return new RespostaApi<UsuarioViewModel>
            { Dados = novoUsuario.ParaViewModel() };
        }
        public async Task<RespostaApi<UsuarioViewModel>> Logim(LoginInputModel login)
        {
            var usuario = await _context.usuario.Include(p => p.Bairro)
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(U => U.Email == login.Email && U.Senha == login.Senha);
            if (usuario == null)
            {
                InformacoesNaoEncontrada.Add("Dados não Encontrado");
                return new RespostaApi<UsuarioViewModel>
                {
                    MenssagensErros = InformacoesNaoEncontrada,
                    Erro = true,
                };

            }
            return new RespostaApi<UsuarioViewModel>
            { Dados = usuario.ParaViewModel() };


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

        public async Task Update(UsuarioImputModel usuarioInputModel)
        {
            //_context.Entry(usuario).State = EntityState.Modified;
            _context.Update(usuarioInputModel);
            await _context.SaveChangesAsync();
        }
        public async Task<RespostaApi<UsuarioViewModel>> AlterarSenha(UsuarioImputModel usuarioInputModel)
        {
            var usuario = await _context.usuario.Include(p => p.Bairro)
                 .Include(p => p.Cidade)
                 .FirstOrDefaultAsync(U => U.Email == usuarioInputModel.Email && U.CPF == usuarioInputModel.CPF);

            usuario.AlterarSenha(usuarioInputModel.Senha);
            if (!usuario.EhValido)
            {
                return new RespostaApi<UsuarioViewModel>
                {
                    MenssagensErros = usuario.Erros,
                    Erro = true,

                };

            }
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return new RespostaApi<UsuarioViewModel>
            { Dados = usuario.ParaViewModel() };
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


