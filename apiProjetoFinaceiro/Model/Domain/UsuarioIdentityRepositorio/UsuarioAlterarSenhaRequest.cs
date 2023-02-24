using System.ComponentModel.DataAnnotations;

namespace apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio
{
    public class UsuarioAlterarSenhaRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [EmailAddress(ErrorMessage = "O campo{0} é invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter ebtre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }
}
