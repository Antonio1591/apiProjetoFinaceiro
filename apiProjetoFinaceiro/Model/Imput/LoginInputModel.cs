using System.ComponentModel.DataAnnotations;

namespace apiProjetoFinaceiro.Model.Imput
{
    public class LoginInputModel
    {
        protected LoginInputModel() { }
        public LoginInputModel(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
       
        public int Id { get;private set; }
        [Required]
        public string Email { get;private set; }
        [Required]
        public string Senha { get;private set; }
       

    }
}
