using Microsoft.Extensions.DependencyInjection;
using SDigital.Interfaces;
using SDigital.Repositories;
using SDigital.Services;

namespace SDigital.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddTransient<IContaService, ContaService>();
            services.AddTransient<IContaRepository, ContaRepository>();
            services.AddTransient<ILancamentoRepository, LancamentoRepository>();

            return services;
        }
    }
}