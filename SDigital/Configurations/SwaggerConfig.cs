using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace SDigital.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("5", new Info
                {
                    Version = "5",
                    Title = "SD Conta",
                    Description = "Contas",
                    Contact = new Contact
                    {
                        Name = "SD",
                        Url = "https://superdigital.com.br/"
                    }
                });
                swagger.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Autorização JWT Header using the Bearer scheme(Obter via IdentityServer). Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                swagger.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                });

                swagger.OperationFilter<ExamplesOperationFilter>();
            });

            return services;
        }

        public static IApplicationBuilder UtilizarConfiguracaoSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/5/swagger.json", "SD Conta");
            });
            return app;
        }
    }
}