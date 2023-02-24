﻿using MathNet.Numerics.LinearAlgebra;
using System.Text.Json.Serialization;

namespace apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio
{
    public class UsuarioLoginResponse 
    {

        public bool Sucesso { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Token { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DataExpiracao { get; private set; }

        public List<string> Erros {get; private set;}

        public UsuarioLoginResponse() =>
            Erros= new List<string>();
        public UsuarioLoginResponse(bool sucesso=true) : this() =>
            Sucesso = sucesso;

        public UsuarioLoginResponse(bool sucesso, string token, DateTime? dataExpiracao) : this(sucesso)
        {
            this.Token = token;
            DataExpiracao = dataExpiracao;
        }

        public void AdicionarErro(string erro) => 
            Erros.Add(erro);
        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
