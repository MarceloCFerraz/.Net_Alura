using FilmesAPI.Data.DTO.Cinema;
using FilmesAPI.Data.DTO.Filme;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] AdicionarCinemaDTO cinemaDto)
        {
            ReadCinemaDTO readDTO = _cinemaService.AdicionaCinema(cinemaDto);

            return CreatedAtAction
                (
                    nameof(RecuperaCinemasPorId), 
                    new { Id = readDTO.Id }, 
                    readDTO
                );
        }

        [HttpGet]
        public IActionResult RecuperaCinemas()
        {
            List<ReadCinemaDTO>? readDTO = _cinemaService.RecuperaCinemas();
            IActionResult retorno = NotFound();

            if (readDTO != null)
                retorno = Ok(readDTO);

            return retorno;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDTO? readDTO = _cinemaService.RecuperaCinemasPorId(id);
            IActionResult? retorno = NotFound();

            if (readDTO != null) retorno = Ok(readDTO);
            
            return retorno;
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] AtualizarCinemaDTO cinemaDTO)
        {
            ReadCinemaDTO? readDTO = _cinemaService.RecuperaCinemasPorId(id, cinemaDTO);
            IActionResult retorno = NotFound();

            if (readDTO != null)
                retorno = NoContent();
            
            return retorno;
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            bool retornoDel = _cinemaService.DeletaCinema(id);
            IActionResult retorno = NotFound();

            if (retornoDel)
                retorno = NoContent();
            
                return retorno;
        }
    }
}
