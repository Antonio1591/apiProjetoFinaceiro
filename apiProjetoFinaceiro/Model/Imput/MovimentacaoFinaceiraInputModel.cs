﻿using apiProjetoFinaceiro.Model.Domain;
using Microsoft.AspNetCore.Identity;

namespace apiProjetoFinaceiro.Model.Imput
{
    public class MovimentacaoFinanceiraInputModel
    {
        public MovimentacaoFinanceiraInputModel( DateTime datamovimentacaoEntrada, decimal valorMovimentacao, int tipoMovimentacao, SituacaoEnum situacao)
        {
            DatamovimentacaoEntrada = datamovimentacaoEntrada;
            ValorMovimentacao = valorMovimentacao;
            TipoMovimentacaoId = tipoMovimentacao;
            Situacao = situacao;
        }

        public DateTime DatamovimentacaoEntrada { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public int TipoMovimentacaoId { get; set; }
        public SituacaoEnum Situacao { get; set; }
    }
}
