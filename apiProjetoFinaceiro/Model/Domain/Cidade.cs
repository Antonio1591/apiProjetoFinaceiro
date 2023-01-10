using System.ComponentModel.DataAnnotations;

namespace apiProjetoFinaceiro.Model.Domain
{
    public class Cidade:Entidade
    {
        protected Cidade()
        {

        }

        public Cidade(string nome, string cep, string situacao)
        {
            if (nome.Length <= 3 || string.IsNullOrEmpty(nome))
                AddErro("Nome da Cidade não encontrado");
            if (cep.Length <= 3 || string.IsNullOrEmpty(cep))
                AddErro("Cep não encontrado");
            if (!EhValido)
                return;
            Nome = nome;
            Cep = cep;
            Situacao = situacao;
        }

        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Situacao { get; set; }

    }
}