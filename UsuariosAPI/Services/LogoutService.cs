using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result DeslogaUsuario()
        {
            Result retorno = Result.Fail("Não foi possível deslogar o usuário");

            var signout = _signInManager.SignOutAsync();

            if (signout.IsCompletedSuccessfully)
            {
                retorno = Result.Ok();
            }

            return retorno;
        }
    }
}
