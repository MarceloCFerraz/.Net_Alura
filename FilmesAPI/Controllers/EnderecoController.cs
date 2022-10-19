using FilmesAPI.Data.DTO.Endereco;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] AdicionarEnderecoDTO enderecoDto)
        {
            ReadEnderecoDTO readDTO = _enderecoService.AdicionaEndereco(enderecoDto);

            return CreatedAtAction
                (
                    nameof(RecuperaEnderecosPorId),
                    new { Id = readDTO.Id },
                    readDTO
                );
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            List<ReadEnderecoDTO>? readDTO = _enderecoService.RecuperaEnderecos();
            IActionResult retorno = NotFound();

            if (readDTO != null)
                retorno = Ok(readDTO);

            return retorno;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            ReadEnderecoDTO? readDTO = _enderecoService.RecuperaEnderecosPorId(id);
            IActionResult? retorno = NotFound();

            if (readDTO != null) retorno = Ok(readDTO);

            return retorno;
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] AtualizarEnderecoDTO enderecoDTO)
        {
            ReadEnderecoDTO? readDTO = _enderecoService.RecuperaEnderecosPorId(id, enderecoDTO);
            IActionResult retorno = NotFound();

            if (readDTO != null)
                retorno = NoContent();

            return retorno;
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            bool retornoDel = _enderecoService.DeletaEndereco(id);
            IActionResult retorno = NotFound();

            if (retornoDel)
                retorno = NoContent();

            return retorno;
        }
    }
}
