
namespace apiProjetoFinaceiro.Model
{
    public class RespostaApi<TViwerModel>
    {
        public TViwerModel Dados  { get; set;}
        public bool Erro { get; set; }
        public List<string> MenssagensErros { get; set; }= new List<string>();
       

    }
}
