using API_Pacientes.Data.DTO;
using API_Pacientes.Models;
using AutoMapper;

namespace API_Pacientes.Profiles
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<Paciente, ReadPacienteDTO>();
            CreateMap<Paciente, PacienteDTO>();
        }
    }
}
