using API_Pacientes.Data;
using API_Pacientes.Data.DTO;
using API_Pacientes.Models;
using AutoMapper;
using Castle.Core.Internal;
using FluentResults;

namespace API_Pacientes.Services
{
    public class PacienteService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public PacienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadPacienteDTO? AdicionarPaciente(PacienteDTO pacienteDTO)
        {
            ReadPacienteDTO? retorno = null;
            Paciente paciente = _mapper.Map<Paciente>(pacienteDTO);

            try
            {
                _context.Add(paciente);
                _context.SaveChanges();
                retorno = _mapper.Map<ReadPacienteDTO>(paciente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.StackTrace);
            }

            return retorno;
        }

        internal List<PacienteDTO>? RecuperarPacientes()
        {
            List<Paciente>? pacientes = _context.Pacientes.ToList();
            List<PacienteDTO>? pacientesDTO = null;

            if (!pacientes.IsNullOrEmpty())
            {
                pacientesDTO = _mapper.Map<List<PacienteDTO>>(pacientes);
            }

            return pacientesDTO;
        }
    }
}
