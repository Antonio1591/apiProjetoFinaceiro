using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace apiProjetoFinaceiro.Model.Domain
{
    public class Bairro:Entidade
    {
        protected Bairro()
        {

        }

        public Bairro(string nome, string situacao)
        {
            if (nome.Length <= 3 || string.IsNullOrEmpty(nome))
                AddErro("Nome do bairro não encontrado");
          
            if (!EhValido)
                return;
            Nome = nome;
            Situacao = situacao;
        }

        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Situacao { get; set; }
    }
}