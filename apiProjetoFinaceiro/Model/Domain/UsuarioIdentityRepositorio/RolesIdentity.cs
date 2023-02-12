using Microsoft.AspNetCore.Identity;

namespace apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio
{
    public class RolesIdentity
    {
        //private readonly RoleManager<IdentityRole> roleManager1;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesIdentity(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

    }
}
