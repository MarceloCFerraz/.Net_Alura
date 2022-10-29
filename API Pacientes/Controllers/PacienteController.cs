using API_Pacientes.Data.DTO;
using API_Pacientes.Services;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;

namespace API_Pacientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpPost]
        public IActionResult AdicionarPaciente([FromBody] PacienteDTO pacienteDTO)
        {
            IActionResult retorno = StatusCode(500);

            ReadPacienteDTO? readDTO = _pacienteService.AdicionarPaciente(pacienteDTO);

            if (readDTO != null)
            {
                retorno = CreatedAtAction
                (
                    nameof(RecuperarPacientePorID),
                    new { Id = readDTO.PacienteID },
                    readDTO
                );
            }

            return retorno;
        }

        [HttpGet]
        public IActionResult RecuperarPacientes()
        {
            IActionResult retorno = NotFound();

            List<PacienteDTO>? pacientesDTO = _pacienteService.RecuperarPacientes();

            if (!pacientesDTO.IsNullOrEmpty())
            {
                retorno = Ok(pacientesDTO);
            }

            return retorno;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPacientePorID(int id)
        {
            IActionResult retorno = NotFound();



            return retorno;
        }
    }
}
