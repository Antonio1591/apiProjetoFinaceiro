
namespace apiProjetoFinaceiro.Model
{
    public class RespostaApi<TViwerModel>
    {
        public TViwerModel Dados  { get; set;}
        public bool Erro { get; set; }
        public List<string> MenssagemErro { get; set; }= new List<string>();

    }
}
