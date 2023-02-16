using api.Data;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace apiProjetoFinaceiro.services
{
    public class TipoMovimentacaoServices : ITipoMovimentacaoServices
    {
        private readonly DataContext _context;
        private readonly IAspNetUser _AspNetUser;
    
        public TipoMovimentacaoServices(DataContext context, IAspNetUser aspNetUser)
        {
            _context = context;
            _AspNetUser = aspNetUser;
        }

        public async Task<RespostaApi<TipoMovimentacaoViewModel>> CadastroTipo(TipoMovimentacaoInputModel input)
        {
            var idUsuarioIdentity = _AspNetUser.ObterUserId();

            TipoMovimentacao tipoMovimentacao = new TipoMovimentacao(idUsuarioIdentity, input.TipoOperacao, input.TipoDescriscao, input.SituacaoEnum);
            if (!tipoMovimentacao.EhValido)
            {
                return new RespostaApi<TipoMovimentacaoViewModel>
                {
                    MenssagensErros = tipoMovimentacao.Erros,
                    Erro = true
                };
            }
            _context.tipoMovimentacao.Add(tipoMovimentacao);
            await _context.SaveChangesAsync();
            return new RespostaApi<TipoMovimentacaoViewModel>
            { Dados = tipoMovimentacao.ParaViewModel() };
        }
        public async Task<RespostaApi<TipoMovimentacaoViewModel>> AtualizarTipo(TipoMovimentacaoInputModel input)
        {
            var idUsuarioIdentity = _AspNetUser.ObterUserId();
            TipoMovimentacao? tipoMovimentacao = await _context.tipoMovimentacao
                                                                 .FirstOrDefaultAsync(T=>T.IdUsuarioIdentity == idUsuarioIdentity || T.TipoOperacao == input.TipoOperacao || T.TipoDescriscao == input.TipoDescriscao);
            tipoMovimentacao.AlterarTipo(input.TipoOperacao, input.TipoDescriscao, input.SituacaoEnum);
            if (!tipoMovimentacao.EhValido)
                return new RespostaApi<TipoMovimentacaoViewModel>
                {
                    MenssagensErros = tipoMovimentacao.Erros,
                    Erro = true,
                };
            _context.Update(tipoMovimentacao);
            _context.SaveChanges();
            return new RespostaApi<TipoMovimentacaoViewModel>
            {
                Dados = tipoMovimentacao.ParaViewModel(),
            };
        }
        public IEnumerable<TipoMovimentacaoViewModel> BuscarTipos()
        {
            var idUsuarioIdentity = _AspNetUser.ObterUserId();
            IEnumerable<TipoMovimentacaoViewModel> tipoMovimentacao = _context.tipoMovimentacao.ToList()
                                                                                                .Where(T=>T.IdUsuarioIdentity== idUsuarioIdentity)
                                                                                                .Select(P => P.ParaViewModel());

            return tipoMovimentacao;
        }

        public async Task<RespostaApi<TipoMovimentacaoViewModel>> ObterPorId(int idTipoMovimentacao)
        {
            var idUsuarioIdentity = _AspNetUser.ObterUserId();
            TipoMovimentacao? tipoMovimentacao =  await _context.tipoMovimentacao.FirstOrDefaultAsync(T => T.IdUsuarioIdentity == idUsuarioIdentity || T.Id == idTipoMovimentacao);
                                                                                               

            if (!tipoMovimentacao.EhValido)
                return new RespostaApi<TipoMovimentacaoViewModel>
                {
                    MenssagensErros = tipoMovimentacao.Erros,
                    Erro = true,
                };

            return new RespostaApi<TipoMovimentacaoViewModel>
            { Dados = tipoMovimentacao.ParaViewModel() };
        }
    }
}
