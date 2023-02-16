using Microsoft.EntityFrameworkCore;

namespace apiProjetoFinaceiro.services
{
    public class AspNetUser:IAspNetUser
    {
        private readonly HttpContextAccessor _contextAccessor;

        public AspNetUser(HttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public Guid ObterUserId()
        {
            return EstaAutenticado() ? Guid.Parse(_contextAccessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }
        public string ObterUserEmail()
        {
            return EstaAutenticado() ? _contextAccessor.HttpContext.User.GetUserEmail() : "";
        }
        public bool EstaAutenticado()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;


         }

    }
}
