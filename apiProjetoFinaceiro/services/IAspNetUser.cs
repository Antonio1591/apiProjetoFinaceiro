namespace apiProjetoFinaceiro.services
{
    public interface IAspNetUser
    {
        Guid ObterUserId();
        string ObterUserEmail();
        bool EstaAutenticado();
    }
}
