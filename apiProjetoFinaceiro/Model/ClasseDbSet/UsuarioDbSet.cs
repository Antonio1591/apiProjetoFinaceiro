using System.ComponentModel.DataAnnotations;
using apiProjetoFinaceiro.Model.Domain;

namespace apiProjetoFinaceiro.Model.ClasseDbSet
{
    public class UsuarioDbSet
    {
        protected UsuarioDbSet(){}
        public UsuarioDbSet(string nome, string senha, string email, string telefone, Cidade cidade, Bairro bairro, string cPF, DateTime dataNascimento, string situacao)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            Telefone = telefone;
            Cidade = cidade;
            Bairro = bairro;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Situacao = situacao;
        }

        public int Id { get; set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        [MinLength(3)]
        public string Senha { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        [MinLength(8)]
        public string Telefone { get; private set; }
        [Required]
        public Cidade Cidade { get; private set; }
        [Required]
        public Bairro Bairro { get; private set; }
        [Required]
        [MinLength(11)]
        public string CPF { get; private set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; private set; }
        [Required]
        public string Situacao { get; private set; }
    }
}
