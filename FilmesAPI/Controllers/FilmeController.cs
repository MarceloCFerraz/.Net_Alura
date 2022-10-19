using Castle.Core.Internal;
using FilmesAPI.Data.DTO.Filme;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] AdicionarFilmeDTO filmeDto)
        {
            ReadFilmeDTO readDTO = _filmeService.AdicionaFilme(filmeDto);

            return CreatedAtAction
                (
                    nameof(RecuperaFilmesPorId),
                    new { Id = readDTO.Id },
                    readDTO
                );
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? idade=null)
        {
            List<ReadFilmeDTO>? readDTO = _filmeService.RecuperaFilmes(idade);
            IActionResult retorno = NotFound();

            if (!readDTO.IsNullOrEmpty())
                retorno = Ok(readDTO);

            return retorno;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDTO? readDTO = _filmeService.RecuperaFilmesPorId(id);
            IActionResult? retorno = NotFound();

            if (readDTO != null) retorno = Ok(readDTO);

            return retorno;
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] AtualizarFilmeDTO filmeDTO)
        {
            ReadFilmeDTO? readDTO = _filmeService.RecuperaFilmesPorId(id, filmeDTO);
            IActionResult retorno = NotFound();

            if (readDTO != null)
                retorno = NoContent();

            return retorno;
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            bool retornoDel = _filmeService.DeletaFilme(id);
            IActionResult retorno = NotFound();

            if (retornoDel)
                retorno = NoContent();

            return retorno;
        }
    }
}
