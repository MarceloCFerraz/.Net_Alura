using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private UserManager<CustomIdentityUser> _userManager;
        private IMapper _mapper;
        //private EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            //_emailService = emailService;
        }

        public Result CadastraUsuario(CadastroUsuarioDTO cadastroDTO)
        {
            Result retorno = Result.Fail("Falha ao cadastrar usuário");

            Usuario usuario = _mapper.Map<Usuario>(cadastroDTO);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);

            Task<IdentityResult> cadastro = _userManager.CreateAsync
                (
                    usuarioIdentity, cadastroDTO.Password
                );

            var usuarioRoleResult = _userManager.AddToRoleAsync(usuarioIdentity, "regular").Result;
            Console.WriteLine(usuarioRoleResult);

            if (cadastro.Result.Succeeded)
            {
                //var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                //var encodedCode = HttpUtility.UrlEncode(code);

                //_emailService.EnviarEmailConfirmacao
                //(
                //    usuarioIdentity.UserName, 
                //    usuarioIdentity.Email,
                //    "Ative sua conta", 
                //    usuarioIdentity.Id,
                //    encodedCode
                //);
                retorno = Result.Ok().WithSuccess("Usuário Cadastrado com sucesso!");
            }

            return retorno;
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            Result retorno = Result.Fail("Não foi possível confirmar o usuário");

            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioID);

            if (identityUser != null)
            {
                var identityResult = _userManager
                    .ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao)
                    .Result;

                if (identityResult.Succeeded)
                {
                    retorno = Result.Ok();
                }
            }

            return retorno;
        }

        public List<UsuarioDTO> GetUsuarios()
        {
            List<CustomIdentityUser> usuarios = _userManager.Users.ToList();
            List<UsuarioDTO> usuariosDTO = _mapper.Map<List<UsuarioDTO>>(usuarios);

            return usuariosDTO;
        }

        public Result DeletaUsuario(string username)
        {
            Result retorno = Result.Fail("Não foi possível deletar este usuário!");

            var userIdentity = _userManager.Users.FirstOrDefault(u => u.UserName == username);

            if (userIdentity == null)
            {
                retorno = Result.Fail("Não foi possível encontrar este usuario");
            } else
            {
                var delete = _userManager.DeleteAsync(userIdentity).Result;

                if (delete.Succeeded)
                {
                    retorno = Result.Ok().WithSuccess("Usuario deletado com sucesso!");
                }
            }

            return retorno;

        }
    }
}
