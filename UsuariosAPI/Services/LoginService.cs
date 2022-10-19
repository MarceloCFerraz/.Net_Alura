using FluentResults;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            Result retorno = Result.Fail("Usuário não autenticado");

            var signin = _signInManager.PasswordSignInAsync
            (
                request.Username, 
                request.Password, 
                false, 
                false
            );

            if (signin.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(
                    usuario => usuario.NormalizedUserName == request.Username.ToUpper()
                );

                var role = _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault();

                Token token;

                if (role != null)
                {
                    token = _tokenService.CreateToken(
                        identityUser,
                        role
                    );
                } else
                {
                    token = _tokenService.CreateToken(
                        identityUser
                    );
                }

                retorno = Result.Ok().WithSuccess(token.Value);
            }

            return retorno;            
        }

        public Result ResetSenhaConfirm(ResetSenhaConfirmRequest request)
        {
            Result retorno = Result.Fail("E-mail não vinculado a nenhum usuário");

            CustomIdentityUser? identityUser = GetUserByEmail(request.Email);
            if (identityUser != null)
            {
                IdentityResult reset = _signInManager.UserManager.ResetPasswordAsync(
                    identityUser,
                    request.ResetToken,
                    request.Senha
                ).Result;

                if (reset.Succeeded)
                {
                    retorno = Result.Ok().WithSuccess("Senha redefinida com sucesso!");
                }

            }

            return retorno;
        }

        public Result ResetSenha(ResetSenhaRequest request)
        {
            Result retorno = Result.Fail("Reset não pôde ser realizado");

            CustomIdentityUser? identityUser = GetUserByEmail(request.Email);

            if (identityUser != null)
            {
                var codigoRecuperacao = _signInManager
                    .UserManager
                    .GeneratePasswordResetTokenAsync(identityUser)
                    .Result;
                retorno = Result.Ok().WithSuccess(codigoRecuperacao);
            }

            return retorno;
        }

        private CustomIdentityUser? GetUserByEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(
                    user => user.NormalizedEmail == email.ToUpper()
                );
        }
    }
}
