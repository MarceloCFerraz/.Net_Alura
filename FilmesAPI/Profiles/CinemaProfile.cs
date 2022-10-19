using AutoMapper;
using FilmesAPI.Data.DTO.Cinema;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<AdicionarCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>();
            CreateMap<AtualizarCinemaDTO, Cinema>();
        }
    }
}
