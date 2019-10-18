using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SDigital.Configurations
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection ConfigurarHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("SD"), name: "Conexão");
            
            return services;
        }
    }
}