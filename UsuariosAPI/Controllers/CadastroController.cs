using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] CadastroUsuarioDTO cadastroDTO)
        {
            IActionResult retorno = StatusCode(500);
            
            Result cadastro = _cadastroService.CadastraUsuario(cadastroDTO);

            if (cadastro.IsSuccess)
            {
                retorno = Ok(cadastro.Reasons);
            }
            
            return retorno;
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            IActionResult retorno = StatusCode(500);

            Result ativacao = _cadastroService.AtivaContaUsuario(request);

            if (ativacao.IsSuccess)
            {
                retorno = Ok(ativacao.Reasons);
            }

            return retorno;
        }

        [HttpGet("/get-all-users")]
        public IActionResult GetUsuarios()
        {
            IActionResult retorno = NotFound();

            List<UsuarioDTO> usuarios = _cadastroService.GetUsuarios();

            if (usuarios != null)
            {
                retorno = Ok(usuarios);
            }

            return retorno;
        }

        [HttpDelete("/delete/{username}")]
        public IActionResult DeletaUsuario(string username)
        {
            Result deleta = _cadastroService.DeletaUsuario(username);

            IActionResult retorno = NotFound(deleta.Reasons);

            if (deleta.IsSuccess)
            {
                return Ok(deleta.Reasons);
            }

            return retorno;
        }
    }
}
