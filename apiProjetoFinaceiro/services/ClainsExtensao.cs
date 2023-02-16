using System.Security.Claims;

namespace apiProjetoFinaceiro.services
{
    public static class ClainsExtensao
    {
         public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
            {
                throw new ArgumentNullException(nameof(claimsPrincipal));
            }
            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
            {
                throw new ArgumentNullException(nameof(claimsPrincipal));
            }
            return claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}
