using AutoMapper;
using FilmesAPI.Data.DTO.Gerente;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<AdicionarGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>() // para substituir o [JsonIgnore]
                .ForMember
                (
                    gerente => gerente.Cinemas, opts => opts.MapFrom
                    (
                        gerente => gerente.Cinemas.Select
                        (
                            c => new {c.Id, c.Nome, c.Endereco, c.EnderecoId}
                        )
                    )
                );
            CreateMap<AtualizarGerenteDTO, Gerente>();
        }
    }
}
