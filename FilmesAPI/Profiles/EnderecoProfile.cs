using AutoMapper;
using FilmesAPI.Data.DTO.Endereco;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<AdicionarEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
            CreateMap<AtualizarEnderecoDTO, Endereco>();
        }
    }
}
