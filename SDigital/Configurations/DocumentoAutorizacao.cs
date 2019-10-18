using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SDigital.Configurations
{
    public class DocumentoAutorizacaoRequirement : IAuthorizationRequirement
    {
        public bool DocumentoValidoParaOperacao(AuthorizationHandlerContext ctx)
        {
            string documentoClaim;

            if (string.IsNullOrEmpty(documentoClaim = ctx.User.FindFirstValue("sub"))) return false;

            AuthorizationFilterContext authorizationFilterContext;

            if ((authorizationFilterContext = (AuthorizationFilterContext)ctx.Resource) == null) return false;

            return documentoClaim.Equals(authorizationFilterContext.HttpContext.GetRouteValue("Documento")?.ToString());
        }
    }

    public class DocumentoAutorizacaoHandler : AuthorizationHandler<DocumentoAutorizacaoRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DocumentoAutorizacaoRequirement requirement)
        {
            switch (requirement.DocumentoValidoParaOperacao(context))
            {
                case true: context.Succeed(requirement); break;
                case false: context.Fail(); break;
            }

            return Task.CompletedTask;
        }
    }
}