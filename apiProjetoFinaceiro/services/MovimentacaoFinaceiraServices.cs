using api.Data;
using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.Mapping;
using apiProjetoFinaceiro.Model.View;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace apiProjetoFinaceiro.services
{
    public class MovimentacaoFinaceiraServices : IMovimentacaoFinanceiraServices
    {
        private readonly DataContext _context;
        private readonly IAspNetUser _aspNetUser;
        private readonly ITipoMovimentacaoServices _tipoMovimentacaoServices;

        public MovimentacaoFinaceiraServices(DataContext context, IAspNetUser aspNetUser, ITipoMovimentacaoServices tipoMovimentacaoServices)
        {
            _context = context;
            _aspNetUser = aspNetUser;
            _tipoMovimentacaoServices = tipoMovimentacaoServices;
        }

        public async Task<RespostaApi<MovimentacaoFinanceiraViewModel>> NovaMovimentacao(MovimentacaoFinanceiraInputModel input)
        {
            var idUsuarioIdentity = _aspNetUser.ObterUserId();
            TipoMovimentacao? tipoMovimentacao = await _context.tipoMovimentacao.FirstOrDefaultAsync(T => T.IdUsuarioIdentity == idUsuarioIdentity || T.Id == input.TipoMovimentacaoId);

            MovimentacaoFinanceira movimentacaoFinaceira = new MovimentacaoFinanceira(idUsuarioIdentity, input.DatamovimentacaoEntrada, input.ValorMovimentacao, tipoMovimentacao, SituacaoEnum.ATIVO);
            if (!movimentacaoFinaceira.EhValido)
            {
                return new RespostaApi<MovimentacaoFinanceiraViewModel>
                {
                    MenssagensErros = movimentacaoFinaceira.Erros,
                    Erro = true
                };
            }
            _context.movimentacaoFinaceira.Add(movimentacaoFinaceira);
            await _context.SaveChangesAsync();
            return new RespostaApi<MovimentacaoFinanceiraViewModel>
            { Dados = movimentacaoFinaceira.ParaViewModel() };
        }
        public async Task<RespostaApi<MovimentacaoFinanceiraViewModel>> AtualizarMovimentacao(MovimentacaoFinanceiraInputModel input)
        {
            var idUsuarioIdentity = _aspNetUser.ObterUserId();
            TipoMovimentacao? tipoMovimentacao = await _context.tipoMovimentacao.FirstOrDefaultAsync(T => T.IdUsuarioIdentity == idUsuarioIdentity || T.Id == input.TipoMovimentacaoId);
            var movimentacaoFinaceira = await _context.movimentacaoFinaceira.FirstOrDefaultAsync(M => M.IdUsuarioIdentity== idUsuarioIdentity ||  M.DatamovimentacaoEntrada==input.DatamovimentacaoEntrada || M.ValorMovimentacao == input.ValorMovimentacao || M.TipoMovimentacao == tipoMovimentacao || M.Situacao==input.Situacao);
            movimentacaoFinaceira.alterarMovimentacao(input.ValorMovimentacao, tipoMovimentacao, input.Situacao);
            if (!movimentacaoFinaceira.EhValido)
                return new RespostaApi<MovimentacaoFinanceiraViewModel>
                {
                    MenssagensErros = movimentacaoFinaceira.Erros,
                    Erro = true,
                };
            _context.Update(movimentacaoFinaceira);
            _context.SaveChanges();
            return new RespostaApi<MovimentacaoFinanceiraViewModel>
            {
                Dados = movimentacaoFinaceira.ParaViewModel(),
            };
        }
        public IEnumerable<MovimentacaoFinanceiraViewModel> BuscarMovimentacao()
        {       
            var idUsuarioIdentity = _aspNetUser.ObterUserId();
            IEnumerable<MovimentacaoFinanceiraViewModel> movimentosFinaceiros = _context.movimentacaoFinaceira.Include(T=>T.TipoMovimentacao)
                                                                                                               .ToList()
                                                                                                               .Where(M=> M.IdUsuarioIdentity == idUsuarioIdentity)
                                                                                                               .Select(P=> P.ParaViewModel());

            return movimentosFinaceiros;
        }

     

    }


}



