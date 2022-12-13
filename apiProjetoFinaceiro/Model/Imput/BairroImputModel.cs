using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiProjetoFinaceiro.Model.Imput
{
    [NotMapped]
    public class BairroImputModel
    {

        [Required(ErrorMessage ="Impossivel prosseguir sem o nome doBairro")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Impossivel prosseguir sem a Situacao do Bairro")]
        public string Situacao { get; set; }
    }
}
