using api.Data;
using apiProjetoFinaceiro.Model.Domain;
using apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace apiProjetoFinaceiro.services
{
    public class IdentityUsuarioServices : IIdentityUsuarioServices
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;
        public IdentityUsuarioServices(
            SignInManager<IdentityUser> signInManager,
                                UserManager<IdentityUser> userManager,
                                 IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest input)
        {
            var identityUser = new IdentityUser
            {
                UserName = input.Email,
                Email = input.Email,
                EmailConfirmed = true,
               
            };
            
            var result = await _userManager.CreateAsync(identityUser, input.Senha);

            if (result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(identityUser, false);
                //await _userManager.AddClaimAsync(identityUser, new Claim("role", input.Role));
                await _userManager.AddToRoleAsync(identityUser, input.Role);
            }

            var usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);

            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

            return usuarioCadastroResponse;
        }

        public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequet usuarioLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
            if (result.Succeeded)
                return await GerarToken(usuarioLogin.Email);
            var usuarioLoginResponse = new UsuarioLoginResponse(result.Succeeded);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                if (result.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("E necessario realizar a segunda validação");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");

            }
            return usuarioLoginResponse;
        }

        private async Task<UsuarioLoginResponse> GerarToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var tokenClaims = await ObterClaims(user);

            var dataExpiracao = DateTime.UtcNow.AddMinutes(_jwtOptions.Expiration);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: _jwtOptions.signingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new UsuarioLoginResponse
            (
                sucesso: true,
                token: token,
                dataExpiracao: dataExpiracao
            );
        }


        private async Task<IList<Claim>> ObterClaims(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));
            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            return claims;
        }

       
    }
}