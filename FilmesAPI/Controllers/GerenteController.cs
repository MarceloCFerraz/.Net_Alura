using FilmesAPI.Data.DTO.Gerente;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] AdicionarGerenteDTO gerenteDto)
        {
            ReadGerenteDTO readDTO = _gerenteService.AdicionaGerente(gerenteDto);

            return CreatedAtAction
                (
                    nameof(RecuperaGerentesPorId),
                    new { Id = readDTO.Id },
                    readDTO
                );
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            List<ReadGerenteDTO>? readDTO = _gerenteService.RecuperaGerentes();
            IActionResult retorno = NotFound();

            if (readDTO != null)
                retorno = Ok(readDTO);

            return retorno;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            ReadGerenteDTO? readDTO = _gerenteService.RecuperaGerentesPorId(id);
            IActionResult? retorno = NotFound();

            if (readDTO != null) retorno = Ok(readDTO);

            return retorno;
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGerente(int id, [FromBody] AtualizarGerenteDTO gerenteDTO)
        {
            ReadGerenteDTO? readDTO = _gerenteService.RecuperaGerentesPorId(id, gerenteDTO);
            IActionResult retorno = NotFound();

            if (readDTO != null)
                retorno = NoContent();

            return retorno;
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            bool retornoDel = _gerenteService.DeletaGerente(id);
            IActionResult retorno = NotFound();

            if (retornoDel)
                retorno = NoContent();

            return retorno;
        }
    }
}
