using System.ComponentModel.DataAnnotations;

namespace apiProjetoFinaceiro.Model.Domain
{
    public class Bairro
    {
        protected Bairro()
        {

        }

        public Bairro(string nome, string situacao)
        {
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