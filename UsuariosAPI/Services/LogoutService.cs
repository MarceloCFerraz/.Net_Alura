using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
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
