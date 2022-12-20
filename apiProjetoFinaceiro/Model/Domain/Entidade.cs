﻿using System.ComponentModel.DataAnnotations.Schema;

namespace apiProjetoFinaceiro.Model.Domain
{
    [NotMapped]
    public abstract class Entidade
    {
        public List<string> Erros = new List<string>();

        public  void AddErro(string erro)
        {
            Erros.Add(erro);
            
        }
        public  bool EhValido => !Erros.Any();


    }
}

