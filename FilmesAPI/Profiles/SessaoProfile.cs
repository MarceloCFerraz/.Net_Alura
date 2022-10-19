using AutoMapper;
using FilmesAPI.Data.DTO.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<AdicionarSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>()
                .ForMember(dto => dto.HoraDeTermino, opts => opts
                .MapFrom(dto => dto.HoraDeInicio.AddMinutes(dto.Filme.Duracao)));
            // lembrar de tentar remover a busca cíclica sem o jsonignore
            CreateMap<AtualizarSessaoDTO, Sessao>();
        }
    }
}
