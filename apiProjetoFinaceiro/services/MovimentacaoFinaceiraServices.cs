using api.Data;
using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.Mapping;
using apiProjetoFinaceiro.Model.View;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace apiProjetoFinaceiro.services
{
    public class MovimentacaoFinaceiraServices : IMovimentacaoFinanceiraServices
    {
        private readonly DataContext _context;

        public MovimentacaoFinaceiraServices(DataContext Context)
        {
            _context = Context;
        }
        public async Task<RespostaApi<MovimentacaoFinanceiraViewModel>> NovaMovimentacao(MovimentacaoFinaceiraInputModel input)
        {
            Usuario usuario = await _context.usuario.FindAsync(input.Usuario.Id);
            if (!usuario.EhValido)
            {
                return new RespostaApi<MovimentacaoFinanceiraViewModel>
                {
                    MenssagensErros = usuario.Erros,
                    Erro = true
                };
            }
            MovimentacaoFinanceira movimentacaoFinaceira = new MovimentacaoFinanceira(input.Usuario, input.DatamovimentacaoEntrada, input.ValorMovimentacao, input.TipoMovimentacao,SituacaoEnum.ATIVO);
            if (!movimentacaoFinaceira.EhValido)
            {
                return new RespostaApi<MovimentacaoFinanceiraViewModel>
                {
                    MenssagensErros = usuario.Erros,
                    Erro = true
                };
            }
            _context.movimentacaoFinaceira.Add(movimentacaoFinaceira);
            await _context.SaveChangesAsync();
            return new RespostaApi<MovimentacaoFinanceiraViewModel>
            { Dados = movimentacaoFinaceira.ParaViewModel() };
        }
        public async Task<RespostaApi<MovimentacaoFinanceiraViewModel>> AtualizarMovimentacao(MovimentacaoFinaceiraInputModel input)
        {
            var movimentacaoFinaceira = await _context.movimentacaoFinaceira.FirstOrDefaultAsync(M => M.Id == input.Id);
            movimentacaoFinaceira.alterarMovimentacao(input.ValorMovimentacao, input.TipoMovimentacao, input.Situacao);
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
            IEnumerable<MovimentacaoFinanceiraViewModel> movimentosFinaceiros = _context.movimentacaoFinaceira.Include(T=>T.TipoMovimentacao)
                                                                                                               .Include(U => U.Usuario)  
                                                                                                               .Select(P => P.ParaViewModel());

            return movimentosFinaceiros;
        }

     

    }


}



