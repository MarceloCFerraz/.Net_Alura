﻿using AutoMapper;
using FilmesAPI.Data.DTO.Filme;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<AdicionarFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
            CreateMap<AtualizarFilmeDTO, Filme>();
        }
    }
}
