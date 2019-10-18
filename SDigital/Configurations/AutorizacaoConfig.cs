using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace SDigital.Configurations
{
    public static class AutorizacaoConfig
    {
        public static IServiceCollection ConfigurarAutorizacao(this IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false,
                    SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                    {
                        return new JwtSecurityToken(token);
                    }
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DocumentoTokenRotaPolicy",
                                policy => policy.Requirements.Add(new DocumentoAutorizacaoRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, DocumentoAutorizacaoHandler>();

            return services;
        }

        public static IApplicationBuilder UtilizarConfiguracaoAutorizacao(this IApplicationBuilder app) => app.UseAuthentication();
    }
}