using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FilmesAPI.Authorization
{
    public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinimaRequirement requirement)
        {
            var retorno = Task.CompletedTask;

            if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                DateTime dataNascimento = Convert.ToDateTime(
                    context.User.FindFirst(
                        c => c.Type == ClaimTypes.DateOfBirth
                    ).Value
                );

                int idade = DateTime.Today.Year - dataNascimento.Year;

                if (dataNascimento > DateTime.Today.AddYears(-idade))
                {
                    idade--;
                }
                if (idade >= requirement.IdadeMinima)
                {
                    context.Succeed(requirement);
                }
            }

            return retorno;
        }
    }
}
