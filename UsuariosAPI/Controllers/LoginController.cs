using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result login = _loginService.LogaUsuario(request);

            IActionResult retorno = Unauthorized(login.Reasons); // os Errors do resultadoLogin não estavam funcionando

            if (login.IsSuccess)
            {
                retorno = Ok(login.Reasons); // os Successes do resultadoLogin não estavam funcionando
            }

            return retorno;
        }

        [HttpPost("/Login/reset")]
        public IActionResult ResetSenha(ResetSenhaRequest request)
        {
            IActionResult retorno = StatusCode(500);

            Result reset = _loginService.ResetSenha(request);

            if (reset.IsSuccess)
            {
                retorno = Ok(reset.Reasons);
            }

            return retorno;
        }

        [HttpPost("/Login/reset/confirm")]
        public IActionResult ResetSenhaConfirm(ResetSenhaConfirmRequest request)
        {
            IActionResult retorno = StatusCode(500);

            Result reset = _loginService.ResetSenhaConfirm(request);

            if (reset.IsSuccess)
            {
                retorno = Ok(reset.Reasons);
            }

            return retorno;
        }
    }
}
