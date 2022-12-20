using apiProjetoFinaceiro.Model.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiProjetoFinaceiro.Model.Imput
{
    [NotMapped]
    public class UsuarioImputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do Usuario Obrigatorio")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
       
        public string Nome { get; set; }
        [Required(ErrorMessage = "Senha do Usuario Obrigatoria")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "A senha deve ter no mínimo 4 e no máximo 100 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Email do Usuario Obrigatorio")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Email deve ter no mínimo 5 e no máximo 100 caracteres.")]
        //[RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone do Usuario Obrigatorio")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Cidade Obrigatoria")]
        public Cidade Cidade { get; set; }
        [Required(ErrorMessage = "Bairro Obrigatorio")]
        public Bairro Bairro { get; set; }
        [Required(ErrorMessage = "CPF do Usuario Obrigatorio")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Data de nascimento Obrigatoria")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Situação obrigatoria")]
        public string Situacao { get; set; }
    }
}
