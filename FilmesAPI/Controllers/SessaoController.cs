using FilmesAPI.Data.DTO.Sessao;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] AdicionarSessaoDTO sessaoDto)
        {
            ReadSessaoDTO readDTO = _sessaoService.AdicionaSessao(sessaoDto);

            return CreatedAtAction
                (
                    nameof(RecuperaSessoesPorId),
                    new { Id = readDTO.Id },
                    readDTO
                );
        }

        [HttpGet]
        public IActionResult RecuperaSessoes()
        {
            List<ReadSessaoDTO>? readDTO = _sessaoService.RecuperaSessoes();
            IActionResult retorno = NotFound();

            if (readDTO != null)
                retorno = Ok(readDTO);

            return retorno;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDTO? readDTO = _sessaoService.RecuperaSessoesPorId(id);
            IActionResult? retorno = NotFound();

            if (readDTO != null) retorno = Ok(readDTO);

            return retorno;
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] AtualizarSessaoDTO sessaoDTO)
        {
            ReadSessaoDTO? readDTO = _sessaoService.RecuperaSessoesPorId(id, sessaoDTO);
            IActionResult retorno = NotFound();

            if (readDTO != null)
                retorno = NoContent();

            return retorno;
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            bool retornoDel = _sessaoService.DeletaSessao(id);
            IActionResult retorno = NotFound();

            if (retornoDel)
                retorno = NoContent();

            return retorno;
        }
    }
}
