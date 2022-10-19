using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario()
        {
            Result logout = _logoutService.DeslogaUsuario();

            IActionResult retorno = Unauthorized(logout.Reasons);

            if (logout.IsSuccess)
            {
                retorno = Ok(logout.Reasons);
            }

            return retorno;
        }
    }
}
