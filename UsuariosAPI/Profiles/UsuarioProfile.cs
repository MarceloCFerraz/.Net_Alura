using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<IdentityUser<int>, UsuarioDTO>();
            CreateMap<CadastroUsuarioDTO, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
