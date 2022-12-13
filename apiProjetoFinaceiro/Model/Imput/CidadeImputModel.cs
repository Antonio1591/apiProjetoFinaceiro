using apiProjetoFinaceiro.Model.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiProjetoFinaceiro.Model.Imput
{
    [NotMapped]
    public class CidadeImputModel
    {

        [Required(ErrorMessage = "Impossivel prosseguir sem o nome da Cidade")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Impossivel prosseguir sem o cep da Cidade")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Impossivel prosseguir sem a situação da Cidade")]
        public string Situacao { get; set; }
    }
}
