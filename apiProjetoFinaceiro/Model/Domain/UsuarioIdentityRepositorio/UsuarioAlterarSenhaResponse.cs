namespace apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio
{
    public class UsuarioAlterarSenhaResponse
    {
        public bool Sucesso { get; private set; }
        public List<string> Erros { get; private set; }

        public UsuarioAlterarSenhaResponse() =>
         Erros = new List<string>();
        public UsuarioAlterarSenhaResponse(bool sucesso = true) : this() =>
            Sucesso = sucesso;
        public void AdicionarErro(string erro) =>
          Erros.Add(erro);

        public void AdicionarErros(IEnumerable<string> erros) =>
               Erros.AddRange(erros);
    
    }
}
