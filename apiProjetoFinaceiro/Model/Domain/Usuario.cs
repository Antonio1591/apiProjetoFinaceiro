using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiProjetoFinaceiro.Model.Domain
{
    public class Usuario
    {

        protected Usuario()
        {

        }
        public Usuario(string nome, string senha, string email, string telefone, Cidade cidade, Bairro bairro, string cPF, DateTime dataNascimento, string situacao)
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
        public string Nome { get;private set; }
        [Required]
        [MinLength(3)]
        public string Senha { get;private set; }
        [Required]
        public string Email { get;private set; }
        [Required]
        [MinLength(8)]
        public string Telefone { get;private set; }
        [Required]
        public Cidade Cidade { get; private set; }
        [Required]
        public Bairro Bairro { get;private set; }
        [Required]
        [MinLength(11)]
        public string CPF { get;private set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get;private  set; }
        [Required]
        public string Situacao { get;private  set; }

        public void AtualizarEndereco(Cidade cidade, Bairro bairro) 
        {
            if (cidade == null) 
            {
                return;
            }
            Cidade = cidade;
            Bairro = bairro;
        }

        public bool CadastrarUsuario(Usuario usuario)
        {
            //if (string.IsNullOrEmpty(usuario.Nome))
            if (usuario == null)
                return false;
            Id = 0;
            Nome = usuario.Nome;
            Senha = usuario.Senha;
            Email = usuario.Email;
            Telefone = usuario.Telefone;
            Cidade = usuario.Cidade;
            Bairro = usuario.Bairro;
            CPF = usuario.CPF;
            DataNascimento = usuario.DataNascimento;
            Situacao = usuario.Situacao;
            return true;
        }
    }
}

