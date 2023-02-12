using api.Data;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Imput;
using apiProjetoFinaceiro.Model.View;
using apiProjetoFinaceiro.Model;
using apiProjetoFinaceiro.Model.Mapping;
using Microsoft.EntityFrameworkCore;

namespace apiProjetoFinaceiro.services
{
    public class TipoMovimentacaoServices: ITipoMovimentacaoServices
    {
        private readonly DataContext _context;

        public TipoMovimentacaoServices(DataContext Context)
        {
            _context = Context;
        }
        public async Task<RespostaApi<TipoMovimentacaoViewModel>> CadastroTipo(TipoMovimentacaoInputModel input)
        {
            
            TipoMovimentacao tipoMovimentacao = new TipoMovimentacao(input.TipoOperacao,input.TipoDescriscao, input.SituacaoEnum);
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
            var tipoMovimentacao = await _context.tipoMovimentacao.FindAsync(input);
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
            IEnumerable<TipoMovimentacaoViewModel> tipoMovimentacao = _context.tipoMovimentacao.ToList()
                                                                                                .Select(P => P.ParaViewModel());

            return tipoMovimentacao;
        }

    }
}
