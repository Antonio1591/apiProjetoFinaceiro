using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiProjetoFinaceiro.Model.Domain
{
    public class Usuario : Entidade
    {

        protected Usuario()
        {

        }
        public Usuario(string nome, string senha, string email, string telefone, Cidade cidade, Bairro bairro, string cPF, DateTime dataNascimento, string situacao)
        {
            if (nome.Length <= 4 || string.IsNullOrEmpty(nome))
                AddErro("O nome do usuario deve ser preenchido");
            if (senha.Length <= 4 || string.IsNullOrEmpty(senha))
                AddErro("A semha deve conter mais de 3 digitos");
            if (email.Length <= 10 || string.IsNullOrEmpty(email))
                AddErro("O Email deve conter mais de 9 caracteres");
            if (telefone.Length <= 8 || string.IsNullOrEmpty(telefone))
                AddErro("Numero invalido, favor digite um numero  valido");
            if (cPF.Length <= 9 || string.IsNullOrEmpty(cPF))
                AddErro("Digite um CPF valido");
            if (dataNascimento.Year < 1900 || dataNascimento.Year > DateTime.Now.Year - 4)
                AddErro("Data de nascimento Invalida");
            if (situacao.Length <= 4 || string.IsNullOrEmpty(cPF))
                AddErro("Digite a situação do Usuario");
            if (!EhValido)
                return;
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

        public void AtualizarEndereco(Cidade cidade, Bairro bairro)
        {
            if (cidade == null)
            {
                return;
            }
            Cidade = cidade;
            Bairro = bairro;
        }

       public void VerificaEmailCpf(string email,string cpf)
        {
            if (cpf.Length <= 9 || string.IsNullOrEmpty(cpf))
                AddErro("Digite um CPF valido");
            if (email.Length <= 10 || string.IsNullOrEmpty(email))
                AddErro("O Email deve conter mais de 9 caracteres");
            if (!EhValido)
                return;
            Email = email;
            CPF = cpf;

        }
        public void AlterarSenha(string senha)
        {
            if (senha.Length <= 4 || string.IsNullOrEmpty(senha))
                AddErro("A semha deve conter mais de 3 digitos");
            if (Senha == senha)
                AddErro("Impossivel Alterar para a mesma senha");
            if (!EhValido)
                return;
            Senha = senha;
        }
    }
}

